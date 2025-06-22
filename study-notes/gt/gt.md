# Graph theory exam prep

## Topics

- [x] Základní pojmy teorie grafů
  - [x] graf, vrcholy a hrany, izomorfismus grafů, podgraf, okolí vrcholu a stupeň vrcholu, doplněk grafu, bipartitní
graf
- [x] Základní příklady grafů
  - [x] úplný graf a úplný bipartitní graf, cesty a kružnice
- [x] Souvislost grafů, komponenty souvislosti, vzdálenost v grafu
- [ ] Stromy
  - [ ] definice a základní vlastnosti (existence listů, počet hran stromu)
  - [ ] ekvivalentní charakteristiky stromů
- [x] Rovinné grafy
  - [x] definice a základní pojmy (rovinný graf a rovinné nakreslení grafu, stěny)
  - [x] Eulerova formule a maximální počet hran rovinného grafu (důkaz a použití)
- [x] Barevnost grafů
  - [x] definice dobrého obarvení
  - [x] vztah barevnosti a klikovosti grafu
- [x] Hranová a vrcholová souvislost grafů
  - [x] hranová a vrcholová verze Mengerovy věty
- [x] Orientované grafy, silná a slabá souvislost
- [x] Toky v sítích
  - [x] definice sítě a toku v ní
  - [x] existence maximálního toku (bez důkazu)
  - [x] princip hledání maximálního toku v síti s celočíselnými kapacitami (například pomocí Ford-Fulkersonova
algoritmu)

## Menger theorem

### Jelinek version

- edge onnectivity $k_e(G) = \min{ \{ |F| ; F \subseteq E \text{ is edge cut of } G \} }$

- vertex connectivity $k_v(G) =$
  - $n - 1$ if $G \simeq K_n$
    - ❗this condition is needed because for $K_n$ there exists no vertex cut of any size
  - $\min{ \{ |A| ; A \subseteq V \text{ vertex cut of } G \} }$

- graph $G$ is $k$ vertex-connected iff
  - $k \leq k_v(G)$

- Menger edge theorem
  - let $G = (V,E)$ be a graph
  - $k_e(G) = t$ iff
    - for every $u,v$ there exist at least $t$ edge disjoint paths from $u$ to $v$

- Menger vertex theorem
  - same as above but
  - vertex disjoint paths where ❗$u$ and $v$ can be shared

### My version

- $G$ is $k$-edge connected
  - iff for every $x \neq y$ there exists no cut $C$ that uses less than $k$ edges and disconnects $x$ from $y$

- global edge version
  - graph $G$ is edge $k$-connected iff
    - for every $x \neq y \in V(G)$ there exist $k$ edge-disjoint paths from $x$ to $y$

- $G$ is $k$-vertex connected iff
  - $V(G) > k$
  - contains no vertex cut $C$ s.t. $|C| < k$ 

- global vertex version
  - graph $G$ is vertex $k$-connected iff
    - for every $x \neq y \in V(G)$ there exist $k$ **internally** vertex-disjoint paths from $x$ to $y$

### Bipartite graph

- graph $G=(V,E)$ is bipartite iff
  - exist sets $A,B \subseteq V$ s.t.
    - $A \cap B = \emptyset$
    - $A \cup B = V$
    - for every $\{u,v\} \in E$ we have
      - $u \in A \wedge v \in B$ or
      - $v \in A \wedge u \in B$

## Trees

### Every tree has at least 2 leafs

- leaf $v \in V(T)$ iff
  - $\deg(v) = 1$

- every finite tree with $|V(T)| \geq 2$ hast at least $2$ leaves
  - since the tree is finite we can consider all $uv$-paths for all choices $u,v \in V(T)$ (there is finitely many of them)
  - let $P = \argmax{ \{ |P| \ : \ \text{ P is a } uv \text{-path } \} }$
  - since $P = (v_0,e_0,\ldots,e_{k-1},v_k)$ was taken as the longest, there exists no edge from $v_0$ to any other vertex than $v_1$
    - otherwise, we would have a loop or we could extend the path


## Past exams