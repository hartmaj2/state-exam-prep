# Preparation for the state exam combinatorics topic

## TODOs

- [ ] how to find closed formula when we know generating function

## Topics

- [x] Vytvořující funkce
  - [x] použití vytvořujících funkcí k řešení lineárních rekurencí
  - [x] zobecněná binomická věta (formulace)
  - [x] Catalanova čísla (příklad kombinatorické interpretace, odvození vzorce v uzavřeněm tvaru)
- [x] Odhady faktoriálu a kombinačních čísel
  - [x] formulace základních odhadů
    - [x] $(n/e)^n \leq n! \leq en (n/e)^n$
    - [x] $(n/k)^k \leq \binom{n}{k} \leq (en/k)^k$
    - [x] $2^{2m}/(2 \sqrt{m}) \leq \binom{2m}{m} \leq 2^{2m}/\sqrt{2m}$
- [x] Ramseyovy věty
  - [x] Ramseyova věta (formulace konečné a nekonečné verze pro p-tice, důkaz verze p=2 pro 2 barvy)
  - [x] Ramseyova čísla (definice, pro 2 barvy horní odhad z důkazu Ramseyovy věty a dolní odhad pravděpodob-
  nostní konstrukcí)
- [ ] Extremální kombinatorika
  - [ ] obecné povědomí co extremální kombinatorika studuje
  - [ ] Turánova věta (formulace, Turánovy grafy)
  - [ ] Erdös-Ko-Radoova věta (formulace)
- [x] Samoopravné kódy
  - [x] přehled o používané terminologii
  - [x] vzdálenost kódu a její vztah k počtu opravitelných a detekovatelných chyb
  - [x] Hammingův odhad (formulace a důkaz)
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


## Combinatorial bounds

- $(\frac{n}{e})^n \leq n! \leq en (\frac{n}{e})^n$

- $(\frac{n}{k})^k \leq \binom{n}{k} \leq (\frac{en}{k})^k$ 

- $\frac{2^{2n}}{2\sqrt{n}}\leq \binom{2n}{n}\leq\frac{2^{2n}}{\sqrt{2n}}$

## Ramsey theorems

### 2 colors and 2-tuples version

- for every choice of number $k$, there exists a number $n$ s.t. for each $2$-coloring (of edges) $c$ of graph $K_n$ there exists a single color clique of size $k$

- subset $S \in V$ is a single color clique in hypergraph with edges of arity $p$ 
  - if there exists color $k$ s.t. for every $s \in \binom{S}{p}$ we have $c(s) = k$

### 2 colors and p-tuples version

- let $H = (V,F)$ be $p$-hypergraph
  - $V$ set of vertices
  - $F$ is a subset of $\binom{V}{p}$

- for every choice of number $k$ and $p$, there exists a number $n$ s.t. for every $2$-coloring of $K_{n}^p$ there exists a subset of size $k$ s.t. it has only edges of single color between the vertices in the subset

### Infinite version

- for every $k$ there exists a monochromatic infinite complete graph inside of any coloring of an infinite complete graph

### Proof of 2 colors and 2-tuples version

- precise formulation
  - $\forall k, \exists n, \forall c : \binom{[n]}{2} \rightarrow \{1,2\}, \exists i \in \{1,2\},\exists S \in \binom{[n]}{k}, \forall e \in \binom{S}{2} : c(e) = i$
    - ❗$S \in \binom{[n]}{k}$ not $S \in \binom{k}{2}$
      - $S$ is not an edge bro!
    - ❗$e \in \binom{S}{2}$ not $e \in S$
      - edges are colored not $k$-tuples

