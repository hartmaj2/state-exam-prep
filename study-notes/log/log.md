# Preparation for logic part of the state exam

## TODOs

- [ ] solve problem from past exam Spring 2023
  - [ ] how resolution method works?

## Topics

- [x] Syntaxe
  - znalost a práce se základními pojmy syntaxe výrokové a predikátové logiky (jazyk, otevřená a uzavřená
  formule, instance formule, apod.)
  - normální tvary výrokových formulí
    - prenexní tvary formulí predikátové logiky
    - znalost základních normálních tvarů (CNF, DNF, PNF)
    - převody na normální tvary
    - použití pro algoritmy (SAT, rezoluce)
- [x] Sémantika
  - pojem modelu teorie
  - pravdivost, lživost, nezávislost formule vzhledem k teorii
  - splnitelnost, tautologie, důsledek
  - analýza výrokových teorií nad konečně mnoha prvovýroky
- [ ] Extenze teorií
  - schopnost porovnat sílu teorií
  - konzervativnost, skolemizace
- [x] Dokazatelnost:
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
  2. pro formule $\varphi_1, \varphi_2$ je $(\varphi_1 \wedge \varphi_2)$ take formule
  3. pro formuli $\varphi_1$ je $(\neg \varphi_1)$ take formule

- formule v predikátové logice:
  - definujeme si **term** rekurzivně (term je symbol, který se dá strkat do atomických formulí):
    1. každá proměnná je term
    2. funkční symbol ve kterém jsou **termy** je také term
  - definujeme si nejprve **atomické formule**
    - atomická formule je relační symbol s vloženými **termy**
  - poté z atomických formulí definujeme **obecnou formuli** rekurzivně:
    1. každá atomická formule je formule
    2. pro formuli $\varphi$ je $(\neg \varphi)$ take formule
    3. pro formule $\varphi_1, \varphi_2$ je $(\varphi_1 \wedge \varphi_2)$ take formule
    4. pro forumi $\varphi$ a lib. prom $x$ jsou $((\forall x)\varphi)$ a $((\exists x)\varphi)$ take formule

- stromy formulí
  - protože formule mají takovou hezkou rekurzivní strukturu, tak je můžeme reprezentovat stromečkem
  - listy jsou atomické formule či prvovýroky a rodičem je vždy operátor, jehož použitím vznikla nová formule

- teorie
  - libovolná množina formulí
  - prvkům této množiny říkáme axiomy

- otevřené vs uzavřené formule
  - otevřená formule
    - formule která **nemá žádný kvantifikátor**
  - uzavřená formule (sentence)
    - nemá žádnou volnou proměnnou

- instance formule $\varphi$
  - je to formule vznikla dosazenim nejakeho termu $t$ za nejakou volnou promennou $x$ ve formuli $\varphi$
  - dosazovani vsak nemuzeme delat uplne libovolne
    - je nutne aby se term $t$ (nebo nejaka promenna v jeho listech) nenavazal na nejaky kvantifikator uvnitr formule $\varphi$

- varianta formule $\varphi$
  - vznikne, pokud prejmenujeme promennou kvantifikatoru a vsechny vyskyty promennych na nej navazanych
  - prejmenovani take nemuzeme delat uplne hlava nehlava
    - promenna, na kterou prejmenovavame nesmi byt volna ve $\varphi$
    - promenna, na kterou prejmenovavame nesmi byt ve $\varphi$ vazana na nejaky jiny kvantifikator (vsimneme si, ze to je stejna podminka jako u instance formule, rikame ji **substituovatelnost**)

### Normalni formy

- muze se stat, ze dve syntakticky ruzne formule maji stejnou mnozinu modelu, ktere tyto formule modeluji
  - e.g. $x \rightarrow y$ ma stejne modely jako $\neg x \vee y$
  - abychom se zbavili teto mnohoznacnosti, tak si zavedeme tzv. normalni formy

- CNF (Conjunctive Normal Form)
  - formule je v CNF pokud je konjunkci klauzuli
  - klauzule je disjunkce literalu
  - literal je promenna **nebo jeji negace**
  - prazdny vyrok v CNF je true

> Formuli v CNF si muzeme predstavit takto: 
>
> Mame proud vody, ktery chceme aby mohl protect z jedne strany na druhou. Kazda klauzule je prekazka na tomto proudu. Promenne jsou jednotlive skulinky v teto prekazce, kterymi se muze dostat voda dale. Staci, aby se v kazde prekazce mohla dostat alespon jednou skulinkou.

