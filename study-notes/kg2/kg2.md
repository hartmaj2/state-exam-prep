# Preparation for the state exam combinatorics topic

## TODOs

- [ ] how to find closed formula when we know generating function

## Topics

- [ ] Vytvořující funkce
  - [ ] použití vytvořujících funkcí k řešení lineárních rekurencí
  - [ ] zobecněná binomická věta (formulace)
  - [ ] Catalanova čísla (příklad kombinatorické interpretace, odvození vzorce v uzavřeněm tvaru)
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