- proof is done by induction
  - induction is on $s = k + l$
  - base case $R(k,1) = R(1,l) = 1$
  - inductive case:
    - we get $R(k,l)$
    - ❗from I.H. we know $R(k-1,l)=A$ and also $R(k,l-1)=B$
    - take $N=A+B$ and prove $N \geq R(k,l)$ and graph $G$ on $N$ vertices
    - ❗take any $x \in V$ and analyse $S=N(x)$ and $T = V \setminus S \setminus \{x\}$ (neighbors and non-neighbors)
    - show that $|S| + |T| \geq A + B - 1$ implies that:
      - $|S| \geq A$ or $|T| \geq B$
      - the rest you can figure out

## Error correcting codes

- we have function $Enc : \{0,1\}^m \rightarrow C$ that maps messages to codewords

- we define $d$ as the distance of code $C$
  - $d := \min \{ d(x,y) \ | \ x \neq y , x \in C , y \in C \}$

- we want to choose the mapping so that when $c=Enc(x)$ is sent and is bit-flipped to $y$ using less than $t=\frac{d-1}{2}$ bitflips, then there exists a unique $c'$ s.t. $d_H(c',y) \leq t$ 
  - that is because causing $d/2$ bitflips could make us closer to a different codeword

- Hamming code
  - has control matrix $H_r$ for some $r \in \{2,3,\ldots\}$
    - $H_r \in \{0,1\}^{r \times 2^r-1}$
  - control matrix $K$
    - for code $C$, $K$ is the basis of $C^\perp$ (the orthogonal complement of $C$)
    - we have $Kx = 0$ iff $x \in C$

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

### Summer 2024 (binary self correcting codes)

#### (1) defining stuff

- Hamming distance
  - for two strings $a,b \in \{0,1\}^k$ where $k \in \mathbb{N}$
  - maybe sum of $a \oplus b$
    - $d(x,y) :=$ # of $i$'s s.t. $x_i \neq y_i$

- self-correcting code
  - encoding of information so that when we send it, we are certain that a bit flip happened and know where as long as at most $n$ bit-flips happened 
  - ❗the naming is shitty, it does not have to be self-correcting
  - definition
    - any set $C \subseteq \{0,1\}^n$ for any naturan number $n$
    - $n$ is the length of the code
    - $|C|$ is the size of the code

- distance of code $C$
  - $$\min_{x,y \in C, x \neq y}d(x,y)$$
  - the minimum over all pairs of **words** in the code

#### (2)

- we have code $C$ with size $k \geq 2$ and length $n$
- let $x \in \{0,1\}^m$ for natural number $m$ ($x$ is a word of length $m$)


- how to use $C$ to encode $x$ so that the result $y$ is smallest possible?

- what will be length of $y$ with respect to $k,n,m$?

- ❗we map shorter messages to longer codewords so $m \leq n$

- solution
  - ❗it has nothing to do with error correction, it is just about encoding information

#### (3)

- let $C$ be $(5,6,3)$-code
  - codewords have length $n=5$
  - $|C| = 6$
  - $d= \min\{ d(x,y) \ | \ x \neq y \in C\} = 3$

- can such code exist?

- use Hamming bound
  - uses the fact that if we have distance $d$ then the balls of size $\lfloor\frac{d-1}{2}\rfloor$

### Autumn 2024 

#### (1)

- let $K_{\infty}$ be an infinite complete graph
- for any $k,b$ and $c : E(K_\infty) \rightarrow [b]$ there exists $i \in [b]$ and ❗**infinite** $S \subseteq V(K_\infty)$ s.t. $\forall e \in \binom{S}{2} : c(e) = i$
  - ❗the subset $S$ has to be infinite not of fixed size

#### (2) fun with infinite bipartite graphs

- ❗think about also disproving stuff

- TODO: try to disprove it

### Autumn 2023 (graphs without triangles)

#### (1)

- use the fact that maximal graph without triangle is a complete bipartite graph


- argument why it should be bipartite?
  - what if there is more partite graph that is not complete but still has more edges than the complete bipartite with partition size $\frac{n}{2}$

#### (2)

- graph without triangle has independent set of size at least $\sqrt{n}$
  


