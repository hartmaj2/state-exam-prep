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
    - [x] vzorec pro rozptyl součtu (závislých či nezávislých veličin)
  - [x] práce s konkrétními rozděleními: geometrické, binomické, Poissonovo, normální, exponenciální
- [x] Limitní věty
  - [x] zákon velkých čísel
  - [x] centrální limitní věta
- [x] Bodové odhady
  - [x] alespoň jedna metoda pro jejich tvorbu
  - [x] vlastnosti
- [x] Intervalové odhady: metoda založená na aproximaci normálním rozdělením
- [x] Testování hypotéz
  - [x] základní přístup
  - [x] chyby 1. a 2. druhu
  - [x] hladina významnosti

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
  - rewrites to $var(X) + var(Y) + 2 (\mathbb{E}[XY] - \mathbb{E}[X]\mathbb{E}[Y])$
    - the funky term with expected values is called **covariance**

### Law of large numbers

#### Weak LLN

- tells us something about large number of random variables that are ❗**identically** distributed
- when we take $n \rightarrow \infty$ then for any $\epsilon > 0$ we have $P(|\bar{X_n} - \mu| > \epsilon) = 0$
  - where $\bar{X_n}$ is the sample mean of the variables $X_1,\ldots,X_n$
  - and since each $X_i$ comes from the same distribution we have single $\mu := \mathbb{E}[X_i]$ for each of them
  - i.o.w. the limit tells us, that when enemy gives us $\epsilon$ we can guarantee that when the number of vars goes to infinity, probability of being more than $\epsilon$ far from the mean $\mu$ tends to $0$

#### Strong LLN

- for independent identically distributed random vars $X_1,\ldots,X_n$
- we have that $P(\lim_{n \rightarrow \infty}\bar{X_n} = \mu) = 1$

### Central limit theorem

- answers a question:
  - what is the distribution of the sample mean of many independent identically distributed random variables
- for every $t \in \mathbb{R}$ we have that:
- $$\lim_{n \to \infty} \mathbb{P}\left( \frac{S_n - n\mu}{\sigma \sqrt{n}} \leq t \right) = \Phi(t)$$
  - where: 
    - $\Phi(t) = \frac{1}{\sqrt{2\pi}} \int_{-\infty}^{t} e^{-x^2/2} \, dx$
    - and $S_n = \sum_{i=1}^nX_n$
    - $\mathbb{E}[X_i] = \mu$
    - $var(X_i) = \sigma$
- can also be expressed as:
  - $$\bar{X}_n \xrightarrow{d} \mathcal{N}\left( \mu, \frac{\sigma^2}{n} \right)$$

## Point estimates

### Estimator

- function $\theta_n(x_1,\ldots,x_n)$ 
  - $\theta_n : \Omega \rightarrow \mathbb{R}$ (when viewed as a random variable)
  - $\theta_n : \mathbb{R}^n \rightarrow \mathbb{R}$ (when viewed as function of the observed data)
  - where 
    - is parametrized by number of samples $n$
    - $x_i$ is a realization of some random variable
    - output is a number which estimates some parameter of the distribution from which the random variables (and their realizations) come from

### Properties of estimators

#### Biasedness

- unbiased when $\mathbb{E}[\theta_n] = \mu$ 
  - where 
    - $\mu$ is the real parameter
    - $\theta_n$ is the estimator function (in terms of the random variables)

#### Consistency

- consistent when for every $\epsilon > 0$ we have $\lim_{n \rightarrow \infty}P(|\theta_n - \mu| > \epsilon) = 0$

#### Constructing point estimate

- compute theoretical moment
- then set the empirical moment equal

### Confidence intervals

- compute $\bar{X_n}$ sample mean is the middle point
- how far the interval spreads is computed using
  - look in the table $1-\frac{\alpha}{2}$ to find $z$
  - then compute $d =z \cdot \frac{\sigma}{\sqrt{n}}$
  - then the interval is $(\bar{X_n}-d,\bar{X_n}+d)$

## Hypothesis testing

- p-value
  - $P( \text{ more extreme event than what we observed happended } | \ H_0 \text{ is true })$

### Summer 2023 (probability)