- DNF (Disjunctive Normal From)
  - formule je v DNF pokud je disjunkci elementarnich konjunkci
  - elementarni konjunkce je konjunkce literalu
  - prazdny vyrok v DNF je false

- ! porad jsme se vsak jednoznacnosti nezbavili, ke kazde formul $\varphi$ v DNF, obsahujici elementarni konjunkci $E$ muzeme vytvorit formuli $\varphi \vee E$, ktera ma stejnou mnozinu modelu (podobny spinavy trik muzeme udelat i s CNF)

- PNF (Prenex Normal Form)
  - jen pro predikatovou logiku
  - formule $\varphi$ je v PNF kdyz je tvaru $(Q_1 x_1)\ldots(Q_n x_n)\varphi'$ kde $\varphi'$ uz neobsahuje zadny kvantifikator

- jak vypada strom formule, ktera je v PNF
  - v PNF ten strom musi mit od korene same kvantifikatory az po nejaky nekvantifikator, pak uz mame jen logicke spojky az po listy, kterymi jsou atomicke formule
  - atomicke formule muzeme rozvinout dale do stromu, ve kterych uz jsou jen termy (v listech jsou pak konstanty nebo promenne)

- mejme tedy nejaky strom, ktery neni v PNF
  - to znamena, ze nad nejakym kvantifikatorem mame spojku $\neg$ nebo $\wedge$
  - v tom pripade musime kvantifikator "probublavat" stromem, dokud uz nad nim nebude zadna spojka
  - kdyz mame vyraz $(\neg ((\forall x)\varphi))$ tak ho muzeme prevest na $(\exists x)(\neg \varphi)$ a naopak, kdyz jsou prohozene kvantifikatory
  - take muze nastat $((\forall x)\varphi_1) \wedge \varphi_2$, to je trochu zajimavejsi pripad
    - nejprve prejmenujeme promenne v $\varphi_2$ tak, aby neobsahovali promennou $x$
    - dale uz muzeme tuto formuli prevest na $(\forall x)(\varphi_1 \wedge \varphi_2)$

### Normalni formy a algoritmy

- casto bychom byli radi, kdybychom mohli overit splnitelnost logicke formule nejak automaticky a nemuseli to delat rucne
- chceme tedy mit nejaky algoritmus, ktery toto overi za nas
- proto se nam hodi normalni formy, se kterymi algoritmus dokaze hezky pracovat

#### SAT (Satisfiability)
  - algoritmus, ktery pro danou formuli v CNF ma rici, zda je splnitelna ci nikoliv
  - tedy: $\varphi$ v CNF -> | SAT solver | -> TRUE/FALSE (existuje model $v$ s.t. $v \models \varphi$ ?)
  - resi se v praxi casto pomoci DPLL

#### DPLL Algoritmus (Davis-Putnam-Logemann-Loveland)

- jednotkova propagace
  - jednotkova klauzule nam totiz vynucuje primo konkretni hodnotu promenne
  - pro jednotkovou klauzuli $x$ je nova klauzule $\varphi^x$ nova klauzule, ktera vznikne z $\varphi$ nasledujicim zpusobem:
    - pokud klauzule $C$ obsahuje $\bar{x}$, tak $\bar{x}$ vyhodime z $C$ -> pokud je $\bar{x}$ posledni, tak vratime FALSE
    - pokud klauzule $C$ obsahuje $x$, tak vyhodime celou klauzuli $C$ -> pokud nam takto vznikne prazdna klauzule, tak vratime TRUE

- cisty vyskyt
  - promenna $x$ ma cisty vyskyt ve formuli $\varphi$ iff neexistuje klauzule $C \in \varphi$, ktera obsahuje $\bar{x}$
  - opacne muze mit i $\bar{x}$ cisty vyskyt
  - cisteho vyskytu se muzeme zbavit tak, ze odstranime vsechny klauzule, ktere obsahuji promennou $x$ (tim de fakto promennou $x$ nastavujeme na 1)

- algoritmus DPLL pro formuli $\varphi$ v CNF:
  1. dokud muzes, tak jednotkove propaguj
  2. dokud muzes, tak odstranuj ciste vyskyty
  3. uz ti nezbyla zadna klauzule -> vyrok je TRUE
  4. dospel jsi k prazdne klauzuli -> vyrok je FALSE
  5. pokud jsi se dostal az sem, tak vem libovolnou promennou $x$ a zavolej se rekurzivne na $\varphi \wedge x$ a $\varphi \wedge \bar{x}$, 
  6. pokud aspon jedna z vetvi vratila TRUE, tak vrat TRUE 


