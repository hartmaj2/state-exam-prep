# Linear algebra state exam prep

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
  - $(F,+)$ is a commutative group
    - where $0$ is the neutral element for $+$
  - ❗$(F \setminus \{0 \},\cdot)$ is a commutative group
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
- add row $i$ to row $j$ where $i \neq j$

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

- rank of $A$
  - number of non-zero rows of $A$ in REF

- matrix $A$ is in RREF
  - $A$ is in REF
  - we have for every non-zero row $i$ that $a_{i,p_i} = 1$
  - ❗for every non-zero row $i$
    - for every $j \in \{1,\ldots,i-1\}$
      - we have $a_{j,p_i} = 0$

### Regular matrix

- matrix $A$ is regular iff
  - $A \in \mathbb{F}^{n \times n}$ for some $n \in \mathbb{N}$
  - $Ax = 0$ iff $x$ is the zero vector

## Vector spaces

### Vector space

- vector space
  - set $V$ 
  - field $\mathbb{F}=(F,+,\cdot)$ s.t.
    - $e_1$ is neut. elem for $+$
    - $e_2$ is neut. elem for $\cdot$
  - operation $\oplus : V \times V \rightarrow V$
  - operation $\star : F \times V \rightarrow V$
  - for every $\alpha,\beta \in F$ and every $v,w \in V$ we have:
    - $e_2 \star v = v$
    - $(\alpha + \beta) \star v = \alpha \star v \oplus \beta \star v$
    - $\alpha \star (v \oplus w) = \alpha \star v \oplus \alpha \star w$
    - $\alpha \star (\beta \star v) = (\alpha \cdot \beta) \star v$
  - ❗$(V,\oplus)$ is a commutative group

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

