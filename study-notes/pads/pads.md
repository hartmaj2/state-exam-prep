# Notes for prep for the state exam from advanced algorithms and data structures

## TODOs

## Topics

- [x] Dynamické programování
    - [x] princip dynamického programování (řešení podproblémů od nejmenších k největším)
    - [x] aplikace: nejdelší rostoucí podposloupnost, editační vzdálenost
- [x] Grafové algoritmy
    - [x] komponenty silné souvislosti orientovaných grafů
    - [x] toky v sítích (Dinicův a Goldbergův algoritmus)
    - [x] toky v celočíselně ohodnocených grafech, aplikace na párování v bipartitních grafech
- [x] Algoritmy vyhledávání v textu
    - [x] algoritmy Knuth-Morris-Pratt a Aho-Corasicková
- [x] Algebraické algoritmy
    - [x] diskrétní Fourierova transformace a její aplikace
    - [x] výpočet Fourierovy transformace algoritmem FFT
- [x] RSA
    - [x] šifrování, dešifrování a generování klíčů
- [x] Aproximační algoritmy
    - [x] aproximační poměr a relativní chyba
    - [x] aproximační schémata
    - [ ] příklady: obchodní cestující, batoh
- [ ] Paralelní třidění pomocí komparátorových sítí

## Dynamic programming

### Idea

- kind of like recursion because we start solving smaller problems and then compose the solution of bigger problems out of the results for the smaller problem solutions

### Longest increasing subsequence

#### Setting

- we have sequence $a_1,\ldots,a_n$
- we want to find subsequence $a_{i_1},\ldots,a_{i_j}$ s.t.
- $j$ is maximum possible
- $i_k < i_l$ for $k < l$
- $a_{i_k} > a_{i_l}$ if $i_k > i_l$

#### Solution

- stupid solution $\mathcal{O}(2^n)$
  - enumerate all $2^n$ possible subsequences, compute their sums and find the maximum

- better solution $\mathcal{O}(n^2)$
  - for each position $i$ calculate $l_i$ (lenght of the longest increasing subsequence) as maximum of all $l_j$'s for $j < i$ and $a_j < a_i$

- use solution of smaller problems to find the solution of the whole big problem

### Editational distance

#### Setting

- two strings $a,b \in \Sigma^n$
  - for fixed $n$ and alphabet $\Sigma$

- editational operation
  - deletion of character
  - addition of character
  - change of character

- for strings $x,y \in \Sigma^n$ the editational distance $L(x,y)$ is
  - least amount of editational operations that need to be performed to make them equal


## Graph algorithms

### Components of strong connectivity

- input: oriented graph $G=(V,E)$
- objective: find components of strong connectivity (by labeling each of them by same label)

- algorithm
  - flip edge directions to create $G^T$
  - set $comp(v) \leftarrow \emptyset$ undefined for each $v \in V$
  - create❗stack $S \leftarrow \emptyset$
  - run repeated DFS and place a vertex to $S$ when closing it
  - while $S \neq \emptyset$ take vertex $v$ from $S$
    - if $comp(v) = \emptyset$
      - run DFS from $v$ but only open vertices $w$ with $comp(w) = \emptyset$
      - if $comp(w) = \emptyset$ then set $comp(w) \leftarrow v$

### Dinic's algorithm

- $f \leftarrow 0$
- repeat
  - create network of reserves $R$ w.r.t. $f$ and reserves based on $c$
    - remove edges with reserve $0$
  - ❗let $l$ be distance from $s$ to $t$
  - if in $R$ no path from $s$ to $t$ then return $f$
  - tidy up $R$ by running BFS
    - ❗remove edges to previous layers
    - ❗remove all layers after $l$ layers passed
    - remove dead ends
  - find blocking flow $g$ in $R$
    - greedily find unsaturated paths and fill them
    - when dead end would appear, remove it
  - then set $f \leftarrow f + g$

- time complexity
  - each phase increases $l$ for the next phase
    - so we have at most $\mathcal{O}(n)$ phases
  - in each phase, looking for blocking flow takes $\mathcal{O}(nm)$
    - each saturated path removes at least $1$ edge
      - we might run $\mathcal{O}(m)$ times
    - each path has length $\mathcal{O}(n)$
  - total time complexity $\mathcal{O}(mn^2)$

### Goldberg's algorithm

- vertices have heights $h : V \rightarrow \mathbb{N}$
- each vertex has surplus $f^\Delta(v)$ defined as
  - $f^\Delta(v) = f^+(v) - f^-(v)$ 

- algorithm
  - set $h(s) \leftarrow n$
  - $h(v) \leftarrow 0$ for each other $v$
  - ❗set $f \leftarrow 0$ everywhere
  - set $f(su) = c(su)$ for each $su \in E$
  - while exists $v \notin \{s,t\}$ s.t. $f^\Delta(v) > 0$
    - if exists $w$ s.t. $r(vw) > 0$ and $h(v) > h(w)$
      - transfer surplus on $w$
    - else
      - set $h(v) \leftarrow h(v) + 1$

