# Preparation for state exam mathematical analysis topic

## TODOs

- [x] Riemann integral definition
- [x] Limit relation to orderings
- [x] Limit arithmetics
- [x] Limit of composite functions
- [x] Taylor polynomial (limit form)
- [ ] computation of integrals using substitution
- [ ] curve length using Riemann integral
- [ ] Riemann integral and Newton integral relationship

## Topics

- [x] Posloupnosti reálných čísel a jejich limity
    - definice, aritmetika limit
    - věta o dvou policajtech, limity a uspořádání
- [x] Řady
    - definice částečného součtu a součtu
    - geometrická řada, harmonická řada
- [x] Reálné funkce jedné reálné proměnné
    - limita funkce v bodě
        - definice, aritmetika limit
        - vztah s uspořádáním
        - limita složené funkce
    - funkce spojité na intervalu
        - nabývání mezihodnot
        - nabývání maxima
- [x] Derivace a její aplikace
    - definice a základní pravidla pro výpočet
    - l’Hospitalovo pravidlo
    - vyšetření průběhu funkcí: extrémy, monotonie a konvexita/konkavita
- [x] Taylorův polynom (limitní forma)
- [x] Integrály a jejich aplikace
    - primitivní funkce: definice a metody výpočtu (substituce, per-partes)
- [ ] Riemannův integrál: definice, souvislost s primitivní funkcí (Newtonovým integrálem)
    - aplikace
        - odhady součtu řad (konečných i nekonečných)
        - obsahy rovinných útvarů
        - objemy a povrchy rotačních útvarů v prostoru
        - délka křivky

## Sequences and their limits

- sequence definition
  - sequence is a mapping $\mathbb{N} \rightarrow \mathbb{R}$

- sequence has limit at $k$ 
  - for every $\epsilon$ exists natural number $n$ s.t. any element of the sequence after $n$ is closer to $k$ than $\epsilon$

- two policemen theorem
  - suppose we have sequences $(a_n),(b_n),(c_n)$ s.t. for every natural number $n \geq m$, $a_n \leq b_n \leq c_n$ (where $m$ is some fixed natural number)
  - then if $\lim_{n \rightarrow \infty}a_n = \lim_{n \rightarrow \infty}c_n = k$ then we have $\lim_{n \rightarrow \infty}b_n = k$

## Real functions in single variable

### Limit of a function

- function $f$ has limit $K$ in point $a$ iff
  - $\forall \epsilon \ \exists \delta$ s.t. $x \in P(a,\delta) \rightarrow U(K,\epsilon)$ where $\epsilon,\delta > 0$
  - ❗ exact usage of $P$ vs $U$ neighborhoods is important

### Relation to ordering <

- relation of limit with ordering (1)
  - let us have functions $f$, $g$ s.t. $\lim_{x \rightarrow a}f(x) = K$ and $\lim_{x \rightarrow a}g(x) = L$ and $K < L$
  - then there exists $\delta > 0$ s.t. $\forall x \in P(a,\delta)$ we have $f(x) < g(x)$ 

- relation of limit with ordering (2)
  - let us have functions $f$, $g$ s.t. they have limit at point $a$
  - if there exists $\delta > 0$ s.t. $\forall x \in P(\delta,a)$ we have $f(x) \leq g(x)$ then $\lim_{x \rightarrow a}f(x) \leq \lim_{x \rightarrow a}g(x)$

- relation of limit with ordering (3)
  - let us have functions $f$, $g$, $h$ s.t. $\lim_{x \rightarrow a}f(x) = \lim_{x \rightarrow a}g(x) = A$
  - if there exists $\delta > 0$ s.t. $\forall x \in P(\delta,a)$ we have $f(x) \leq h(x) \leq g(x)$, then $\lim_{x \rightarrow a}h(x) = A$

  - note that we have $A \in \mathbb{R}^*$ so it is possible that $A = \infty$ or $A = - \infty$

### Arithmetic of limits

- let $f$,$g$ be functions in real variable
- let $\lim_{x \rightarrow a}f(x) = K$ and $\lim_{x \rightarrow b}g(x) = L$

- sum of limits
  - ❗ can't do : sum opposite infinities