### Dokazovaci systemy

- dokazovaci system
  - formalizuje proces dokazovani
  - dokazovani je:
    - algoritmicky popis procedury, kterou muzeme z nejake teorie postupne dokazat vsechny mozne vyroky

- dukaz formule $\varphi$
  - posloupnost kroku deterministickeho algoritmu, kterymi z nejakych formuli dojdeme k vysledne formuli $\varphi$
  - chceme umet efektivne overit pro nejaky dukaz, zda je korektni

- dokazatelnost
  - pokud z teorie $T$ muzeme dokazat vyrok $\varphi$, pak piseme $T \vdash \varphi$

- pro dokazovaci systemy mame dve dulezite vlastnosti, ktere bychom idealne od dokazovaciho systemu pozadovali

- korektnost
  - chceme pro kazdou $\varphi$ aby $T \vdash \varphi \rightarrow T \models \varphi$
  - tedy, kdyz existuje dukaz formule, tak formule plati ve vsech modelech teorie $T$

- uplnost
  - chceme pro kazdou $\varphi$ aby $T \models \varphi \rightarrow T \vdash \varphi$
  - tedy, pokud nejaka formule plati ve vsech modelech (je dusledkem teorie $T$), tak chceme, aby existoval dukaz, ktery toto dosvedcuje

-  korektnost chceme vzdy
-  dokazovaci system ale muze byt zajimavy i kdyz neni uplny.


#### Tablo 

- je zalozene na dukazu sporem
- je to strom, ktery zacina formuli $\varphi$ o ktere rikame, ze je FALSE (piseme $F\varphi$)
- tablo pak rozsirujeme od korene pomoci pravidel (dana atomickymi tably) dokud kazda vetev neni dokoncena
  - dokoncena vetev muze byt sporna nebo redukovana a bezesporna
- pravidla jsou vymyslena tak, aby kazdy model, ktery se shoduje s korenem tabla, tak aby se shodoval alespon s jednou vetvi tabla po aplikaci libovolneho pravidla

### Rezolucni metoda ve vyrokove logice

- vhodna pro prakticke aplikace
- funguje pro vyroky v CNF (podobne jako SAT)
- zalozena na dukazu sporem
  - vezmeme teorii $T$ ve ktere chceme dokazat vyrok $\varphi$ a uvazime $T \cup \{\neg \varphi \}$
  - ukazeme, ze takova teorie by byla sporna

- pouziva jedine inferencni pravidlo -> **rezolucni pravidlo**

- pravidlo řezu
  - $$\frac{\varphi \vee \psi , \neg \varphi \vee \chi}{\psi \vee \chi}$$
  - co se v tom pravidle řeže?
  - pravidlo zakládá na tom, že nemůže zároveň platit $\varphi$ a $\neg \varphi$ -> tedy abychom splnili obe formule v predpokladu, tak musi prijit napomoc bud $\psi$ nebo $\chi$

- mnozinova reprezentace
  - zjednoduseny zapis formule v CNF
  - jako mnozina klauzuli, kde kazda klauzule je mnozina
  - v podstate tedy akorat misto carek mezi mnozinami si predstavime $\wedge$ a misto carek mezi literaly si predstavime $\vee$

- pro mnozinovou reprezentaci si pak definujeme ohodnoceni $\mathcal{V}$:
  - je to mnozina literalu neobsahujici pro nejakou promennou $x$ jak literal $x$ tak i $\bar{x}$
  - je to uplne ohodnoceni, pokud obsahuje pro kazdy literal $x$ bud $x$ nebo $\bar{x}$
  - pro formuli $S$ je to splnujici ohodnoceni, pokud pro kazdou $C \in S$ plati: $\mathcal{V} \cap C \neq \emptyset$ (tuto krasnou udalost, nastane-li, zapisujeme $\mathcal{V} \models S$)

- rezolucni pravidlo
  - muzeme ho pouzit, pokud mame klauzule $C_1,C_2$ takove, ze $x \in C_1$ a $\bar{x} \in C_2$
  - z techto klauzuli pak odvodime novou klauzuli $C' = (C_1 \setminus \{x\}) \cup (C_2 \setminus \{\bar{x}\})$

### Rezolucni metoda v predikatove logice

