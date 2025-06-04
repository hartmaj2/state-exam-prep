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
  1. logické symboly - and, negace (stačí jen tyhle dva)
  2. proměnné (spočetně mnoho)
  3. **závorky**

- signatura 
  - jaké máme relační a funkční symboly
  - jakou mají tyto symboly aritu

- jazyk predikátové
    1. jaká je signatura?
      - to nám dá relační a funkční symboly
    2. je s rovností? 
      - to nám dá nebo nedá rovnost
    3. všechno z výrokové logiky
    4. kvantifikátory

### Formule

- to jsou věcičky, které stavíme z našich symbolů (nemůžeme ale stavět úplně jen tak ledacos)

- formule výrokové se definuje rekurzivně:
  1. každá proměnná je formule
  2. **uzávorkovaná** negace formule je zase formule
  3. **uzávorkované** spojení formulí nějakou spojkou je zase formule

- formule v predikátové logice:
  - definujeme si term rekurzivně:
    1. každá proměnná je term
    2. funkční symbol ve kterém jsou proměnné je také term
  - definujeme si nejprve atomické formule
    - atomická formule je relační symbol s vloženými **termy**
  - poté z atomických formulí definujeme obecnou formuli rekurzivně:
    1. každá atomická formule je formule
    2. formule spojená logickými spojkami a uzavřená v závorkách je formule
    3. okvantifikovaná formule jakoukoliv proměnnou je zase formule

- stromy formulí
  - protože formule mají takovou hezkou rekurzivní strukturu, tak je můžeme reprezentovat stromečkem
  - listy jsou atomické formule či prvovýroky a rodičem je vždy operátor, jehož použitím vznikla nová formule

- teorie
  - libovolná množina formulí
  - prvkům této množiny říkáme axiomy

- otevřené vs uzavřené formule
  - otevřená formule
    - formule která nemá žádný kvantifikátor
  - uzavřená formule (sentence)
    - nemá žádnou volnou proměnnou

## Sémantika

- popisuje objekty, které splňují danou teorii

- co to znamená, splnit nějakou teorii?
- napřed bychom asi měli vědět, co znamená splnit nějakou formuli

- chtěli bychom umět o výroku říct, jestli je pravdivý nebo ne při daném ohodnocení proměnných -> zadefinujeme si pravdivostní funkci

### Pravdivostní funkce ve výrokové logice

- pravdivostní funkce formule se definuje rekurzivně
  - báze je pokud je formule prvovýrok -> vrátíme jen hodnotu na pozici vektoru nul a jedniček, který odpovídá tomu danému prvovýroku (proměnné)
  - jinak používáme booleovské funkce
    - pro formuli tvaru negace je její pravdivostní funkce složením booleovské negace po aplikaci pravdivostní funkce na neznegovanou formuli
    - pro formuli tvaru spojky -> p.f. je složením booleovské funkce pro danou spojku po aplikaci pravdivostní funkce na oba podvýroky

### Model ve výrokové logice

- model ve výrokové logice
  - vektor nul a jedniček udávající, jaké jsou hodnoty jednotlivých proměnných

- když máme pravdivostní funkci $f$ pro nějaký výrok $\varphi$ a model $m$, tak můžeme spočítat $f_\varphi(m)$ a podle výsledku určit, zda výrok $\varphi$ platí v modelu $m$
  - $\varphi$ platí v $m$ právě tehdy když $f_\varphi(m) = 1$ 
    - jelikož v případě logiky chceme modely vždy prohánět naší krásnou pravdivostní funkcí $f$ a žádnou jinou, tak ji můžeme v zápisu vynechat a píšeme $m \models \varphi$

### Model v predikátové logice

- stuktura
  - definuje se vzhledem k nějaké předem dané struktuře
  - obsahuje množinu prvků - univerzum $A$ (objekty, které se cpou do proměnných)
  - pro každý relační symbol ze signatury poskytuje relaci arity daného symbolu nad množinou $A$
  - podobně pro každý funkční symbol ze signatury poskytuje funkci dané arity tedy $f : A^n \rightarrow A$

- model v predikátové logice
  - je to nějaká struktura

