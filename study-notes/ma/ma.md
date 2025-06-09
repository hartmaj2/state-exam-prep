# Preparation for state exam mathematical analysis topic

## Topics

– [ ] Posloupnosti reálných čísel a jejich limity
    – definice, aritmetika limit
    – věta o dvou policajtech, limity a uspořádání
– [ ] Řady
    – definice částečného součtu a součtu
    – geometrická řada, harmonická řada
– [ ] Reálné funkce jedné reálné proměnné
    – limita funkce v bodě
        – definice, aritmetika limit
        – vztah s uspořádáním
        – limita složené funkce
    – funkce spojité na intervalu
        – nabývání mezihodnot
        – nabývání maxima
– [ ] Derivace a její aplikace
    – definice a základní pravidla pro výpočet
    – l’Hospitalovo pravidlo
    – vyšetření průběhu funkcí: extrémy, monotonie a konvexita/konkavita
– [ ] Taylorův polynom (limitní forma)
– [ ] Integrály a jejich aplikace
    – primitivní funkce: definice a metody výpočtu (substituce, per-partes)
– [ ] Riemannův integrál: definice, souvislost s primitivní funkcí (Newtonovým integrálem)
    – aplikace
        – odhady součtu řad (konečných i nekonečných)
        – obsahy rovinných útvarů
        – objemy a povrchy rotačních útvarů v prostoru
        – délka křivky

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