- sum of products
  - ❗can't multiply infinity by zero
  - ❗can't divide infinities by each other
  - divide by zero (quite obvious)

### Limit of composite functions

- let $f$, $g$ be functions in real variable s.t. $\lim_{x \rightarrow a}f(x) = K$ and $\lim_{x \rightarrow K}g(x) = L$
  - ❗one of following conditions must be fulfilled
    - (1) exists $\delta$ s.t. $f(x) \neq K$ for all $x \in P(a,\delta)$
      - because $g$ can be undefined at point $K$ even if the limit exists
    - (2) $g$ is continuous at $K$, this means that $g(K) = L$
  - then $\lim_{x \rightarrow a}g(f(x)) = L$

## Series

- series
  - expression in form $a_0 + a_1 + \ldots$ denoted by $\sum_{n=0}^{\infty}a_n$ where $(a_n)_{n=0}^\infty$ is a sequence

- partial sum
  - given an infinite sum for $(a_n)_{n\geq0}$ the partial sum for a given $m$ denoted by $S_m$ is $a_0 + \cdots + a_m$

## Taylor polynomial

- it is a polynomial (wow!)
- used to approximate a function around some point on the domain

- parameters:
  - $f$ the function for which we evaluate the polynomial
  - $a$ the point at which we approximate it
  - $n$ amount of degrees to which we write out the polynomial

- how is it constructed?
  - we want the polynomial to have same derivatives up to $n$
  - so for $i \in [n]$ we want:
    - $(T_{f,a}^{n})^{(i)}(a) = f(a)^{(i)}$

- special case for $0$
  - $T(x) = f(0) + x \cdot f'(0) + \frac{x^2 \cdot f''(0)}{2!} + \ldots$
  - main idea:
    - lower terms disappear when differentiated $i$ times
    - according to the power rule, we get a constant $k = i!$ in front of our coefficient

