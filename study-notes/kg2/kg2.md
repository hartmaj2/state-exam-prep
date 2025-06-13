# Preparation for the state exam combinatorics topic

## TODOs

- [ ] how to find closed formula when we know generating function

## Topics

- [x] Vytvořující funkce
  - [x] použití vytvořujících funkcí k řešení lineárních rekurencí
  - [x] zobecněná binomická věta (formulace)
  - [x] Catalanova čísla (příklad kombinatorické interpretace, odvození vzorce v uzavřeněm tvaru)
- [ ] Odhady faktoriálu a kombinačních čísel
  - [ ] formulace základních odhadů
    - [ ] $(n/e)^n \leq n! \leq en (n/e)^n$
    - [ ] $(n/k)^n \leq \binom{n}{k} \leq (en/k)^k$
    - [ ] $2^{2m}/(2 \sqrt{m}) \leq \binom{2m}{m} \leq 2^{2m}/\sqrt{2m}$
- [ ] Ramseyovy věty
  - [ ] Ramseyova věta (formulace konečné a nekonečné verze pro p-tice, důkaz verze p=2 pro 2 barvy)
  - [ ] Ramseyova čísla (definice, pro 2 barvy horní odhad z důkazu Ramseyovy věty a dolní odhad pravděpodob-
  nostní konstrukcí)
- [ ] Extremální kombinatorika
  - [ ] obecné povědomí co extremální kombinatorika studuje
  - [ ] Turánova věta (formulace, Turánovy grafy)
  - [ ] Erdös-Ko-Radoova věta (formulace)
- [ ] Samoopravné kódy
  - [ ] přehled o používané terminologii
  - [ ] vzdálenost kódu a její vztah k počtu opravitelných a detekovatelných chyb
  - [ ] Hammingův odhad (formulace a důkaz)
  - [ ] perfektní kódy (definice a příklady, Hammingův kód bez přesné konstrukce)

## Generating functions

### Brainstorm

- $f(x) = x^0 + x^1 + x^2 + \ldots = \frac{1}{1-x}$ is a generating function of sequence $(a_n) = (1,1,\ldots)$

- once we know the generating function, we can use a cookbook procedure to find an explicit formula for $n$-th element of the sequence

### Definitions

- generating function $f$ of a sequence $(a_n) = (a_0,a_1,\ldots)$
  - $f(x) = a_0 x^0 + a_1 x^1 + \ldots$

### Finding generating function from recursive formula (cookbook)

- write down all the recursive terms
- rewrite the recursive equation as a sum over all ❗non-recursive (base case) terms
- simplify to find out what the generating function is
  - left side of equation should be $f$ with subtracted base terms
  - right side has to be simplified

### Find explicit formula using the generating function

- test on simple case

### Generalised binomial theorem

#### Normal binomial theorem

$(a+b)^n = \sum_{k=0}^{n}\binom{n}{k}a^kb^{n-k}$

#### Generalized binomial theorem

- how does it generalize the previous one?
  - sum goes to infinity?
- the $n$ exponent can be $n \in \mathbb{R}$

- then we need a **generalized binomial coefficient**

- $(1+x)^r = \sum_{k=0}^{\infty}\binom{r}{k}x^k$
  - so it is generalized only in some way
  - ❗inside parentheses is $1+x$
  - ❗we must have $|x| < 1$

#### Generalized binomial coefficient

- $\binom{r}{k} = \frac{r \cdot (r-1) \cdot \ldots \cdot (r-k+1)}{k!}$ where $r \in \mathbb{R}$
  - ❗beware that $k \in \mathbb{N}_0$


### Catalan numbers

- count of rooted ordered binary trees
- first find recursive formula
  - just draw a picture to get:
    - $C_n = \sum_{i=0}^{n-1}C_{n-1-i}C_i$
- then we can use that to find generating function
  - follow cookbook steps
  - ❗realize that on the right side we get a function whose coefficients are a convolution of the coefficient of the generating function we are looking for
    - $f(x) - C_0 = x \cdot f(x) \cdot f(x)$
  - this leads to quadratic formula
    - ❗to find which root is the correct one, we know that the generating function should technically give us $a_0$ for $x = 0$
      - so look what is the limit as $x \rightarrow 0$
  - result:
    - $f(x) = \frac{1-\sqrt{1-4x}}{2x}$
- then use the generating function to find the explicit formula




## Past exams

### Spring 2025 (catalan numbers and generating sequences)

#### (1)

- these are the catalan numbers
  - $C_n = \frac{1}{n+1} \cdot \binom{2n}{n}$

- $D_n = | \{ (a_i)_{i=1}^n \subset \mathbb{N} \ ; \ a_1=1 \wedge a_{i+1} \leq a_i + 1\} |$
  - number of sequences of natural numbers s.t. they are not allowed to increase by more than 1 between two elements

- ❗use the fact that they ask for definition of **parentheses** version of Catalan
  - try to map the sequences to parentheses
  - each valid sequence corresponds to a valid parenthesizing

- $a_i$ describes how many parentheses were already open (including this one) when we opened the $i$-th parenthesis

#### (2)

- $\mathcal{A} = \{ \alpha^n ; \alpha \in \{ a,b \} \}$
- $\mathcal{C} = \{ \alpha^n ; \alpha \in \{ c,d \} \}$
- $\mathcal{S} = \{ s ; s = a' \cdot c \cdot a'' \}$

- ❗if not mentioned all sequences, it can be just a subset


### Spring 2024 (generating functions and bounds)

#### (1)

$$\frac{1}{n+1} \cdot \binom{2n}{n}$$

#### (2)

- ❗if we have generating function which looks like $\frac{a_1x + b_1}{(a_2x+b_2)(a_3x+b_3)}$ we use the decomposition into sum of fractions using $\frac{A}{a_2x+b_2} + \frac{B}{a_3x+b_3}$

### Autumn 2023 (graphs without triangles)

#### (1)

- use the fact that maximal graph without triangle is a complete bipartite graph


- argument why it should be bipartite?
  - what if there is more partite graph that is not complete but still has more edges than the complete bipartite with partition size $\frac{n}{2}$

#### (2)

- graph without triangle has independent set of size at least $\sqrt{n}$
  


