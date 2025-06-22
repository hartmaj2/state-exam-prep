# State exam prep on advance discrete mathematics

## Topics

- [x] Barvení grafů
  - [x] definice a základní vlastnosti
  - [x] hranová barevnost (definice, formulace Vizingovy věty, souvislost s párováními v grafech)
  - [x] Brooksova věta (formulace)
  - [x] základní metody z důkazů Vizingovy a Brooksovy věty (Kempeho řetězce, hladový algoritmus)
  - [x] silná a slabá věta o perfektních grafech (formulace), chordální grafy a další příklady tříd perfektních grafů
- [x] Párování v grafech
  - [x] definice párování a perfektního párování
  - [x] párování v obecných grafech (formulace Tutteovy věty včetně důkazu jednodušší implikace, Petersenova
  věta a její důkaz použitím Tutteovy věty)
  - [x] Edmondsův algoritmus (pouze vědět o jeho existenci)
- [ ] Kreslení grafů na plochách
  - [x] základní topologické pojmy (homeomorfismus, křivka, plocha)
  - [x] konstrukce ploch pomocí přidávání uší a křížítek (formulace), orientovatelné a neorientovatelné plochy,
  Eulerova charakteristika
  - [x] pojem buňkového (2-cell) nakreslení
  - [ ] zobecněná Eulerova formule, její použití pro horní odhad počtu hran a minimálního stupně v grafu
  nakresleném na dané ploše
- [x] Grafové minory
  - [x] definice a základní vlastnosti
  - [x] zachovávání nakreslení při minorových operacích
- [x] Množiny a zobrazení
  - [x] přehled o používané terminologii (třídy a vlastní třídy, kartézský součin, relace, zobrazení, suma, potenční
  množina, ...)
- [x] Subvalence a ekvivalence množin
  - [x] definice
  - [x] Cantorova-Bernsteinova věta (bez důkazu)
  - [x] spočetné množiny
    - [x] definice
    - [x] zachovávání spočetnosti při množinových operacích
  - [x] mohutnost množin racionálních a reálných čísel, důkaz neekvivalence diagonální metodou
- [x] Dobré uspořádání
  - [x] definice
  - [x] ordinální a kardinální čísla (definice)

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

## Drawing graphs on surfaces

### Basic definitions

- homeomorphism
  - mapping $f : \mathbb{R}^d \rightarrow \mathbb{R}^d$ s.t.
    - $f$ is continuous
    - $f$ is bijective
    - ❗$f^{-1}$ is continuous

- arc
    - mapping $f : [0,1] \rightarrow \mathbb{R}^d$ s.t. 
      - $f$ is injective
      - $f$ is continuous

- surface
  - $2$-dimensional topological manifold without a "boundary" s.t. it is also
    - compact
    - connected
  - ❗$\mathbb{R}^2$ is not a surface

- connected surface $S$
  - cannot be expressed as union $S = A \cup B$ s.t.
    - $A \cap B = \emptyset$ and $A,B$ are open

- manifold with boundary 
  - is a topological space 
  - where each point has a neighborhood homeomorphic either to 
    - the open $n$-dimensional Euclidean space $\mathbb{R}^n$, 
    - or to the closed half-space $\mathbb{H}^n = \{ x \in \mathbb{R}^n : x_n \geq 0 \}$

- drawing
  - mapping $\varphi : V(G) \cup E(G) \rightarrow S$ where $S$ is a surface, $G$ a graph and
    - for each $v \in V(G)$ we have $\varphi(v) \in S$
    - for $u \neq v$ we have $\varphi(u) \neq \varphi(v)$
    - for $e = \{u,v\}$ then $\varphi(e)$ is an arc in $S$
    - for $e_1 \neq e_2$ we have $\varphi(e_1) \cap \varphi(e_2) = \varphi(e_1 \cap e_2)$

- face
  - connected component of $S \setminus (\cup_{v \in V}\varphi(v) \cup \cup_{e \in E}\varphi(e) )$

### Construction of topological surfaces

- adding a 
  - ❗crosscap
    - introduces non-orientability
  - ❗handle
    - increases genus by $1$

- euler characteristic ❗of a surface
  - $\chi(S) = V(G) + F(G) - E(G)$
    - where $G$ is any triangulation drawn on $S$
  - for sphere we have $\chi(\Sigma_0) = 2$

- surface classification
  - let $S$ be a surface with $k$ crosscaps and $l$ handles
    - orientable if $k = 0$
    - non-orientable otherwise 

- notation
  - $\Sigma_g$ 
    - surface that was created from $\Sigma_0$ by adding $g$ ears
  - $\Pi_g$
    - surface that was created from $\Sigma_0$ by adding $g$ crosscaps where $g > 0$

- genus of a surface $S$ is $\Gamma(S)$
  - suppose $S$ has $k$ crosscaps and $l$ handles
  - if $S$ is orientable
    - $\Gamma(S) = l$
    - $\chi(S) = 2 - 2 \cdot \Gamma(S)$
  - if $S$ is non-orientable
    - $\Gamma(S) = k + 2l$
    - $\chi(S) = 2 - \Gamma(S)$
  - ❗i.o.w. for euler characteristic
    - adding ear has always value 2
    - adding crosscap has value 1

