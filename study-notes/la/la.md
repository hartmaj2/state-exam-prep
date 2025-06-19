# Linear algebra state exam prep

## TODOs

- [ ] why we have closedness from Hladik's definition of subgroup?

## Topics

- [x] Algebraické struktury:
  - [x] grupy a podgrupy, permutace
  - [x] tělesa a speciálně konečná tělesa
- [ ] Soustavy lineárních rovnic:
  - [ ] maticový zápis, elementární řádkové úpravy, odstupňovaný tvar matice
  - [ ] Gaussova a Gaussova-Jordanova eliminace, popis množiny řešení
- [ ] Matice:
  - [ ] operace s maticemi a základní typy matic, hodnost matice
  - [ ] regulární a inverzní matice
- [ ] Vektorové prostory:
  - [ ] vektorový prostor, lineární kombinace, lineární závislost a nezávislost, lineární obal, systém generátorů
  - [ ] Steinitzova věta o výměně, báze, dimenze, souřadnice
  - [ ] vektorové podprostory, zejména maticové (řádkový, sloupcový, jádro) a jejich dimenze
- [ ] Lineární zobrazení:
  - [ ] definice, maticová reprezentace lineárního zobrazení, matice složeného zobrazení
  - [ ] obraz a jádro lineárních zobrazení
  - [ ] isomorfismus prostorů
- [ ] Skalární součin:
  - [ ] skalární součin, norma indukovaná skalárním součinem
  - [ ] Pythagorova věta, Cauchyho-Schwarzova nerovnost, trojúhelníková nerovnost
  - [ ] ortonormální systémy vektorů, Fourierovy koeficienty, Gramova-Schmidtova ortogonalizace
  - [ ] ortogonální doplněk, ortogonální projekce, projekce jako lineární zobrazení
  - [ ] ortogonální matice a jejich vlastnosti
- [ ] Determinanty:
  - [ ] definice a základní vlastnosti determinantu (multiplikativnost, determinant transponované matice, vztah s
  regularitou a vlastními čísly)
  - [ ] Laplaceův rozvoj determinantu
  - [ ] geometrická interpretace determinantu
- [ ] Vlastní čísla a vlastní vektory:
  - [ ] definice, geometrický význam a základní vlastnosti vlastních čísel, charakteristický polynom, násobnost
  vlastních čísel
  - [ ] podobnost a diagonalizovatelnost matic, spektrální rozklad
  - [ ] symetrické matice, jejich vlastní čísla a spektrální rozklad
- [ ] Positivně semidefinitní a positivně definitní matice:
  - [ ] charakterizace a vlastnosti, vztah se skalárním součinem, vlastními čísly
  - [ ] Choleského rozklad (znění věty a praktické použití)

## Algebraic structures

### Group

- $\mathcal{G}=(G,\cdot,0)$ where 
  - $\cdot : G \times G \rightarrow G$
  - ❗$0 \in G$
  - and we have for each $x,y,z \in G$
    - associativity of $\cdot$
    - neutrality of $0$ w.r.t. $\cdot$ 
      - (when $0$ is multiplied with any elem $x$, then the result is $x$)
    - invertibility of every element 
      - (for each $x \in G$, there exists $y \in G$ s.t. $x \cdot y = 0$)

- group can also be commutative

### Subgroup

- subgroup $\mathcal{H} = (H,+)$ of group $\mathcal{G} = (G,\cdot)$ is
  - $H \subseteq G$
  - for each $x,y \in H$ we have $x + y = x \cdot y$

- characteristic of subgroup $\mathcal{H} = (H,+)$
  - $H \subseteq G$
  - $0 \in H$
  - for $x,y \in H$ 
    - we have $x \cdot y \in H$
    - $x^{-1} \in H$

### Permutation

- is a mapping $\pi : V \rightarrow V$ s.t. it is a bijection

- $S_n = \{ f: [n] \rightarrow [n] : \ f \ \text{ is bijection} \}$

### Field

