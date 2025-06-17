# Prep for automata and grammars

## Topics

- [x] Regulární jazyky
  - [x] regulární gramatiky
  - [x] deterministický a nedeterministický konečný automat
  - [ ] regulární výrazy
- [x] Bezkontextové jazyky
  - [x] bezkontextové gramatiky, jazyk generovaný gramatikou
  - [x] zásobníkový automat, třída jazyků přijímaných zásobníkovými automaty
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

### Push-down automaton

- $P = (Q,\Sigma,\Gamma,\delta,q_0,Z_0,F)$ ❗$Z_0$
  - $Q$ ... states
  - $\Sigma$ ... symbols
  - $\Gamma$ ... stack symbols
  - $\delta : Q \times \Sigma \times \Gamma \rightarrow \mathcal{P}_{FIN}(Q \times \Gamma^*)$ 
    - s.t. $(p,\alpha) \in \delta(q,x,Z)$ if from state $q$ with symbol $Z$ on top of stack, we can go to state $p$ when we read $x$ from the input and then we place $\alpha$ on the stack instead of $Z$

- configuration $c \in Q \times \Sigma^* \times \Gamma^*$ (also called ID)
  - $c = (p,\omega,\alpha)$ if
    - $p$ ... state where we are at
    - $\omega$ ... part of word that we still have to read
    - $\alpha$ ... sequence of stack symbols that we have on the stack

- if $(q,\gamma)\in \delta(p,x,Z)$ and $\alpha \in \Sigma^*$ (word) and $\beta \in \Gamma^*$
  - where $x \in \Sigma \cup \{\epsilon\}$, $Z \in \Gamma$, $p,q \in Q$
  - we have $(p,x\alpha,Z\beta) \vdash (q,\alpha,\gamma\beta)$

- defining $\vdash^*$ inductively
  - let $I,J$ configurations, then:
    - $I \vdash^* I$
    - $I \vdash^* J$ iff exists configuration $K$ s.t. $I \vdash K$ and $K \vdash^* J$

- $P$ accepts word $\alpha$ if 
  - $(q_0,\alpha,Z_0) \vdash^* (q,\epsilon,\gamma)$ and $q \in F$
  - or $(q_0,\alpha,Z_0) \vdash^* (q,\epsilon,\epsilon)$ 
    - ❗we need to get rid of $Z_0$ as well

### From grammar to PDA

- let $G=(V,T,P,S)$ be grammar
- we construct PDA $P=(\{q\},T,V \cup T,\delta,q,S)$
- the transition function will be as follows
  - for every $a \in T$ we have $\{(q,\epsilon)\} = \delta(q,a,a)$
  - for every $A \in V$ we have $\{ (q,\gamma) \ | \ A \rightarrow \gamma \in P \} = \delta(q,\epsilon,A)$
  - ❗the results of the transition function are sets (not just single elements)

### Intersection of PDA and FA

- we have FA $A=(Q_1,\Sigma,\delta_1,q_1,F_1)$ and PDA $P=(Q_2,\Sigma,\delta_2,\Gamma,Z_0,q_2,F_2)$
- we construct automaton $M = (Q_1 \times Q_2,\Sigma,\Gamma,\delta,Z_0,(q_1,q_2),F_1 \times F_2)$

- we have $((r,s),\gamma) \in \delta((p,q),x,Z)$ iff
  - $x=\epsilon$
    - $r=s \wedge (s,\gamma) \in \delta_1(q,\epsilon,Z)$
  - $x \neq \epsilon$
    - $r = \delta_2(p,x) \wedge (s,\gamma) \in \delta_1(q,x,Z)$

### Language L generated by grammar G

- $\alpha$ directly rewrites to $\beta$
  - we say $a \Rightarrow b$ iff
    - exist $\nu,\gamma \in (V \cup T)^*$ s.t. $a = \nu \alpha \gamma$ and $b = \nu \beta \gamma$ and $\alpha \rightarrow \beta$ is a rule of $G$

- $\alpha \Rightarrow^* \beta$
  - if exists a chain of words in between to which I can be rewritten and then to $\beta$

