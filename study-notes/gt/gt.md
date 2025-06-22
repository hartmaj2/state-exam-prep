# Graph theory exam prep

## Topics

- [x] Základní pojmy teorie grafů
  - [x] graf, vrcholy a hrany, izomorfismus grafů, podgraf, okolí vrcholu a stupeň vrcholu, doplněk grafu, bipartitní
graf
- [x] Základní příklady grafů
  - [x] úplný graf a úplný bipartitní graf, cesty a kružnice
- [ ] Souvislost grafů, komponenty souvislosti, vzdálenost v grafu
- [ ] Stromy
  - [ ] definice a základní vlastnosti (existence listů, počet hran stromu)
  - [ ] ekvivalentní charakteristiky stromů
- [ ] Rovinné grafy
  - [ ] definice a základní pojmy (rovinný graf a rovinné nakreslení grafu, stěny)
  - [ ] Eulerova formule a maximální počet hran rovinného grafu (důkaz a použití)
- [ ] Barevnost grafů
  - [ ] definice dobrého obarvení
  - [ ] vztah barevnosti a klikovosti grafu
- [ ] Hranová a vrcholová souvislost grafů
  - [ ] hranová a vrcholová verze Mengerovy věty
- [ ] Orientované grafy, silná a slabá souvislost
- [ ] Toky v sítích
  - [ ] definice sítě a toku v ní
  - [ ] existence maximálního toku (bez důkazu)
  - [ ] princip hledání maximálního toku v síti s celočíselnými kapacitami (například pomocí Ford-Fulkersonova
algoritmu)

## Menger theorem

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