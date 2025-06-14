# Notes for prep for the state exam from advanced algorithms and data structures

## TODOs

## Topics

- [ ] Dynamické programování
    - [ ] princip dynamického programování (řešení podproblémů od nejmenších k největším)
    - [ ] aplikace: nejdelší rostoucí podposloupnost, editační vzdálenost
- [ ] Grafové algoritmy
    - [ ] komponenty silné souvislosti orientovaných grafů
    - [ ] toky v sítích (Dinicův a Goldbergův algoritmus)
    - [ ] toky v celočíselně ohodnocených grafech, aplikace na párování v bipartitních grafech
- [ ] Algoritmy vyhledávání v textu
    - [ ] algoritmy Knuth-Morris-Pratt a Aho-Corasicková
- [ ] Algebraické algoritmy
    - [ ] diskrétní Fourierova transformace a její aplikace
    - [ ] výpočet Fourierovy transformace algoritmem FFT
- [ ] RSA
    - [ ] šifrování, dešifrování a generování klíčů
- [ ] Aproximační algoritmy
    - [ ] aproximační poměr a relativní chyba
    - [ ] aproximační schémata
    - [ ] příklady: obchodní cestující, batoh
- [ ] Paralelní třidění pomocí komparátorových sítí

## Dynamic programming

### Idea

- kind of like recursion because we start solving smaller problems and then compose the solution of bigger problems out of the results for the smaller problem solutions

## Past exams

### Spring 2025 (strong connectivity)


### Spring 2024 (network flows)


### Summer 2024 (components of strong connectivity)


### Autumn 2024 (dynamic programming)

#### (1) Solving the problem

- simple solution
  - test all possible subsequences $2^n$ possible combinations

- we compute $X_{i,j}$ which is a boolean indicator
  - can we find subset of items $a_0,\ldots,a_i$ s.t. sum of its weights is $j$?

- suppose we want to compute $X_{i+1,j}$
  - we have one more item available $a_i$
  - we want to sum up to $j$

- it makes no sense to consider $X_{i-2,j}$ and lower ($i$ or $j$) if we already have precomputed values for $X_{i-1,j}$ and lower values
  - because if we had true for $X_{i-k,j}$ it would be true also for higher $i$'s

- does it make sense to consider values other than $X_{i-1,j-a_i}$ for the same row $i-1$?
  - because if $X_{i-1,j-a_i} = 1$ then $X_{i,j} = 1$
  - ❗it seems like otherwise, we just set $X_{i,j}$ to $X_{i-1,j}$ but I don't know why

- suppose we want to use items $a_0, \ldots a_i$ to get sum $j$
  - for any solution $S$ of this problem we have either 
  - $a_i \in S$
    - if there exists such solution $S$ with $|S|=j$ there must also exist solution $S'$ with $|S'|=j-a_i$ for problem with items $a_0,\ldots,a_{i-1}$ (proof by contradiction)
  - $a_i \notin S$  
    - if there is such solution $S$ then it must also solve the problem where only $a_0,\ldots,a_{i-1}$ are available so there exists corresponding $S'$

- so in the algorithm we go through the whole row first and at the and move down by one row

#### (2) Writing out the solution

- at each entry in the table $i,j$, if $X_{i,j} = 1$ we write:
  -  $P_{i,j} = (i-1,j)$ if $X_{i-1,j}=1$
  -  $P_{i,j} = (i-1,j-a_i)$ otherwise

- now if $X_{n,s}=1$, then we can backtrack to find the elements in the solution

- if $P_{i,j} = (i-1,j)$ then $i$ is not in the solution
- if $P_{i,j} = (i-1,j-a_i)$ then $i$ is in the solution

#### (3) Finding the cheapest treasure

- setting
  - we have also $c_1,\ldots,c_n$ : prices of the elements

- problem
  - there can be mutliple valid treasures
  - we want to find the one with lowest sum of $c_i$'s
  - multiple solutions occur when $X_{i-1,j} = 1$ but also $X_{i-1,j-a_i}=1$
  - then we must also hold $C_{i,j}$ for each position which is the cost of the current solution

- computing $C_{i,j}$
  - if both $X_{i-1,j} = X_{i-1,j-a_i} = 1$ then we set:
    - $C_{i,j}= \min(C_{i-1,j};C_{i-1,j-a_i}+c_i)$

- ❗space complexity can be reduced because we only need the previous row for each computation