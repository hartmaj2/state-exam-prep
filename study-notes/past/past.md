# Prob and stats state exam prep

## Topics

- [ ] Pravděpodobnostní prostor, náhodné jevy, pravděpodobnost
  - [ ] definice těchto pojmů, příklady
  - [ ] základní pravidla pro počítání s pravděpodobností
  - [ ] nezávislost náhodných jevů, podmíněná pravděpodobnost
  - [ ] Bayesův vzorec
- [ ] Náhodné veličiny a jejich rozdělení
  - [ ] diskrétní i spojitý případ
  - [ ] popis pomocí distribuční funkce a pomocí pravděpodobnostní funkce/hustoty
  - [ ] střední hodnota
    - [ ] linearita střední hodnoty
    - [ ] střední hodnota součinu nezávislých veličin
    - [ ] Markovova nerovnost
  - [ ] rozptyl
    - [ ] definice
    - [ ] vzorec pro rozptyl součtu (závislých či nezávislých veličin)
  - [ ] práce s konkrétními rozděleními: geometrické, binomické, Poissonovo, normální, exponenciální
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
  - its cumulative function $F_X(x) = \int_{-\infty}^xf_X(t)dt$
  - $f_X$ is called probability density

### Summer 2023 (probability)