- $T_{n}^{f,a}=f(a) + \frac{(x-a) \cdot f'(a)}{1!}+ \frac{(x-a)^2 \cdot f''(a)}{2!} + \ldots$

## Computing integrals

### General hints

- rewrite roots in terms of powers

### Substitution rule

- when do we use it?
  - when we notice that the function $h$ we need to integrate can be rewritten as some $f$ and $g$ s.t. $h(x) = f(g(x)) \cdot g'(x) \cdot k$ where $k$ is some constant
    - ❗ note the $k$

## Riemann integral

- done by approximating the area from below and above by taking supremum/infimum of lower/upper bounds on this area

- partition of interval $[a,b]$
  - is a sequence $D=(a_0,a_1,\ldots,a_k)$ s.t. $a=a_0<a_1<\ldots<a_k=b$
  - interval on the partition: $I_i = [a_i,a_i+1]$

- define lower and upper sums
  - length of interval $|I_i| = a_{i+1} - a_i$
  - lower sum: $s(f,D)=\sum_{i=0}^{k-1}|I_i|\cdot m_i$ where $m_i = \inf\{f(x), x \in I_i\}$
  - upper sum: $S(f,D)=\sum_{i=0}^{k-1}|I_i|\cdot M_i$ where $M_i = \sup\{f(x), x \in I_i\}$

- then we define $\overline{\int_a^b}f=\sup\{S(f,D) , D \text{ is partition of } [a,b]\}$
- similarly $\underline{\int_a^b}f$
- if $\overline{\int_a^b}f = \underline{\int_a^b}f = r \in \mathbb{R}$
  - then we have Riemann integral $\int_a^bf(x) dx = r$

## Past Exams

### Spring 2024 (discontinuity of a function)

#### (1)
- $(\exists \epsilon > 0)(\forall \delta > 0)(\exists x \in (0,1))(|x-\frac{1}{2}| < \delta \wedge | f(x) - f(\frac{1}{2}) | \geq \epsilon)$

#### (2)

- chceme najit limitu $f(x) = \frac{2x - 1}{1 - 2x} = - \frac{2x-1}{2x-1}$
  - vidime ze $\lim(f)_{x \rightarrow \frac{1}{2}} = -1$ a tedy dodefinovana funkce je spojita

#### (3)

- v bode $x = \frac{1}{2}$ neni definovana a tedy neni nespojita (jelikoz se o tom bodu asi vubec nemuzeme bavit hmm?)

### Autumn 2024 (integrals and primitive functions)

#### (1)

- definice primitivni funkce pro funkci $f$ na otevrenem intervalu $I$
  - je to libovolna funkce $F$ t.z. $(\forall x \in I)(F'(x) = f(x))$
  - tedy existuje nekonecne mnoho ruznych primitivnich funkci k $f$

#### (2)

- pravidlo per partes
  - mejme funkce $f$,$g$ spojite na celem jejich definicnim oboru
  - pak plati:
    - $f \cdot g = \int f \cdot g' + \int f' \cdot g$

#### (3)

- plosny obsah spocitame jako integral:
  - $\int x \cdot \cos(x) = \sin(x) \cdot x - \int \sin(x) =  \sin(x) \cdot x + \cos(x)$ 
  - my chceme oblast pod krivkou na intervalu $x \in (0,\frac{\pi}{2})$
  - vysledkem bude $\frac{\pi}{2} - 1$

### Autumn 2023 (geometric sequence)

#### (1)

- geometricka rada $\sum_{n=0}^{\infty}a_n$ je geometricka prave kdyz existuje cislo $q$ t.z. $(\forall n \in \mathbb{N_0})(a_n = a_0 \cdot q^n)$

#### (2)

- what is the sum of geometric series 
    1. for $n \in \mathbb{N}$ we have $\sum_{i=0}^{n}a_n = a_0 \cdot \frac{q^{n+1} - 1}{q - 1}$
    2. for infinite series we have $\sum_{i=0}^{\infty} = \frac{a_0}{1-q}$ but only if $q \in (0,1)$
    3. for infinite with $q \geq 1$ the sum is $+\infty$ or $-\infty$ if $a_0 \neq 0$ 
    4. for infinite with $q \leq -1$ the sum is undefined

#### (3)

- $\frac{4}{9} + \frac{8}{27} + \frac{16}{81} + \cdots = 3 - 1 - \frac{2}{3} = \frac{4}{3}$

### Summer 2022 - one (integral)

#### (1)

- $I$ je otevreny interval (s kazdym $x \in I$ existuje $\delta > 0$ t.z. $\{y , | x - y | < \delta \} \subseteq I$)

1. mame-li funkce $F_1$, $F_2$ primitivni k $f$, tak plati, ze $(\forall x \in I)( F_1'(x) = f(x) = F_2'(x))$

- chceme ukazat, ze potom $(\exists c \in \mathbb{R})(\forall x \in I)(F_1(x) = F_2(x) + c)$
  - podminka (vztah) nahore je urcite postacujici k tomu, aby obe dve byly primitivni k te stejne funkci $f$
  - je to ale nutna podminka?
    - neplati-li vztah nahore, pak zvolme libovolne $c$

#### (2)

- to je per partes : $\int f \cdot G = F \cdot G - \int F \cdot g$

#### (3)

- pouziju vzorec tak, ze $x$ se zderivuje a $\sin(x)$ se zintegruje, coz mi nezkomplikuje vysledek

### Autumn 2022 - (sequences)

#### (1)

- (K) poslooupnost je konvergentni: $\lim(a_n)_{n \rightarrow \infty} = k \equiv (\forall \epsilon > 0)(\exists n_0 \in \mathbb{N})(\forall n > n_0)(|a_n - k| < \epsilon)$

#### (2)

- (N) posloupnost $(a_n) = (a_0,a_1,\ldots)$ je neomezena ... $(\forall k)(\exists n)(\exists m)(|a_n - a_m | > k)$

- oficialne: $(\forall k)(\exists n \in \mathbb{N})(|a_n| > k)$

#### (3)

- dokazat $(N) \rightarrow \neg (K)$
  - uplne mi neni jasne, jak napasovat (N) na tvrzeni $(\forall k \in R)(\exists \epsilon > 0)(\forall n \in \mathbb{N})(\exists m > n)(|a_m - k| > \epsilon)$
  - napada me ale pouzit fakt, ze pokud je $(a_n)_{n=0}^\infty$ unbounded, tak pro kazde $m \in \mathbb{N}$ mame $(a_n)_{n=m}^\infty$ unbounded