- a tuple $\mathcal{F} = (F,\cdot,+)$ s.t.
  - $(F,+)$ is a **commutative** group
    - where $0$ is the neutral element for $+$
  - ❗$(F \setminus \{0 \},\cdot)$ is a **commutative** group
  - distributivity 
    - $\forall x,y,z \in F$ we have $x \cdot (y + z) = x \cdot y + x \cdot z$

- if $\mathcal{F}$ is a finite field, then $|F| = p^k$ where
  - $p$ is a prime number
  - $k$ is a ❗positive integer
    - a field must have at least two elements (unlike a group)

## Systems of linear equations

### Matrix form

- system of linear equations
  - set of expressions in form
    - $k_{1,1}x_1 + \ldots k_{1,n}x_n = b_1$
    - $\ldots$
    - $k_{m,1}x_1 + \ldots k_{m,n}x_n = b_m$

### Elementary row operations

- multiply a row by $\alpha \neq 0$
  - if $\alpha = 0$, then such operation would increase the solution set from $A$ to $A'$
- add row $i$ to row $j$ 
  - ❗but no multiplication allowed (we can simulate mult using sequence of these ops)

### Row echelon form

- pivot
  - ❗non-zero element of a matrix with the lowest index in its row

- matrix $A$ is in REF
  - exists index $k$ s.t. 
    - rows $r_1,\ldots,r_k$ are non-zero rows
    - rows $r_{j+1},\ldots,r_n$ are all-zero rows
  - we have $p_1 < \ldots < p_k$
    - where $p_i = \min\{j ; a_{i,j} \neq 0\}$ 
      - index of non-zero element of $i$-th row with the smallest column index
    - ❗not that from $p_i$'s we want strict inequality

- rank of $A$
  - number of non-zero rows of $A$ in REF

- matrix $A$ is in RREF
  - $A$ is in REF
  - for every non-zero row $i$ we have 
    - ❗$a_{1,p_i} = 0 \wedge \ldots \wedge a_{i-1,p_i} = 0$
    - $a_{i,p_i} = 1$

### Regular matrix

- matrix $A$ is regular iff
  - $A \in \mathbb{F}^{n \times n}$ for some $n \in \mathbb{N}$
  - $Ax = 0$ iff $x$ is the zero vector

## Vector spaces

### Vector space

- vector space $\mathcal{V}$
  - set $V$ 
  - field $\mathbb{F}=(F,+,\cdot)$ s.t.
    - $e_1$ is neut. elem for $+$
    - $e_2$ is neut. elem for $\cdot$
  - operation $\oplus : V \times V \rightarrow V$
  - operation $\star : F \times V \rightarrow V$
  - for every $\alpha,\beta \in F$ and every $v,w \in V$ we have:
    - $e_2 \star v = v$
      - neutrality of $e_2$ w.r.t. $\star$
    - $(\alpha + \beta) \star v = \alpha \star v \oplus \beta \star v$
      - distributivity of $\star$ over $+$
    - $\alpha \star (v \oplus w) = \alpha \star v \oplus \alpha \star w$
      - distributivity of $\star$ over $\oplus$
    - $\alpha \star (\beta \star v) = (\alpha \cdot \beta) \star v$
      - associativity of $\cdot$ and $\star$
  - ❗$(V,\oplus)$ is a commutative group
    - $e_3$ is neutral element for $\oplus$

- vector subspace $\mathcal{U}$ of $\mathcal{V}$
  - $U \subseteq V$
  - $\mathcal{U}$ is vector space over same field $\mathbb{F}$

- span of set $X$
  - for vector space with set $V$ s.t. $X \subseteq V$
  - is $\bigcap_{U : X \subseteq U \subseteq V}U$ where $U$ is ground set of vector space with ground set $V$

- generators of space $U$
  - if we have $U$ is a span of $X$ 
  - then every $x \in X$ is a generator of $U$
  - we also say that $X$ generates $U$

- linear combination
  - for vectors $x_1,\ldots,x_n$ from vector space $V$ over $\mathbb{F}$
  - for coefficients $\alpha_1,\ldots,\alpha_n$
  - is an expression $\sum_{i=1}^n\alpha_i \star x_i$

