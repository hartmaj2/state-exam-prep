# Prep for state exam in multidimensional mathematical analysis

## TODO

- [ ] how to compute Hessian
- [ ] definition of partial derivative

## Topics

- [x] Riemannův integrál jedno- i vícerozměrný
- [x] Funkce více proměnných
  - [x] parciální derivace: definice a výpočet
  - [x] výpočet extrémů pomocí paricálních derivací
  - [x] existence extrémů pro funkce několika reálných proměnných
  - [ ] vázané extrémy: výpočet pomocí Lagrangeových multiplikátorů
- [x] Metrický prostor
  - [x] definice a základní příklady
  - [x] otevřené a uzavřené množiny: definice, příklady
  - [x] spojitost funkce na metrickém prostoru
  - [x] kompaktnost: definice a důsledky pro extrémy funkcí více proměnných
  - [x] stejnoměrná spojitost

## Riemann integral in multiple dimensions

### Definitions

- $n$-dimensional compact interval
  - for pairs of points $(a_1,b_1),\ldots,(a_n,b_n)$
  - is $J = \langle a_1,b_1 \rangle \times \ldots \times \langle a_n,b_n \rangle$

- multi-partition of $J$
  - is a sequence of partitions $P=(P_1,\ldots,P_n)$ where
    - $P_i$ is a partition of $\langle a_i,b_i \rangle$
    - $P_i = (a_i = t_{i,1} < \ldots < t_{i,k_i} = b_i)$

- brick is $B = [t_{1,j_1},\ldots,t_{1,j_1+1}] \times \ldots \times [t_{n,j_n},\ldots,t_{n,j_n+1}]$
  - ❗notice double indexes of the second coefficient, that's because the offset can be starting at different point for each partition

- set of all bricks in $P$ is $\mathcal{B}(P)$

- brick volume $vol(B)$
  - product of sizes of all the intervals that the brick is composed of

- upper and lower sums
  - parametrized by $n$-dimensional compact interval $J$ and its multi-partition $P$
  - go over all bricks and compute the sum of their infima/suprema times volumes 

## Mutlivariate functions

### Partial derivatives

- fix everything except a single variable

### Finding extrema

1. compute the gradient $\nabla f$ - see where it is $o$
2. look at edges of the set $M$
3. look where partial derivatives are undefined

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

- set $X$ is open
  - for every $a \in X$ there exists $\delta$ s.t. $U(a,\delta) \subseteq X$

## Open and closed sets

- open set $X \subseteq M$ in space $(M,d)$
  - for every $x \in X$ there exists $\delta > 0$ s.t. $U(x,\delta) \subseteq X$

- closed set $X \subseteq M$ in space $(M,d)$
  - the set $M \setminus X$ is open

- equivalent characteristic of closed set
  - for every convergent sequence $(a_n) \subset X$ we have $\lim_{n \rightarrow \infty}a_n \in X$

## Compact sets

- compact set $X \subseteq M$
  - every sequence $(a_n) \subset X$ has a subsequence $(a_{n_k})$ s.t. it converges to a point inside $X$

- on a compact set a continuous function has global minimum and maximum

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
  - $\frac{\partial g}{\partial x}(x,y) = 2x - 2$
  - $\frac{\partial g}{\partial y}(x,y) = 2y + 2$  

- partial derivatives are independent of the second variable
  - inflection point can only be at $p = (1,-1)$

- ❗should use hessian to prove that it indeed is an inflection point 

### Spring 2024 (metric spaces)

### Summer 2024 (multivariate functions)

#### (1)

- $f$ is continuous at point $x$
  - $\forall \epsilon, \exists \delta, y \in U(x,\delta) \implies f(y) \in U(f(x),\epsilon)$
  - ❗ $U(x,\delta) = \{ y \ ; \ d_n(x,y) < \delta\}$

#### (2)

- $f(x,y) = \exp(x^2) \cdot \ln(2 + y^2)$

- $\frac{\partial f}{\partial x}(x,y)=\exp(x^2) \cdot 2x \cdot \ln(2 + y^2)$

- $\frac{\partial^2 f}{\partial x \partial y}(x,y)=\exp(x^2) \cdot 2x \cdot (2 + y^2)^{-1} \cdot 2y$

- $\frac{\partial^2 f}{\partial x^2}(x,y)= (\exp(x^2) \cdot 2 + \exp(x^2) \cdot 4x^2) \cdot \ln(2 + y^2) = \exp(x^2) ( 2 +  4x^2) \cdot \ln(2 + y^2)$

#### (3)

- $f$ is continuous on its whole domain so it must have global maximum and minimum

- $\frac{\partial f}{\partial y}(x,y)= \exp(x^2) \cdot (2 + y^2)^{-1} \cdot 2y$

- look where we have $\frac{\partial f}{\partial x}(x,y)=\frac{\partial f}{\partial y}(x,y)=0$
  - when $x=0$ and $y=0$

- compute Hessian to see if it is not an inflection point without min/max

- ❗show that the function is unbounded when $x \rightarrow \infty$

### Autumn 2024 (closed sets in metric spaces)

#### (1) 

- just learn the definitions

#### (2)

- (a) $X_a = [0,+\infty)$
  - it is closed because $\mathbb{R} \setminus X_a = (-\infty,0)$ is open
    - for $x < 0$ we can choose $\delta = - \frac{x}{2}$
- (b) $X_b = \{ \frac{1}{n}; n \in \mathbb{N} \} = \{ 1, \frac{1}{2}, \frac{1}{3}, \ldots \}$
  - ❗ it is open since the sequence $(a_n)$ where $a_i = \frac{1}{i}$ converges to $0 \notin X_b$ 

#### (3)

- ❗always try use every assumption!
  - think about intuition why the assumption is necessary
  - what exactly would go wrong if the assumption did not hold
- the straightforward solution works here
  - write out definitions of the assumption and the set involved
- use WLOG