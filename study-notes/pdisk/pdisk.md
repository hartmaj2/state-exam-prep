# State exam prep on advance discrete mathematics

## Topics

- [ ] Barvení grafů
  - [ ] definice a základní vlastnosti
  - [ ] hranová barevnost (definice, formulace Vizingovy věty, souvislost s párováními v grafech)
  - [ ] Brooksova věta (formulace)
  - [ ] základní metody z důkazů Vizingovy a Brooksovy věty (Kempeho řetězce, hladový algoritmus)
  - [ ] silná a slabá věta o perfektních grafech (formulace), chordální grafy a další příklady tříd perfektních grafů
- [ ] Párování v grafech
  - [ ] definice párování a perfektního párování
  - [ ] párování v obecných grafech (formulace Tutteovy věty včetně důkazu jednodušší implikace, Petersenova
  věta a její důkaz použitím Tutteovy věty)
  - [ ] Edmondsův algoritmus (pouze vědět o jeho existenci)
- [ ] Kreslení grafů na plochách
  - [ ] základní topologické pojmy (homeomorfismus, křivka, plocha)
  - [ ] konstrukce ploch pomocí přidávání uší a křížítek (formulace), orientovatelné a neorientovatelné plochy,
  Eulerova charakteristika
  - [ ] pojem buňkového (2-cell) nakreslení
  - [ ] zobecněná Eulerova formule, její použití pro horní odhad počtu hran a minimálního stupně v grafu
  nakresleném na dané ploše
- [ ] Grafové minory
  - [ ] definice a základní vlastnosti
  - [ ] zachovávání nakreslení při minorových operacích
- [ ] Množiny a zobrazení
  - [ ] přehled o používané terminologii (třídy a vlastní třídy, kartézský součin, relace, zobrazení, suma, potenční
  množina, ...)
- [ ] Subvalence a ekvivalence množin
  - [ ] definice
  - [ ] Cantorova-Bernsteinova věta (bez důkazu)
  - [ ] spočetné množiny
    - [ ] definice
    - [ ] zachovávání spočetnosti při množinových operacích
  - [ ] mohutnost množin racionálních a reálných čísel, důkaz neekvivalence diagonální metodou
- [ ] Dobré uspořádání
  - [ ] definice
  - [ ] ordinální a kardinální čísla (definice)

## Graph coloring

- Brooks theorem
  - for graph $G$ which is connected
    - $G$ has $\chi(G) = \Delta(G) + 1$ iff $G$ is an odd cycle or a complete graph
    - otherwise $\chi(G) \leq \Delta(G)$
    - where $\Delta(G) = \max_{v \in V(G)}\deg(v)$