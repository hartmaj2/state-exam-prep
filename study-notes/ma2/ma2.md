# Prep for state exam in multidimensional mathematical analysis

## TODO

- [ ] how to compute Hessian

## Topics

- [ ] Riemannův integrál jedno- i vícerozměrný
- [ ] Funkce více proměnných
  - parciální derivace: definice a výpočet
  - výpočet extrémů pomocí paricálních derivací
  - existence extrémů pro funkce několika reálných proměnných
  - vázané extrémy: výpočet pomocí Lagrangeových multiplikátorů
- [ ] Metrický prostor
  - definice a základní příklady
  - otevřené a uzavřené množiny: definice, příklady
  - spojitost funkce na metrickém prostoru
  - kompaktnost: definice a důsledky pro extrémy funkcí více proměnných
  - stejnoměrná spojitost

## Metric spaces

### Definition

- metric space is $(M,d)$ where
  - $M$ is some set
  - $d : M \times M \rightarrow \mathbb{R}_0^+$
  - and the following hold for each $x,y,z$:
    1. $d(x,x) = 0$
    2. ❗$d(y,x) = 0 \rightarrow x=y$
    3. $d(x,y) = d(y,x)$
    4. $d(x,y) + d(y,z) \geq d(x,z)$

- $\delta$ neighborhood around $a$ in metric space $(M,d)$
  - $U(a,\delta) = \{ y\in M , d(y,a) < \delta \}$
  - ❗for $\delta > 0$

- set $X$ is closed
  - for every $a \in X$ there exists $\delta$ s.t. $U(a,\delta) \subseteq X$

## Open and closed sets

- open set $X \subseteq M$ in space $(M,d)$
  - for every $x \in X$ there exists $\delta > 0$ s.t. $U(x,\delta) \subseteq X$

- closed set $X \subseteq M$ in space $(M,d)$
  - the set $M \setminus X$ is open

- equivalent characteristic of closed set
  - for every convergent sequence $(a_n)_{n=0}^\infty \subseteq X$ we have $\lim_{n \rightarrow \infty}a_n \in X$

## Past exams

### Spring 2025 (extremes of functions in multiple dimensions)

- we define set $M \subseteq \mathbb{R}^2$ as follows $M = \{(x,y) \in \mathbb{R}^2 ; -1 \leq x \leq 2 \wedge -3 < x + y < 2 \}$

#### (1)


- it is not open since for $p=(2,-1) \in M$ there exists no $\delta > 0$ such that $U(\delta,p) \subseteq M$
- to be closed, we would have to have $N = \mathbb{R}^2 \setminus M$ to be open
  - but we have $q=(2,0) \in N$ s.t. there is no $\delta > 0$ s.t. $U(\delta,q) \subseteq N$
- it is not compact because it is not closed

#### (2)

- we want function $f : M \rightarrow \mathbb{R}$ s.t. 
  - $\forall x \in M,\forall \epsilon > 0, \exists \delta > 0: y \in P(x,\delta) \implies f(y) \in U(f(x),\epsilon)$ (continuous on the whole domain)
  - there exists $m \in \mathbb{R}$ s.t. $\forall p \in M$ we have $f(p) \geq m$
  - there exists no $p \in M$ s.t. $f(p) \neq \inf(f[M])$

- yes, for example function $f(x,y) = y$

#### (3)

- $g(x,y) = x^2 - 2x + y^2 + 2y + 4$

- what criterion does the minimum need to fulfill?
  - $\frac{\partial g}{\partial x} = 2x - 2$
  - $\frac{\partial g}{\partial y} = 2y + 2$  

- partial derivatives are independent of the second variable
  - inflection point can only be at $p = (1,-1)$

- ❗should use hessian to prove that it indeed is an inflection point 

### Spring 2024 (metric spaces)

### Summer 2024 (multivariate functions)

### Autumn 2024 (closed sets in metric spaces)

#### (1) 

- just learn the definitions

#### (2)

- (a) $X_a = [0,+\infty)$
  - it is closed because $\mathbb{R} \setminus X_a = (-\infty,0)$ is open
    - for $x < 0$ we can choose $\delta = - \frac{x}{2}$
- (b) $X_b = \{ \frac{1}{n}; n \in \mathbb{N} \} = \{ 1, \frac{1}{2}, \frac{1}{3}, \ldots \}$
  - it is closed
    - ❗I guess we have to use the equivalent characteristic of a closed set