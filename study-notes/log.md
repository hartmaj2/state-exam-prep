# Preparation for logic part of the state exam

## Topics

- [ ] Syntaxe
  - znalost a práce se základními pojmy syntaxe výrokové a predikátové logiky (jazyk, otevřená a uzavřená
  formule, instance formule, apod.)
  - normální tvary výrokových formulí
    - prenexní tvary formulí predikátové logiky
    - znalost základních normálních tvarů (CNF, DNF, PNF)
    - převody na normální tvary
    - použití pro algoritmy (SAT, rezoluce)
- [ ] Sémantika
  - pojem modelu teorie
  - pravdivost, lživost, nezávislost formule vzhledem k teorii
  - splnitelnost, tautologie, důsledek
  - analýza výrokových teorií nad konečně mnoha prvovýroky
- [ ] Extenze teorií
  - schopnost porovnat sílu teorií
  - konzervativnost, skolemizace
- [ ] Dokazatelnost:
  - pojem formálního důkazu, zamítnutí
  - schopnost práce v některém z formálních dokazovacích systémů (např. tablo metoda, rezoluce, Hilbertovský
  kalkul)
- [ ] Věty o kompaktnosti a úplnosti výrokové a predikátové logiky
  - znění a porozumění významu
  - použití na příkladech, důsledky
- [ ] Rozhodnutelnost
  - pojem kompletnosti a její kritéria, význam pro rozhodnutelnost
  - příklady rozhodnutelných a nerozhodnutelných teorií

## Syntax

### Jazyk

- jazyk výrokové
  - logické symboly - and, negace (stačí jen tyhle dva)
  - proměnné (spočetně mnoho)
  - **závorky**

- signatura 
  - jaké máme relační a funkční symboly
  - jakou mají tyto symboly aritu

- jazyk predikátové
    - jaká je signatura?
      - to nám dá relační a funkční symboly
    - je s rovností? 
      - to nám dá nebo nedá rovnost
    - všechno z výrokové logiky
    - kvantifikátory

### Formule

- to jsou věcičky, které stavíme z našich symbolů (nemůžeme ale stavět úplně jen tak ledacos)

- formule výrokové se definuje rekurzivně:
  - každá proměnná je formule
  - **uzávorkovaná** negace formule je zase formule
  - **uzávorkované** spojení formulí nějakou spojkou je zase formule

- formule v predikátové logice:
  - definujeme si term rekurzivně:
    - každá proměnná je term
    - funkční symbol ve kterém jsou proměnné je také term
  - definujeme si nejprve atomické formule
    - atomická formule je relační symbol s vloženými **termy**
  - poté z atomických formulí definujeme obecnou formuli rekurzivně:
    - každá atomická formule je formule
    - formule spojená logickými spojkami a uzavřená v závorkách je formule
    - okvantifikovaná formule jakoukoliv proměnnou je zase formule

- stromy formulí
  - protože formule mají takovou hezkou rekurzivní strukturu, tak je můžeme reprezentovat stromečkem
  - listy jsou atomické formule či prvovýroky a rodičem je vždy operátor, jehož použitím vznikla nová formule

- teorie
  - libovolná množina formulí
  - prvkům této množiny říkáme axiomy

## Sémantika

- popisuje objekty, které splňují danou teorii

- co to znamená, splnit nějakou teorii?
- napřed bychom asi měli vědět, co znamená splnit nějakou formuli

- chtěli bychom umět o výroku říct, jestli je pravdivý nebo ne při daném ohodnocení proměnných -> zadefinujeme si pravdivostní funkci
  
- pravdivostní funkce formule se definuje rekurzivně
  - báze je pokud je formule prvovýrok -> vrátíme jen hodnotu na pozici vektoru nul a jedniček, který odpovídá tomu danému prvovýroku (proměnné)
  - jinak používáme booleovské funkce
    - pro formuli tvaru negace je její pravdivostní funkce složením booleovské negace po aplikaci pravdivostní funkce na neznegovanou formuli
    - pro formuli tvaru spojky -> p.f. je složením booleovské funkce pro danou spojku po aplikaci pravdivostní funkce na oba podvýroky

- model
  - vektor nul a jedniček udávající, jaké jsou hodnoty jednotlivých proměnných

- když máme pravdivostní funkci $f$ pro nějaký výrok $\varphi$ a model $m$, tak můžeme spočítat $f_\varphi(m)$ a podle výsledku určit, zda výrok $\varphi$ platí v modelu $m$
  - $\varphi$ platí v $m$ právě tehdy když $f_\varphi(m) = 1$ 
    - jelikož v případě logiky chceme modely vždy prohánět naší krásnou pravdivostní funkcí $f$ a žádnou jinou, tak ji můžeme v zápisu vynechat a píšeme $m \models \varphi$

### Past exam

### Jaro 2023 (skolemizace a modely)

- $\varphi_1$ - “Každý zajíc je rychlejší než nějaká želva.”
- $\varphi_2$ - “Každý je buď zajíc, nebo želva, ale ne obojí.”
- $\varphi_3$ - “Existuje alespoň jeden zajíc a alespoň jedna želva.”

$(\forall x)(\exists y)(Zajic(x) \wedge Zelva(y) \wedge JeRychlejsiNez(x,y))$

$(\forall x)(\neg (Zajic(x) \Leftrightarrow Zelva(y) ))$

$(\exists x)(Zajic(x)) \wedge (\exists x)(Zelva(x))$