- linear independence
  - we say that vectors $x_1,\ldots,x_n$ are linearly independent when
    - for $\alpha_i,\ldots,\alpha_n$ we have 
      - $\sum_{i=1}^n\alpha_i \star x_i = e_3$ 
      - iff for every $i$ we have $\alpha_i = e_1$

- basis $X$
  - vectors $x_1,\ldots,x_n$ s.t. $X=(x_1,\ldots,x_n)$ form a basis of vector space $V$ iff
    - they are linearly independent
    - span of $X$ is $V$
  - ❗it is a system because it is ordered

- coordiantes with respect to basis $B=\{b_1,\ldots,b_n\}$
  - let $u = \sum_{i=1}^n\alpha_i \star b_i$
  - then $[u]_B = (\alpha_1,\ldots,\alpha_n)^T$

### Steinitz theorem

- says that every system of linearly independent guys $X$ is at most as bit as any system of generators $Y$ of vector space $V$
- so if $|X|=m$ and $|Y|=n$ we have $m \leq n$

- but moreover, we can pick $n-m=k$ guys from $Y$ and name them
  - $y_1,\ldots,y_k$
  - and $\{ x_1, \ldots,x_m,y_1,\ldots,y_k \}$ spans $V$

- analogy to inclusion exclusion principle
  - $\dim(U + V) = \dim(U) + \dim(V) - \dim(U \cap V)$

- dimension of kernel and column/row spaces
  - for matrix $A \in \mathbb{F}^{m \times n}$
  - $\dim(\ker(A)) + rank(A) = n$
  - kernel ... how many dimensions we lose when mapping
  - rank ... how many dimensions we do not lose when mapping
  - n ... arity of vectors that we are mapping (all available dimensions)

## Linear mapping

- $f : V \rightarrow W$ is linear mapping between spaces iff
  - $f(\alpha \star u \oplus \beta \star v) = \alpha \cdot f(u) + \beta \cdot f(v)$

- matrix $A$ of a linear mapping $f : U \rightarrow W$
  - notation: $A = {}_{B_V}[f]_{B_U}$
  - $B_U = \{u_1,\ldots,u_n\}$
  - $B_W = \{w_1,\ldots,w_m\}$
  - $A$ is a matrix s.t.
    - $f(x_i) = \sum_{j=0}^m  a_{j,i} \cdot w_j$
  - imagine that the $a_{j,i}$'s are just the coordinates of the image of $x_i$ w.r.t. $B_W$

- transition matrix $A$
  - matrix of linear mapping $id$
  - for two bases $B_1,B_2$ of the same vector space

- matrix $C \in \mathbb{F}^{k \times n}$ of $(g \circ f)$
  - lin. map. $f : U \rightarrow V$
  - lin. map. $g : V \rightarrow W$
  - basis $B_U = \{x_1,\ldots,x_n\}$
  - basis $B_V = \{y_1,\ldots,y_m\}$
  - basis $B_W = \{z_1,\ldots,z_k\}$
  - then matrix $C={}_{B_W}[g \circ f]_{B_U} = {}_{B_W}[g]_{B_V} \cdot {}_{B_V}[f]_{B_U}$
  - i.o.w. matrix of composite mapping is just a matrix multiple of the corresponding matrices

- for linear mapping $f : U \rightarrow V$ we have
  - $f(U) = \{ f(x) \ : x \in U \}$
  - $\ker(f) = \{ x \in U \ : \ f(x) = o \}$ where $o$ is neutral element in $U$

- isomorphism
  - linear mapping which is also a bijection

- inverse of isomorphism $f$
  - for linear isomorphism $f : U \rightarrow V$
  - we have ${}_{B_U}[f^{-1}]_{B_V} = ({}_{B_V}[f]_{B_U})^{-1}$
  - i.o.w. the matrix of mapping inverse to $f$ is exactly the inverse matrix of ${}_{B_U}[f]_{B_V}$

- dimension of domain vs dimensions of kernel and image
  - $\dim(U) = \dim(\ker(f)) + \dim(f(U))$

## Scalar product

### Scalar product

