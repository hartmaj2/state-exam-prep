# State exam prep on advance discrete mathematics

## Topics

- [x] Barvení grafů
  - [x] definice a základní vlastnosti
  - [x] hranová barevnost (definice, formulace Vizingovy věty, souvislost s párováními v grafech)
  - [x] Brooksova věta (formulace)
  - [x] základní metody z důkazů Vizingovy a Brooksovy věty (Kempeho řetězce, hladový algoritmus)
  - [x] silná a slabá věta o perfektních grafech (formulace), chordální grafy a další příklady tříd perfektních grafů
- [ ] Párování v grafech
  - [ ] definice párování a perfektního párování
  - [ ] párování v obecných grafech (formulace Tutteovy věty včetně důkazu jednodušší implikace, Petersenova
  věta a její důkaz použitím Tutteovy věty)
  - [ ] Edmondsův algoritmus (pouze vědět o jeho existenci)
- [ ] Kreslení grafů na plochách
  - [ ] základní topologické pojmy (homeomorfismus, křivka, plocha)
  - [ ] konstrukce ploch pomocí přidávání uší a křížítek (formulace), orientovatelné a neorientovatelné plochy,
  Eulerova charakteristika
  - [ ] pojem buňkového (2-cell) nakreslení
  - [ ] zobecněná Eulerova formule, její použití pro horní odhad počtu hran a minimálního stupně v grafu
  nakresleném na dané ploše
- [ ] Grafové minory
  - [ ] definice a základní vlastnosti
  - [ ] zachovávání nakreslení při minorových operacích
- [ ] Množiny a zobrazení
  - [ ] přehled o používané terminologii (třídy a vlastní třídy, kartézský součin, relace, zobrazení, suma, potenční
  množina, ...)
- [ ] Subvalence a ekvivalence množin
  - [ ] definice
  - [ ] Cantorova-Bernsteinova věta (bez důkazu)
  - [ ] spočetné množiny
    - [ ] definice
    - [ ] zachovávání spočetnosti při množinových operacích
  - [ ] mohutnost množin racionálních a reálných čísel, důkaz neekvivalence diagonální metodou
- [ ] Dobré uspořádání
  - [ ] definice
  - [ ] ordinální a kardinální čísla (definice)

## Graph coloring

### Brooks theorem

- Brooks theorem
  - for graph $G$ which is connected
    - $G$ has $\chi(G) = \Delta(G) + 1$ iff $G$ is an odd cycle or a complete graph
    - otherwise $\chi(G) \leq \Delta(G)$
    - where $\Delta(G) = \max_{v \in V(G)}\deg(v)$

### Vizing's theorem

#### Formulation

- Vizing's theorem
  - for any graph we have either $\Delta(G) \leq \chi'(G) \leq \Delta(G) + 1$

#### Proof

- suppose we have a graph $G$ s.t. it cannot be edge colored by $\Delta(G) + 1$ colors
- note there exists a subgraph $H$ with $V(G) = V(H)$ s.t. it can be $\Delta(G) + 1$ colored
  - e.g. we can take empty graph
  - or graph with single edge
    - then $\Delta(G) = 1$ and we can surely color it using $2$ colors
- suppose such $H$ which is edge inclusion maximal (no more edges can be added)
- now we find a contradiction
- we suppose an edge $e = \{x,y\} \in E(G)$ s.t. $e \notin E(H)$
- ❗now for any vertex $z \in V(H)$ we have that it has at most $\Delta(G)$ edges going out of it
  - this means that there exists $\alpha \in B$ s.t. the color $\alpha$ is not used by any edge incident on $z$ (because we can use $|B| = \Delta(G) + 1$ colors)
- let for every vertex $v$ denote by $\phi(v)$ the color that is free for that vertex
- then the following might happen:
  - $\phi(x) = \phi(y)$
    - then we can just color edge $e$ with color $\phi(x)$
- so suppose $\phi(x) \neq \phi(y)$
- there must exist an edge $e_1 = \{x,y_1\}$ s.t. $c(e_1) = \phi(y)$
  - in the case that $\phi(x) = \phi(y_1)$ we can color edge $e_1$ with color $\phi(x)$
  - this will make color $\phi(y)$ free on $x$ and we will be able to color $e$ using color $\phi(y)$
- if the above is not the case, we try to construct a hand-fan $y_1,\ldots,y_k$ s.t. $\phi(x) = \phi(y_k)$ and also for any $i \neq j : \phi(y_i) \neq \phi(y_j)$ 
  - once we have this hand-fan, we can just flip colors of the edges until we have color $\phi(y)$ free on $x$
  - ❗note that if we had $\phi(y_i) = \phi(y_j)$ for $i < j$, this would mean that for $y_j$ we cannot continue adding another edge to the fan with $c(e_j) = \phi(y_j)$ because we already have edge with such color
- in that case we create a so called Kempe chain
  - suppose we have $i < j$ s.t. $\phi(y_i) = \phi(y_j) = \beta$
  - also, let $\phi(x) = \alpha$ and let $\phi(y) = \gamma$
  - objective:
    - make $\phi'(x) = \gamma$
  - we create a Kempe chain which is a path with alternating colors of $\alpha$ and $\beta$ starting at $y_i$ ❗and it is the longest such

### Perfect graphs

#### Perfect graph

- perfect graph
  - $G$ is perfect if for every induced subgraph $H \subseteq G$ we have that $\kappa(H) = \chi(H)$
    - where $\kappa(G) = \max_{K \subseteq G : K \text{ is complete }}|V(K)|$
      - i.e. the size of the maximal clique in $G$

#### Strong perfect graph theorem

- graph $G$ is perfect iff it does not contain
  - an odd cycle ❗of size $\geq 5$ as an induced subgraph 
  - ❗and no induced subgraph $H$ s.t. $H$ is a complement of some odd cycle of size $\geq 5$

#### Weak perfect graph theorem

- a graph $G$ is perfect iff $\overline{G}$ is perfect
  - where $\overline{G}$ is the complement of $G$

#### Chordal graph

- $G$ is chordal iff $G$ does not contain an odd cycle of length greater than $3$ as an induced subgraph

#### Classes of perfect graphs

- chordal graphs
- complete graphs
- bipartite graphs