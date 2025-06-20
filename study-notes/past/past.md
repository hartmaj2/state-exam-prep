# Prob and stats state exam prep

## Topics

- [x] Pravděpodobnostní prostor, náhodné jevy, pravděpodobnost
  - [x] definice těchto pojmů, příklady
  - [x] základní pravidla pro počítání s pravděpodobností
  - [x] nezávislost náhodných jevů, podmíněná pravděpodobnost
  - [x] Bayesův vzorec
- [x] Náhodné veličiny a jejich rozdělení
  - [x] diskrétní i spojitý případ
  - [x] popis pomocí distribuční funkce a pomocí pravděpodobnostní funkce/hustoty
  - [x] střední hodnota
    - [x] linearita střední hodnoty
    - [x] střední hodnota součinu nezávislých veličin
    - [x] Markovova nerovnost
  - [x] rozptyl
    - [x] definice
    - [ ] vzorec pro rozptyl součtu (závislých či nezávislých veličin)
  - [x] práce s konkrétními rozděleními: geometrické, binomické, Poissonovo, normální, exponenciální
- [ ] Limitní věty
  - [ ] zákon velkých čísel
  - [ ] centrální limitní věta
- [ ] Bodové odhady
  - [ ] alespoň jedna metoda pro jejich tvorbu
  - [ ] vlastnosti
- [ ] Intervalové odhady: metoda založená na aproximaci normálním rozdělením
- [ ] Testování hypotéz
  - [ ] základní přístup
  - [ ] chyby 1. a 2. druhu
  - [ ] hladina významnosti

## Past exams

## Probability space

### Event space

- subset of power set of $\Omega$
  - must contain
    - empty set
    - $\Omega$
    - ❗for every event, the complementary event
    - ❗for every sequence of events, the union of the events

### Probability function

- function $P : \mathcal{F} \rightarrow [0,1]$
  - for **pairwise** disjunct ❗**sequence of** events, their probabilities add up
  - prob of empty set is 0
  - prob of $\Omega$ is 1

### Probability space

- triple $(\Omega,\mathcal{F},P)$
  - ❗$\Omega$ is any non-empty set
  - $\mathcal{F}$ is event space of $\Omega$
  - $P$ is probability function

### Examples of prob spaces

- finite with uniform probabilities
  - $P(A) = \frac{|A|}{|\Omega|}$

- discrete
  - $\Omega$ is a ❗**countable** set
    - then we can measure prob of every $\omega \in \Omega$

- continuous
  - $\Omega \subseteq \mathbb{R}^d$

### Random variable

- (discrete r.v.) function $X$ from $\Omega$ to $\mathbb{R}$
  - ❗$X[\Omega]$ is countable set
  - ❗for any $n \in X[\Omega]$ we have that the preimage of $n$ is an event

- (general r.v.) function $X$ from $\Omega$ to $\mathbb{R}$
  - for every $x \in \mathbb{R}$ we have that the set of all elementary events that map to something smaller than $x$ is an event from event space

- distribution function of $X$ (discrete r.v.)
  - $F_X : \mathbb{R} \rightarrow [0,1]$
  - for each $x \in \mathbb{R}$ tells you the probability of all events that map (using $X$) below

- (continuous r.v.) $X$ is a general r.v. s.t
  - there exists a non-negative real function $f_X : \mathbb{R} \rightarrow \mathbb{R}_0^+$
  - for cumulative function of $X$ we have : $F_X(x) = \int_{-\infty}^xf_X(t)dt$
  - $f_X$ is called probability density

### Markov inequality

- says that the probability that a random variable $X$ has value $x$ greater than $n$ times the expected value is smaller than $\frac{1}{n}$

### Variance

- variance of a r.v. $X$
  - $var(X)$
  - it is a particular number $k \in \mathbb{R}$
  - it is $\mathbb{E}[(X-\mathbb{E}[X])^2]$
    - it is the expected value of a helper variable $Y= (X - \mathbb{E}[X])^2$
    - $Y$ counts for any event, how far will be the value of $X$ from its mean $\mathbb{E}[X]$ when that particular event happens

- variance of sum of r.v's $X$ and $Y$

### Summer 2023 (probability)