- chteli bychom idealne, aby fungoval podobny postup i v predikatove logice
- tam ale mame kvantifikatory a ty nam mohou delat paseku

- pravidlo rezu funguje pro vseobecne kvantifikatory
  - $$\frac{(\forall x)(\varphi(x) \vee \psi(x)), (\forall x)(\neg \varphi(x) \vee \chi(x))}{(\forall x)(\psi(x) \vee \chi(x))}$$

- vsimneme si, ze pro existencni kvantifikator by to nemuselo platit

- budeme tedy chtit dostat co mozna nejvice klauzuli do formy, ze maji pouze univerzalni kvantifikator
  - kdyby univerzalni kvantifikator meli vsechny formule, tak dokonce muzeme postupovat s rezoluci uplne identicky jako ve vyrokove logice

- ne vzdy se vsak dokazeme existencniho kvantifikatoru zbavit
  - co budeme delat v takovem pripade?

## Sémantika

- popisuje objekty, o kterých náš jazyk ze sekce syntaxe mluví

- naším cílem je, umět nějak popsat objekty, které splňují nějakou teorii a odlišit je od těch, které ji nesplňují
  - k tomu si potřebujeme nadefinovat, co to znamená, že formule platí v nějakém modelu
  - model pak platí v teorii, když platí v každé formuli teorie

- jelikož formule může buď platit nebo neplatit, máme dva možné stavy, které budeme simulovat 0 a 1
  - zavedeme si tedy pravdivostní funkci, která z modelu bude vyrábět 0 a 1

### Pravdivostní funkce ve výrokové logice

- pravdivostní funkce formule se definuje rekurzivně
  1. báze je pokud je formule prvovýrok -> vrátíme jen hodnotu na pozici vektoru nul a jedniček, který odpovídá tomu danému prvovýroku (proměnné)
  2. jinak používáme booleovské funkce
       - pro formuli tvaru negace je její pravdivostní funkce složením booleovské negace po aplikaci pravdivostní funkce na neznegovanou formuli
       - pro formuli tvaru spojky -> p.f. je složením booleovské funkce pro danou spojku po aplikaci pravdivostní funkce na oba podvýroky

### Model ve výrokové logice

- model ve výrokové logice
  - vektor nul a jedniček udávající, jaké jsou hodnoty jednotlivých proměnných

- když máme pravdivostní funkci $f$ pro nějaký výrok $\varphi$ a model $m$, tak můžeme spočítat $f_\varphi(m)$ a podle výsledku určit, zda výrok $\varphi$ platí v modelu $m$
  - $\varphi$ platí v $m$ právě tehdy když $f_\varphi(m) = 1$ 
    - jelikož v případě logiky chceme modely vždy prohánět naší krásnou pravdivostní funkcí $f$ a žádnou jinou, tak ji můžeme v zápisu vynechat a píšeme $m \models \varphi$

- tautologie
  - vyrok, ktery plati v kazdem modelu (nehlede na teorii)

- splnitelna formule
  - vyrok, ktery plati v nejakem modelu