- we say $L$ is generated by $G$ if
  - for $\omega \in T^*$
  - $\omega \in L(G)$ iff $S \Rightarrow^* \omega$

## Recursively enumerable languages

### Type 0 grammars

- type 0 grammar
  - only rules of type $\alpha \rightarrow \beta$ where $\alpha$ must contain a variable
  - ❗specify that $\alpha, \beta \in (V \cup T)^*$

### Turing machine

- has tape on which it can write

- $M=(Q,\Sigma,\Gamma,\delta,q_0,B,F)$
- ❗tape head can only move $L$ or $R$

- $\delta : Q \times \Gamma \rightarrow Q \times \Gamma \times \{L,R\}$
  - ❗is deterministic again
  - $\delta(q,X) = (p,Y,D)$
  - $D \in \{L,R\}$
  - $q$ ... starting state
  - $X$ ... symbol that is under the head
  - $p$ ... state to which the head moves to
  - $Y$ ... symbol we write under the head
  - $D$ ... direction into which we move after reading symbol $X$

- configuration
  - $X_1,\ldots,X_{i-1}qX_i\ldots,X_n$
    - head is in state $q$ 
    - head is above symbol $X_i$

- step of Turing machine from config. to config.
  - $\mathcal{I} \vdash \mathcal{J}$
  - defined by writing what the related configurations can look like if we have $\delta(q,X) = (p,Y,D)$
  - $\vdash^*$ is defined analogously as for PDA

- Turing Machine $M$ stops when
  - $M$ achieved accepting state or
  - $M$ has no valid transition from current state

- Turing machine $M$ decides a language $L$ iff
  - for each $w \in L$ turing machine halts on $w$
  - then we write $L = L(M)$

### Decidable problem

- problem $P$
  - mathematically formulated problem
  - a question with an answer $\{0,1\}$
  - using alphabet $\Sigma$

- problem $P$ is **algorithmically** decidable if
  - for every input $w \in P$
  - exists a TM $M$ s.t. $M$ halts on $w$ and accepts iff $P(w) = 1$

- if problem is not decidable it is undecidable

## Chomsky hierarchy

- sequence of grammars by strength
  - type $0$
    - recursively enumerable
    - Turing machine
  - type $1$
    - context-sensitive
    - Linearly Bounded Automata
    - examples:
      - $0^n1^n2^n$
  - type $2$
    - context-free lanugage
    - Push-Down Automaton
    - examples:
      - $0^n1^n$
      - parentheses
      - more $0$'s than $1$'s
      - even palidromes
  - type $3$
    - regular language
    - Deterministic Finite Automaton
    - examples:
      - ending by set sequence of letters (KMP)
      - amount of chars divisible by something

## Past exams

### Spring 2025 (intersection of context-free and regular grammars)

#### (2)

- let $\Sigma = \{0,1\}$

- we construct PDA $P$ accepting $L_1$
- it is $P=(\{q\},\Sigma,\{0,1,S\},\delta,q,S)$
  - the transition funciton $\delta$ is
    - $\delta(q,\epsilon,S) = \{(q,\epsilon),(q,SS),(q,0S1)\}$
    - $\delta(q,0,0)= \{(q,\epsilon)\}$
    - $\delta(q,1,1)= \{(q,\epsilon)\}$

- then we construct PDA $M=(Q_1 \times Q_2,\Sigma,\{0,1,S\},\delta_m,(q_0,q),S)$
  - the transition function $\delta_m$ is
    - if we have $\delta_1(p,a)=r \wedge (q,\epsilon) \in \delta(q,a,a)$ then
      - $((r,q),\epsilon) \in \delta_m((p,q),a,a)$
    - for every $(q,\gamma) \in \delta(q,\epsilon,S)$ we have
      - $((r,q),\gamma) \in\delta((r,q),\epsilon,S)$

### Spring 2024 (representation of context-free grammar)

### Autumn 2024 (complement of regular expression)

### Summer 2023 (conversion of context-free grammar to an automaton)

### Autumn 2023 (pushdown automaton)

### Summer 2022 - one (0 type grammar)