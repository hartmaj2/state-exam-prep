# Prep for automata and grammars

## Topics

- [ ] Regulární jazyky
  - [ ] regulární gramatiky
  - [ ] deterministický a nedeterministický konečný automat
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

### Regular language

- $L \subseteq \Sigma^*$ s.t. exists deterministic finite automaton $A$ with $L(A) = L$

### Pumping lemma

- for every regular language $L$ exists a constant $n \in \mathbb{N}$ (higher than number of states of the automaton $A$ for the regular language) s.t. for every word $w \in L$ s.t. $|w| \geq n$ then we can split $w = xyz$ s.t.
  - $y$ is nonempty
  - $|xy| \leq n$
  - for each $k \in \mathbb{N}_0$ we have $xy^kz \in L$

## Past exams