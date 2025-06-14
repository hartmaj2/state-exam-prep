# Pres for ads state exam topic

## Topics

- [x] Časová složitost algoritmů
  - [x] časová a prostorová složitost algoritmu
  - [x] měření velikosti dat
  - [x] složitost v nejlepším, nejhorším a průměrném případě
  - [x] asymptotická notace
- [ ] Třídy složitosti
  - [ ] třídy P a NP
  - [ ] převoditelnost problémů, NP-těžkost a NP-úplnost
  - [ ] příklady NP-úplných problémů a převodů mezi nimi
- [ ] Metoda rozděl a panuj
  - [ ] princip rekurzivního dělení problému na podproblémy
  - [ ] výpočet složitosti pomocí rekurentních rovnic
- [ ] Master theorem (kuchařková věta) (bez důkazu)
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