- dusledek teorie $T$
  - $\varphi$ je dusledek teorie $T$ pokud pro kazdy model $m$ teorie $T$ mame take $m \models \varphi$

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
  1. mějmě atomickou formuli $\varphi = R(t_1,\ldots,t_n)$ definujeme pravdivostní funkci jako:
       - $f_\varphi(e) = 1$ iff $(t_1[e],\ldots,t_n[e]) \in R^\mathcal{A}$ 
       - $f_\varphi(e) = 0$ iff $(t_1[e],\ldots,t_n[e]) \not\in R^\mathcal{A}$ 
   2. pro formuli vzešlou použitím logických spojek se bude chovat jako ve výrokové logice
   3. nechť máme formuli $\varphi = (\forall x)\varphi'$ potom $f_\varphi(e)$ definujeme jako:
        - $\min_{a \in A}(f'_\varphi(e_{x\rightarrow a}))$ kde $e_{x\rightarrow a} = (e \setminus {(x,b)} )\cup {(x,a)}$ pro nějakou $(x,b) \in e$
        - analogicky s max pro $(\exists x)\varphi'$

- o formuli $\varphi$ pak říkáme, že je pravdivá nebo lživá v nějaké struktuře $\mathcal{A}$
  - pravdivá: platí v každém ohodnocení (znacime $\mathcal{A} \models \varphi$)
  - lživá: neplatí v žádném ohodnocení

- generální uzávěr formule $\varphi$
  - je to formule vzniklá přidáním všeobecného kvantifikátoru pro každou volnou proměnnou z $\varphi$

- struktura $\mathcal{A}$ je modelem teorie $T$ pokud pro každý $\varphi \in T$ máme $\mathcal{A} \models \varphi$
  - třída všech modelů teorie $T$ má pěkné značení $M(T)$

### Platnost v teorii

- s touto terminologií už jsme připraveni definovat si, co znamená, že nějaká formule $\varphi$ platí v teorii $T$
  - $\varphi$ je pravdiva v teorii $T$ kdyz plati v kazdem modelu $\mathcal{A} \in M(T)$
    - zapisujeme jako $T \models \varphi$
  - $\varphi$ je lziva v teorii $T$ kdyz neplati v zadnem modelu $\mathcal{A} \in M(T)$
  - jinak je formule $\varphi$ nezavisla v teorii $T$

- ekvivalentni vyroky $\varphi_1, \varphi_2$
  - pro kazdy model $v$ mame $v \models \varphi_1$ iff $v \models \varphi_2$

## Past exams

### Summer 2024 (model of a theory)

#### (1)

- struktura jazyka $L=\langle\mathcal{R},\mathcal{F}\rangle$
  - mnozina $A$ ... univerzum
  - pro kazdy $R \in \mathcal{R}$ mame $R^{\mathcal{A}} \subseteq A^{ar(R)}$ ... realizace relacnich symbolu
  - pro kazdy $F \in \mathcal{F}$ mame $F^{\mathcal{A}} : A^{ar(F)} \rightarrow A$ ... realizace funkcniho symbolu

- model teorie $T$ je $L$-struktura $\mathcal{M}$ t.z. $\forall \varphi \in T : \mathcal{M} \models \varphi$
  - zda $\mathcal{M} \models \varphi$ se urci dle pravdivostni hodnoty formule $\varphi$ vzhledem k modelu $\mathcal{M}$

#### (2)

(a) $\varphi_1 : \neg(\forall x)(Z(x) \rightarrow S(x)) \wedge (\forall x)(S(x) \rightarrow Z(x))$

(b) $\varphi_2 : (\forall x)(P(x) \rightarrow S(x))$

(c) $\varphi_3 : (\exists x)(P(x) \wedge \neg Z(x))$


#### (3)

$T = \{\varphi_1, \varphi_2\}$ ma model:
- nelze vzit prazdny model jelikoz musi $A \neq \emptyset$
- mozny model je $A = \{a\}$ t.z. $Z(a)$ a nic vice

$T = \{\varphi_1, \varphi_2, \varphi_3\}$ nema model
- budeme postupovat rezoluci -> musime prevest do CNF
  - $\varphi_0 : (\exists x)(Z(x) \wedge \neg S(x))$
  - $\varphi_1 : (\forall x)(\neg S(x) \vee Z(x))$
  - $\varphi_2 : (\forall x)(\neg P(x) \vee S(x))$
  - $\varphi_3 : (\exists x)(P(x) \wedge \neg Z(x))$
- nyni je potreba provest skolemizaci
  - zavedeme konstantni symboly $c_1,c_2$
  - budeme mit nasledujici mnoziny
    - $\{Z(c_1)\},\{\neg S(c_1)\},\{\neg S(x),Z(x)\},\{\neg P(x),S(x)\},\{P(c_2)\},\{\neg Z(c_2)\}$
- nyni budeme opakovane pouzivat pravidlo rezu a chceme ziskat spor (prazdnou mnozinu)
  - odovdime nejprve $\{S(c_2)\}$
  - pote odvodime $\{Z(c_2)\}$
  - diky tomu uz mame spor s $\{\neg Z(c_2)\}$

### Jaro 2023 (skolemizace a modely)

- $\varphi_1$ - “Každý zajíc je rychlejší než nějaká želva.”
- $\varphi_2$ - “Každý je buď zajíc, nebo želva, ale ne obojí.”
- $\varphi_3$ - “Existuje alespoň jeden zajíc a alespoň jedna želva.”

$(\forall x)(\exists y)(Zajic(x) \wedge Zelva(y) \wedge JeRychlejsiNez(x,y))$

$(\forall x)(\neg (Zajic(x) \Leftrightarrow Zelva(x) ))$

$(\exists x)(Zajic(x)) \wedge (\exists x)(Zelva(x))$


