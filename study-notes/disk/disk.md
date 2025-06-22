# Discrete mathematics state exam prep

## Topics

- [ ] Relace
  - [ ] vlastnosti binárních relací (reflexivita, symetrie, antisymetrie, tranzitivita)
- [ ] Ekvivalence a rozkladové třídy
- [ ] Částečná uspořádání
  - [ ] základní pojmy (minimální a maximální prvky, nejmenší a největší prvky, řetězec, antiřetězec)
  - [ ] výška a šířka částečně uspořádané množiny a věta o jejich vztahu (o dlouhém a širokém)
- [ ] Funkce
  - [ ] typy funkcí (prostá, na, bijekce)
  - [ ] počty různých typů funkcí mezi dvěma konečnými množinami
- [ ] Permutace a jejich základní vlastnosti (počet a pevný bod)
- [ ] Kombinační čísla a vztahy mezi nimi, binomická věta a její aplikace
- [ ] Princip inkluze a exkluze
  - [ ] obecná formulace (a důkaz)
  - [ ] použití (problém šatnářky, Eulerova funkce pro počet dělitelů, počet surjekcí)
- [x] Hallova věta o systému různých reprezentantů a její vztah k párování v bipartitním grafu
  - [x] princip důkazu a algoritmické aspekty (polynomiální algoritmus pro nalezení SRR)

## Inclusion exclusion principle

### Formulation

- let $A_1,\ldots,A_n$ sets
- inclusion exclusion principle
  - $|\bigcup_{i=1}^n A_i| = \sum_{i=1}^n(-1)^{i+1}\sum_{I \in \binom{[n]}{i}}|\bigcap_{j \in I}A_j|$

- also
  - $|\bigcup_{i=1}^n A_i| = \sum_{\emptyset \neq I \subseteq [n]}(-1)^{|I|+1}|\bigcap_{j\in I}A_j|$

### Proof

- suppose we have $x \in \bigcup_{i=1}^n A_i$
  - we want to show that the element is counted exactly once on the right side
- let $J = \{ j \in [n] \ ; \ x \in A_j \}$
- in what intersections does $x$ get counted?
- only in those that contain no set $A_i$ s.t. $i \notin J$
- so only in intersections of sets determined by indices $I \subseteq J$
- so we can just count the following:
  - $\sum_{\emptyset \neq I \subseteq J}(-1)^{|I|+1}|\bigcap_{i \in I}A_i|$
- since for every intersection, we count $x$ once, we just want to see whether:
  - $\sum_{\emptyset \neq I \subseteq J}(-1)^{|I|+1} = 1$
- so we want
  - $\sum_{|I| \text{ odd } : \ \emptyset \neq I \subseteq J}1 = 1 + \sum_{|I| \text{ even } : \ \emptyset \neq I \subseteq J}1$
  - $\sum_{|I| \text{ odd } : \ I \subseteq J}1 = \sum_{|I| \text{ even } : \  I \subseteq J}1$
  - $|\{ I \subseteq J ; |I| \text{ is odd } \}| = |\{ I \subseteq J ; |I| \text{ is even } \}|$

## Hall theorem

### For bipartite graphs

- let $G=(V,E)$ be bipartite graph with partitions $A,B$
- there exists matching that saturates $A$ iff
  - for every $F \subseteq A$ we have $|N(F)| \geq |F|$

### System of distinct representants

- let $X$ be a ground set and $M_1,\ldots,M_k$ s.t. $M_i \subseteq X$
- system of distinct representants is a function
  - $f : [k] \rightarrow X$ s.t.
    - for every $i$ we have $f(i) \in M_i$
    - $f$ is injective

- Hall theorem
  - there exists SDR iff 
    - for every $J \subseteq [k]$ we have $|J| \leq |\bigcup_{i \in J}M_i|$


## Past exams

### Spring 2025 (Euler graphs)

#### (1)

- ❗note that $\emptyset$ is disjunct with any other set

#### (2)

- ❗note that for $\emptyset$, since it is disjunt with every set and there cannot be edge to itself and to $[n]$ because that is not included, we have
  - $\deg(\emptyset) = 2^n-2$

#### (3)

- graph $G$ is eulerian iff
  - for every $v \in V(G)$ we have $\deg(v)$ is even
  - ❗$G$ is connected