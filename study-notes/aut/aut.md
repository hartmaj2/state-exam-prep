# Prep for automata and grammars

## Topics

- [x] Regulární jazyky
  - [ ] regulární gramatiky
  - [x] deterministický a nedeterministický konečný automat
  - [ ] regulární výrazy
- [ ] Bezkontextové jazyky
  - [ ] bezkontextové gramatiky, jazyk generovaný gramatikou
  - [ ] zásobníkový automat, třída jazyků přijímaných zásobníkovými automaty
- [ ] Rekurzivně spočetné jazyky
  - [ ] gramatika typu 0
  - [ ] Turingův stroj
  - [ ] algoritmicky nerozhodnutelné problémy
- [ ] Chomského hierarchie
  - [ ] schopnost zařazení konkrétního jazyka do Chomského hierarchie (zpravidla sestrojení odpovídajícího au-
tomatu či gramatiky)

## Regular languages

### Deterministic finite automaton

- 5-tuple $A=(Q,\Sigma,\delta,q_0,F)$
  - $Q$ ... states
  - $\Sigma$ ... alphabet
  - $\delta : Q \times \Sigma \rightarrow Q$ ... transition function
  - $q_0$ ... initial state
  - $F \subseteq Q$ ... final states

#### Extended transition function

- $\delta^* : Q \times \Sigma^* \rightarrow Q$
  - $\delta^*(q,xa) = \delta(\delta^*(q,x),a)$
  - $\delta^*(q,\epsilon) = q$

### Regular language

- $L \subseteq \Sigma^*$ s.t. exists deterministic finite automaton $A$ with $L(A) = L$

### Pumping lemma

- for every regular language $L$ exists a constant $n \in \mathbb{N}$ (higher than number of states of the automaton $A$ for the regular language) s.t. for every word $w \in L$ s.t. $|w| \geq n$ then we can split $w = xyz$ s.t.
  - $y$ is nonempty
  - $|xy| \leq n$
  - for each $k \in \mathbb{N}_0$ we have $xy^kz \in L$

### Non-deterministic finite automaton

- like DFA, but following differences:
  - $\delta : Q \times (\Sigma \cup \{ \epsilon \}) \rightarrow \mathcal{P}(Q)$

#### Extended transition function

- $\delta^* : Q \times \Sigma^* \rightarrow \mathcal{P}(Q)$
  
- $\epsilon$-closure
  - define by what belongs to it (inductively)
  - $\epsilon(q) \subseteq Q$
    - $q \in \epsilon(q)$
    - $p \in \epsilon(q) \wedge r \in \delta(p,\epsilon) \implies r \in \epsilon(q)$

- extended transition function
  - $\delta^*(q,wx) = \epsilon(\bigcup_{p \in \delta^*(q,w)}\delta(p,x))$
  - $\delta^*(q,\epsilon)=\epsilon(q)$

### Grammars

#### Grammar in general

- $G=(V,T,P,S)$
  - $V$ ... variables
  - $T$ ... terminals
  - $P$ ... rewriting rules
  - $S$ ... initial variable

#### Regular grammar

- only rules of type $A \rightarrow \omega B$ where $A,B \in V$ and $\omega \in T^*$
- ❗also $A \rightarrow \omega$ (otherwise it could not terminate)

#### Context-free grammar

- only rules of type $A \rightarrow \omega$ where $A \in V$ and $\omega \in (V \cup T)^*$
  - ❗is weaker than context-sensitive because it cannot generate something cool by sensing the surroundings

#### Context-sensitive grammar

- only rules of type $\alpha A \beta \rightarrow \alpha \omega \beta$ s.t. $\alpha,\beta \in (V \cup T)^*$ and ❗$\omega \in (V \cup T)^+$
- ❗also allows for rule $S \rightarrow \lambda$

#### Recursively enumerable language

- rules of type $\alpha \rightarrow \beta$ where $\alpha,\beta \in (V \cup T)^*$
- ❗there exists $A \in V$ s.t. $A \in \alpha$ (left side of the rule must contain at least one variable)

## Past exams

### Spring 2025 (intersection of context-free and regular grammars)

### Spring 2024 (representation of context-free grammar)

### Autumn 2024 (complement of regular expression)

### Summer 2023 (conversion of context-free grammar to an automaton)

### Autumn 2023 (pushdown automaton)

### Summer 2022 - one (0 type grammar)