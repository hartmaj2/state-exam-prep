# Pres for ads state exam topic

## Topics

- [x] Časová složitost algoritmů
  - [x] časová a prostorová složitost algoritmu
  - [x] měření velikosti dat
  - [x] složitost v nejlepším, nejhorším a průměrném případě
  - [x] asymptotická notace
- [x] Třídy složitosti
  - [x] třídy P a NP
  - [x] převoditelnost problémů, NP-těžkost a NP-úplnost
  - [x] příklady NP-úplných problémů a převodů mezi nimi
- [x] Metoda rozděl a panuj
  - [x] princip rekurzivního dělení problému na podproblémy
  - [x] výpočet složitosti pomocí rekurentních rovnic
  - [x] Master theorem (kuchařková věta) (bez důkazu)
  - [ ] aplikace
    - [x] Mergesort
    - [ ] násobení dlouhých čísel
- [x] Binarní vyhledávací stromy
  - [x] definice vyhledávacího stromu
  - [x] operace s nevyvažovanými stromy
  - [x] AVL stromy (definice)
- [x] Třídění
  - [x] primitivní třídicí algoritmy (Bubblesort, Insertsort)
  - [x] Quicksort
  - [x] dolní odhad složitosti porovnávacích třídicích algoritmů
- [ ] Grafové algoritmy
  - [ ] prohledávání do šířky a do hloubky
  - [ ] topologické třídění orientovaných grafů
  - [ ] nejkratší cesty v ohodnocených grafech (Dijkstrův a Bellmanův-Fordův algoritmus)
  - [ ] minimální kostra grafu (Jarníkův a Borůvkův algoritmus)
  - [ ] toky v sítích (Ford-Fulkerson algoritmus)

## Time complexity

- time complexity
  - function $f : \mathbb{N} \rightarrow \mathbb{N}$
  - function takes size of input $n$
  - returns time of slowest algorithm run over all inputs of size $n$

## Asymptotic notation

- let $f,g$ be functions $\mathbb{N} \rightarrow \mathbb{R}$
  - we say $f \in \mathcal{O}(g)$ iff
    - exists a positive constant s.t. in long term $g$ is bigger than $f$ no matter how we multiply $f$

## Complexity classes

- class $P$ of problems
  - a problem $L \in P$
  - exists algorithm $A$ and polynomial $f$ s.t. 
    - for every input $x$ we have 
      - $t(A(x)) \leq f(|x|)$
      - $A(x) = L(x)$
  - where $t(A(x))$ is time how long the algorithm ran

- class $NP$ of problems
  - a problem $L \in NP$
  - problem $K \in P$ and polynomial $g$ s.t.
    - for every input $x$ we have
      -  $L(x)=1$ iff there exists $y$ s.t. $|y| \leq g(x)$ s.t. $K(x,y)=1$

- convertibility $A \rightarrow B$
  - if exists $f : \{0,1\}^* \rightarrow \{0,1\}^*$ s.t.
    - for every input $x$
      - $A(x) = B(f(x))$
      - $f(x)$ is poly time computable in terms of $|x|$
  - ❗$A$ cannot be harder than $B$

- $NP$-hard problem $A$
  - for every $B$ in $NP$ we have $B \rightarrow A$

- $NP$-complete problem $A$
  - $A$ is in $NP$ and $A$ is $NP$-hard

### NP-complete problem examples

- SAT
  - input: formula $\varphi$ in CNF
  - objective: exists valuation of variables $x$ s.t. $\varphi(x)=1$

- independent set
  - input: graph $G$, number $k$
  - objective: find set $S \subseteq V$ s.t. $S$ is independent set

- graph coloring
  - input: graph $G$, number $k$
  - objective: exists $k$-coloring of $G$ ?

- knapsack problem

## Binary search trees

### BVS

- ❗rooted tree

- BVS $T$ is ordered binary tree
  - every vertex has at most two children

- for each vertex $x$ we have key $k(x)$
  - $k$ is a mapping

- also for each $x$ in $T$ we have
  - for each $y \in L(x)$ we have $k(y) < k(x)$
  - for each $y \in R(x)$ we have $k(y) > k(x)$
  - where $l(x)$ and $r(x)$ are left and right children of $x$
  - where $L(x)$ is left subtree and $R(x)$ is the right subtree

### AVL Trees

- binary search tree with the following property

- for each element $x$ in the tree, we have $|h(l(x))-h(r(x))| \leq 1$
  - $l(x)$ is the left subtree of $x$
  - $r(x)$ is the right subtree of $x$
  - $h(T)$ is height of the tree

## Divide and conquer

### Master theorem

- recursive problem parameters
  - $a$ how many subproblems we need to compute for each problem
  - $b$ how does the size of the subproblems increase/decrease
  - $c$ complexity ❗**exponent** of solving a single problem

- we have recursive formula $T(n) = a \cdot T(\frac{n}{b}) + \Theta(n^c)$
  - we determine what happens based on ratio $\frac{a}{b^c} = r$
    - $r < 1$ ... $\Theta(n^c)$
    - $r = 1$ ... $\Theta(\log n\cdot n^c)$
    - $r > 1$ ... $\Theta(n^{\log_ba})$