- $2$-cell embedding
  - drawing of a graph in which each face is homeomorphic to an open $2$-dimensional ball in $\mathbb{R}^2$

### Generalized Euler's formula

- for any graph drawn on surface $S$ we have
  - $v + f \geq e + \chi(S)$ ❗(direction of the inequality)
  - if $2$-cell embedding then
    - $v + f = e + \chi(S)$

- from that we can derive
  - $e \leq 3v - 3\chi(S)$
    - (increasing the genus of the surface $\rightarrow$ decreasing genus $\rightarrow$ increasing the right hand side of the inequality)

- from that we have
  - $\mu \leq 6 - \frac{\chi(S)}{v}$
    - where $\mu$ is the average degree in $G$

- trivially also 
  - $\delta \leq 6 - \frac{\chi(S)}{v}$
    - where $\delta$ is the minimum degree in $G$
  - and $\delta \leq \Delta \leq v + 1$

## Graph matching

- matching $M$ in graph $G=(V,E)$
  - $M \subseteq E$ s.t.
    - for any $e_1 \neq e_2 \in M$ we have $e_1 \cap e_2 = \emptyset$

- perfect matching $M$ iff 
  - $\bigcup_{e \in M}=V(G)$

- Tutte theorem
  - $G$ has perfect matching iff $\forall S \subseteq V(G) : odd(V(G) \setminus S) \leq |S|$
  - $odd(G) =$ # of components of odd size
  - ❗easier implication 
    - $\implies$

- Petersen theorem
  - $G$ has perfect matching iff $G$ is $2$-edge connected and $3$-regular
  - proof outline
    - just check Tutte criterion
    - fix a subset $S \subseteq V(G)$
    - draw a diagram with odd components
      - at least two edges must go from each odd component to $S$
        - ($2$-edge connectedness)
      - ❗observe that if we have odd component s.t. degree of every vertex inside is odd
        - then an odd number of edges must go out of it
      - ❗use two way counting 
        - at most $3$ edges go out of any vertex in $S$ ($3$-regularity)
        - at least $3$ edges go out of every odd component

## Minors

- minor $H$ of $G$
  - $H \preceq G$ iff 
    - $H$ can be obtained from $G$ by a sequence of
      - edge deletions
      - vertex deletions
      - edge contractions

- if $H$ is subgraph of $G$ then $H \preceq G$

- if $G$ planar then $H \preceq G$ planar

- Kuratowski and Wagner
  - the following statements are equivalent
    - $G$ is planar
    - $G$ does not contain a subdivision of $K_{3,3}$ or $K_5$ as a subgraph
    - $G$ does not contain $K_{3,3}$ or $K_5$ as a minor

## Classes and proper classes

### Terminology basics

- class 
  - class term
    - expression of form $\{ x \ ; \ \varphi(x) \}$ 
  - collection of objects described by a class

- proper class
  - class that is not a set

### Subvalency and equivalency

- let $A,B$ sets
  - $A \preceq B$ iff exists an injective function from $A$ to $B$

- Cantor-Bernstein for $A,B$ sets
  - $A \approx B$ iff $A \preceq B \wedge B \preceq A$

- countably infinite set $A$
  - if $A \approx \omega$

- countable $A$
  - if $A \preceq \omega$

- proof of $x \not \approx \mathcal{P}(x)$
  - ❗show that there is no **surjective** function $f : x \rightarrow \mathcal{P}(x)$

- proof of $\mathbb{R} \approx \mathcal{P}(\omega)$
  - prove $\mathbb{R} \approx [0,1] \approx {}^{\omega}2 \approx \mathcal{P}(\omega)$

### Well ordering

- well ordering $\preceq$ of set $M$
  - for every $\emptyset \neq A \subseteq M$ we have that $A$ has a least element w.r.t. $\preceq$
  - ❗$A$ is non-empty

- set $x$ is transitive iff
  - for every $y \in x$ we have that if $z \in y$ then $z \in x$

- $\alpha$ is ordinal iff
  - $\alpha$ is transitive
  - $\in$ relation is strict well ordering on $\alpha$

- $\kappa$ is cardinal iff
  - $\kappa$ is an ordinal
  - if $\alpha < \kappa$ then $\alpha \not \approx \kappa$

## Past exams

### Spring 2025 (graph drawing)

#### (2)

- use generalized Euler's formula (the one with inequality)

- ❗each face is bounded by at least $3$ edges

#### (3)

- use generalized Euler's formula for $2$-cell embeddings

- ❗use the fact that for any drawing we have $f \geq 1$

### Summer 2024 (perfect matchings and Tutte)

#### (2)

- ❗sometimes the second part does not use what was formulated in the first part
- also, don't be lazy and draw examples

#### (3)

- ❗sometimes the solution is a reduction of the problem to some other problem
  - think if solving something else doesn't provide me a solution to the original problem

- this problem was also a nice example showing that 
  - we can reduce the problem of:
    - finding a set of edges such that each vertex has prescribed number of incident edges
  - into a problem of:
    - finding a perfect matching
  - done using the weird construction