- scalar product $\sigma : V \times V \rightarrow \mathbb{C}$
  - ❗$V$ is vector space on $\mathbb{C}$
  - for every $x,y,z \in V$ and $\alpha \in \mathbb{C}$ we have:
    - $\sigma(x,x) \geq 0$
      - $\geq$ is standard linear ordering on $\mathbb{R}$
    - $\sigma(x,x) = 0$ iff $x = e_3$
    - $\sigma(x,y) = \overline{ \sigma(y,x)}$
    - $\sigma(\alpha \star x,y)= \alpha \cdot \sigma(x, y)$
    - $\sigma(x \oplus y ,z) \leq \sigma(x,z) + \sigma(y,z)$

### Norm

- norm $\mu : V \rightarrow \mathbb{R}$
  - $V$ is vector space over $\mathbb{C}$
  - $\mu(x) \geq 0$
  - $\mu(x) = 0$ iff $x = e_3$
  - $\mu(\alpha \star x) = |\alpha| \cdot \mu(x)$
    - scaling inside the vector spaces scales the resulting measurement in the same way
  - $\mu(x \oplus y) = \mu(x) + \mu(y)$
    - triangle inequality

- norm induced by scalar product

- Pythagorean theorem
  - $c^2 = a^2 + b^2$
  - $\mu(a \oplus b)^2 = \mu(a)^2 + \mu(b)^2$

- Cauchy-Schwarz inequality
  - $| \sigma(x,y) | \leq \mu(x) \cdot \mu(y)$

- triangle inequality
  - $\mu(a \oplus b) \leq \mu(a) + \mu(b)$

### Fourier coefficients

- for orthogonal basis $z_1,\ldots,z_n$ of $V$
  - scalar product $\sigma$
  - we have for $x \in V$ 
    - $x = \sum_{i=0}^n\alpha_i \star z_i$ but also
    - $x = \sum_{i=0}^n \sigma(x,z_i) z_i$

### Gram-Schmidt orthonormalization

- we have $z_1,\ldots,z_{k-1}$ orthonormal
- $y_k = x_k - \sum_{i=1}^{k-1} \lang x_k,z_i \rang \cdot z_i$
- $z_k = \frac{1}{\mu(y_k)} \star y_k$
  - i.o.w. the sum that we subtract is the representation of $x_k$ w.r.t. the orthonormal basis we made to far
  - we then subtract this representatino from $x_k$ to get him out of the dimensions of $z_1,\ldots,z_{k-1}$

### Orthogonality

- orthogonal complement of ❗**subset** $U$ of $W$ is $U^\perp$
  - $U^\perp = \{ v \in W \ | \ \forall w \in U : \sigma(v,w) = 0 \}$

- orthogonal projection of $v \in V$ to subspace $U$
  - $p : V \rightarrow U$
  - s.t. $p(v) = \argmin_{u \in U}(\mu(v-u))$
    - where $\mu$ is norm on $V$

- matrix $M$ is orthogonal 
  - if $M^TM = I_n$
  - nice to see when imagining what $M^TM$ does
    - check the diagonal
    - check the rest

- characteristic of orthogonal matrices
  - the columns are unit vectors that are pairwise perpendicular to themselves

- product of orthonormal matrices is orthonormal

- multiplying $x$ by orthonormal matrix does not change the norm of any $x$

- applying orthonormal matrix to both $x,y$ does not change their scalar product 

## Past exams

### Spring 2025 (matrices)

#### (1)

- use the fact that row space of $A$ is perpendicular to kernel of $A$
  - that can be shown by writing out what that means

- we know that the kernel of $A$ is equal to span of two vectors
  - so the span of those two vectors must be perpendicular to row space of $A$

- we find out that what is perpendicular to span those two vectors can only be some multiple of a vector $v$

- then $v$ generates the row space

- so we know that the rows of the matrix we are looking for are just some multiples of $v$

- but we want $A$ to be symmetric
  - this can be done if we do $v \cdot v^T$ (we know that result of this expression will be a symmetric matrix)

### Spring 2024 (scalar product)

### Summer 2024 (basis of vector space)

### Spring 2023 (linear mapping)

### Summer 2023 (linear algebra)