- runs in $\mathcal{O}(mn^2)$

## Text searching algorithms

- setting: text string $\sigma$, pattern string $\iota$
- objective: find $n$ number of occurences of $\iota$ in $\sigma$

### Knuth-Morris-Pratt

- prefix automaton definition
  - we have states $0,...,n$ where $n = |\iota|$
  - $z[s] = k$ iff $\iota[0:k]$ is the largest prefix of $\iota$ which is also a non-trivial suffix of $\iota[0:s]$

- construct prefix automaton for $\iota$
  - do this by searching $\iota$ in $\iota[1:]$

- why the automaton works
  - if we read a letter $x$ and are currently in state $s$ 
    - we have $\iota[0:s]$ is a suffix of currently read $\sigma$
    - we need to see if $\iota[0:s] \cdot x$ is maybe also a prefix of $\iota$
    - if $\iota[s] = x$ 
      - then just move to $s+1$
    - if $\iota[s] \neq x$
      - find largest prefix of $\iota$ in $\iota[0:s]$ and try to append $x$ to it
      - repeat this until can append or $s = 0$

- build automaton algorithm 
  - $z(i) \leftarrow 0$ for each $i \in \{0,\ldots,n\}$
    - where $n=|\iota|$
  - $s \leftarrow 0$
  - $i \leftarrow 0$
  - for each $x \in \iota[1:]$
    - ❗START OF KMP STEP (s,x)
    - repeat
        - if $\iota[s] = x$
          - $s \leftarrow s + 1$
          - break
        - else
          - $s \leftarrow z[s]$
          - if $s = 0$ break
    - ❗END OF KMP STEP
    - $z[i] \leftarrow s$
    - $i \leftarrow i + 1$

- KMP algorithm for needle $\iota$ and straw $\sigma$
  - build prefix automaton $z$
  - for each $x \in \sigma$
    - $s \leftarrow$ result of KMP step for $(s,x)$
    - if $s = n$ 
      - we have occurence!

### Aho-Korasick

- automaton representation
  - states $s \in \{0,...,m\}$ where $m \in \mathbb{N}$
  - $Back(s)$ ... state to which we can get by backward edge (or $\emptyset$ if no such state)
  - $Shortcut(s)$ .. state $z$ whose word $w_z$ is a suffix of $w_s$ and also identical to some $\iota_i$
  - $Word(s)$ ... what word ends here or $\emptyset$
  - $Forward(s,x)$ ... what state we get to from state $s$ when we read letter $x$

## Discrete fourier transform

- discrete fourier transform
  - mapping $\mathcal{F} : \mathbb{C}^n \rightarrow \mathbb{C}^n$
  - for vectors $a = (a_1,\ldots,a_n)$, $b = (b_1,\ldots,b_n)$
  - $\mathcal{F}(a) = b$ iff
    - $b_i = \sum_{k=0}^{n-1}a_k(\omega^i)^k$
  - ❗$n$ determines what is $\omega$ ($n$ is in turn determined by the vector size)

- $\omega$ is a primitive $n$-th root of $1$
  - $\omega^n = 1$
  - for every $i < n$ and ❗$i \neq 0$ we have $\omega^i \neq 1$
  - this is the case for $e^{\frac{2\pi i}{n}}$

## Fast Fourier Transform

- input
  - $n$ is the degree of the polynomial $+1$
  - $\omega$ is $n$-th primitive root of $1$
  - $p=(p_{n-1},\ldots,p_0)$

- $FFT(n,\omega,(p_{n-1},\ldots,p_0))$
  - $l \leftarrow FFT(\frac{n}{2},\omega^2,p_{n-1},\ldots,p_{1})$
  - $s \leftarrow FFT(\frac{n}{2},\omega^2,p_{n-2},\ldots,p_{0})$
  - for $j \in \{0,...,\frac{n}{2}-1\}$
    - $y_j = s_j + \omega^j \cdot l_j$
    - $y_{j+\frac{n}{2}} = s_j - \omega^j \cdot l_j$

## RSA

šifrování, dešifrování a generování klíčů

- Euler's formula
  - $a^{\varphi(n)} \equiv 1 \mod n$

- pick $p,q$ big primes
- set $N=pq$
- we have $\varphi(N)=(p-1)(q-1)$
- message $x$

- pick $e \perp N$
- $y = x^e$
- decryption: $(x^e)^d=x^{ed}=x^{\varphi(N)}$

## Past exams

### Spring 2025 (strong connectivity)


### Spring 2024 (network flows)


### Summer 2024 (components of strong connectivity)

#### (1)

- runs in $\mathcal{O}(m+n)$

#### (3)

- ❗create topological ordering on vertices

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

### Autumn 2023 (discrete fourier transform)