### Pravdivostní funkce v predikátové logice

- pravdivostní funkce teď určitě už musí vypadat nějak jinak, protože naše proměnné nyní samy o sobě už nemají pravdivostní hodnotu nula nebo jedna

- nejprve chceme umět vypreparovat z proměnné (syntax) konkrétní prvek univerza (sémantika)
  - to presně dělá **ohodnocení proměnných**: libovolná funkce $e: Var \rightarrow A$

- dále bychom chtěli umět preparovat prvky univerza z obecných termů, na to slouží tzv. **hodnota termu** 

- hodnota termu $t$ se zapisuje $t^\mathcal{A}[e]$ je definována rekurzivně pro pevnou strukturu $\mathcal{A}$ a ohodnocení proměnných $e$ (z funkce $e$ už ale plyne, že se jedná o ohodnocení struktury $\mathcal{A}$, takže ten superscript budu vynechávat)
  1. pro samostatnou proměnnou $x$ je hodnota tohoto termu jednodušše $e(x)$
  2. pro term $t=f(t_1,\ldots,t_n)$ hodnota $f^\mathcal{A}(t_1[e],\ldots,t_n[e])$

- rekurzivně si teď můžeme definovat pro libovolnou formuli $\varphi$ její pravdivostní funkci $f_\varphi$
  - ta funkce by měla jako v případě výrokové logiky vracet buď 0 nebo 1 (lež či pravda)
  1. mějmě atomickou formuli $\varphi = R(x_1,\ldots,x_n)$ definujeme pravdivostní funkci jako:
       - $f_\varphi(e) = 1$ iff $(x_1[e],\ldots,x_n[e]) \in R^\mathcal{A}$ 
       - $f_\varphi(e) = 0$ iff $(x_1[e],\ldots,x_n[e]) \not\in R^\mathcal{A}$ 
   2. pro formuli vzešlou použitím logických spojek se bude chovat jako ve výrokové logice
   3. nechť máme formuli $\varphi = (\forall x)\varphi'$ potom $f_\varphi(e)$ definujeme jako:
        - $\min_{a \in A}(f'_\varphi(e_{x\rightarrow a}))$ kde $e_{x\rightarrow a} = (e - {(x,b)} )\cup {(x,a)}$ pro nějakou $(x,b) \in e$
        - analogicky s max pro $(\exists x)\varphi'$

- o formuli $\varphi$ pak říkáme, že je pravdivá nebo lživá v nějaké struktuře $\mathcal{A}$
  - pravdivá: platí v každém ohodnocení
  - lživá: neplatí v žádném ohodnocení

- generální uzávěr formule $\varphi$
  - je to formule vzniklá přidáním všeobecného kvantifikátoru pro každou volnou proměnnou z $\varphi$

- struktura $\mathcal{A}$ je modelem teorie $T$ pokud pro každý $\varphi \in T$ máme $\mathcal{A} \models \varphi$
  - třída všech modelů teorie $T$ má pěkné značení $M(T)$

- s touto terminologií už jsme připraveni definovat si, co znamená, že nějaká formule $\varphi$ platí v teorii $T$
  - $\varphi$ je pravdiva v teorii $T$ kdyz plati v kazdem modelu $\mathcal{A} \in M(T)$
  - $\varphi$ je lziva v teorii $T$ kdyz neplati v zadnem modelu $\mathcal{A} \in M(T)$
  - jinak je formule $\varphi$ nezavisla v teorii $T$

### Past exams

### Jaro 2023 (skolemizace a modely)

- $\varphi_1$ - “Každý zajíc je rychlejší než nějaká želva.”
- $\varphi_2$ - “Každý je buď zajíc, nebo želva, ale ne obojí.”
- $\varphi_3$ - “Existuje alespoň jeden zajíc a alespoň jedna želva.”

$(\forall x)(\exists y)(Zajic(x) \wedge Zelva(y) \wedge JeRychlejsiNez(x,y))$

$(\forall x)(\neg (Zajic(x) \Leftrightarrow Zelva(x) ))$

$(\exists x)(Zajic(x)) \wedge (\exists x)(Zelva(x))$


