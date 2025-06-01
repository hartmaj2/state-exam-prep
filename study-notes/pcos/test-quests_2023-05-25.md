# Otázka #1 — CPU ISA

Co je součástí ISA (Instruction Set Architecture) u CPU?

1) linkování programu
2) souborový systém
3) stav (kontext) vlákna
4) instrukční sada
5) algoritmy alokace paměti

# Otázka #2 – Generování instrukcí

Vyberte fragment kódu jazyka C, který nejlépe odpovídá následujícím instrukcím:

```
    ld   $t0,[a]      ; load a
    ld   $t1,[b]      ; load b
    add  $t2=$t0,$t1  ; addition
    ld   $t0,[c]      ; load c
    ld   $t1,[d]      ; load d
    add  $t3=$t0,$t1  ; addition
    mul  $v0=$t2,$t3  ; multiplication
```

1) a + b * c + d
2) (a + b) * (c + d)
3) a + (b << c) * d
4) d * (a << b) + c
5) (a + c) * (b + d)
 
# Otázka #3 – Využití asociativní paměti pro cache

Cache pro instrukce a data v CPU je implementována pomocí asociativní paměti, pro kterou platí

1) klíčem je virtuální adresa, hodnotou je obraz paměti (cache line), vyhledává se v čase O(log n)
2) fyzická adresa indexuje položku, hodnotou je virtuální adresa, přístup je v konstantním čase
3) klíčem je fyzická adresa, hodnotou je obraz paměti (cache line), vyhledává se v konstantním čase
4) klíčem je fyzická adresa, hodnotou je obraz paměti (cache line), vyhledává se v čase O(n)
5) klíčem je virtuální adresa, hodnotou je obraz paměti (cache line), vyhledává se v konstantním čase

# Otázka #4 – Zarovnání složených typů

Mějme deklarovaný následující typ struktury S a proměnnou arr typu pole vytvořené z této struktury:

```
  struct S {
    int       count;
    char      letter;
    double    precise;
  };
  S arr[20];
```

Velikosti základních typů jsou: double 8B (64 bitů), int 4B (32 bitů) a char 1B (8 bitů).

Spočítejte posunutí (offset) v bajtech položky arr[9].letter od začátku pole arr.

# Otázka #5 – Překladač

Překladač (programovacích jazyků) přeloží

1) všechny zdrojové kódy na platné a správně použité instrukce cílového CPU
2) všechny zdrojové kódy a vyřeší jejich relokace ve všech modulech projektu
3) všechny zdrojové kódy na instrukce cílového CPU a pospojuje je do spustitelného programu
4) všechny korektní zdrojové kódy na platné a správně použité instrukce cílového CPU a pospojuje je do spustitelného programu
5) všechny korektní zdrojové kódy na platné a správně použité instrukce cílového CPU, při špatném vstupu ohlásí všechny zjištěné chyby

# Otázka #6 – Alokace souvislého bloku paměti

Heap programu (prostor pro dynamickou alokaci paměti) má následující vlastnosti:

- na začátku máme jeden prázdný blok o velikosti 2 MiB na adrese 0xa0000
- pro alokaci se používá algoritmus first-fit, který začíná alokovat od počátku bloku (tj. od 0xa0000)
- heap používá alokaci po blocích velikosti 32 B

Proces provádí alokaci a dealokaci paměti na heapu v následující sekvenci (alokované úseky paměti jsou označeny pro přehlednost písmeny, která jsou následně použita pro identifikaci uvolňované paměti):
```
A = alloc 1230 B
B = alloc 42 B
C = alloc 314 B
D = alloc 640 B
free A
E = alloc 4 KiB
free D
free C
F = alloc 1234 B
```
Spočítejte, na jaké adrese bude umístěný blok F. Pokud zjistíte, že blok F nelze alokovat, uveďte jako odpověď číslo 0.

# Otázka #7 – Překlad adresy

Předpokládejme teoretickou paměťovou architekturu **YA-16**, kde virtuální i fyzický prostor používá `16`\-bitové adresování. Pro překlad adres se používá 2-úrovňové stránkování s `64 B` stránkami. Záznamy ve stránkovacích tabulkách (které mají také 16-bitů) využívají offsetové bity pro přidružené příznaky (podobně jako IA-32), nejméně významný bit je použit jako **příznak platnosti** (tj. `1` = záznam je platný, `0` = záznam není platný).

Stránkovací tabulka 1. úrovně se nachází na adrese **`0x9f40`**. **Proveďte překlad virtuální adresy `0x5c89` (`0b0101110010001001` binárně) na fyzickou adresu.**

Vaše odpověď musí obsahovat právě **2 čísla** (v následujícím pořadí):

1.  Kompletní fyzická adresa odpovídající zadané virtuální adrese.
2.  Fyzická adresa stránkovací tabulky 2. úrovně, která byla při překladu použita.

Pokud některou z adres není možné určit (mapování neexistuje), odpovězte `-1` namísto adresy. Připomeňme si, že v některých případech je možné, aby virtuální adresa neměla překlad (první odpověď bude `-1`), ale stále existovala platná adresa pro druhou odpověď (tj. druhé číslo nebude `-1`).

Výpis fyzické paměti:

Fyzická paměť je příliš velká, aby bylo možné ji zobrazit najednou. Upravte adresu na prvním řádku, abyste nasměrovali výpis na jinou část paměti.

*(V testu je interaktivní prohlíč paměti, který zobrazuje data rovnou po 16-bitových číslech, aby se nemusela řešil endianita. Vykopíroval jsem relevantní úseky.)*

|        | +0x0   | +0x2   | +0x4   | +0x6   | +0x8   | +0xa   | +0xc   | +0xe   |
| ------ | ------ | ------ | ------ | ------ | ------ | ------ | ------ | ------ |
| 0x9f40 | 0x2e85 | 0xe209 | 0x3591 | 0xef49 | 0xa391 | 0xf751 | 0x2785 | 0x5945 |
| 0x9f50 | 0xa991 | 0x32e1 | 0x0419 | 0xded9 | 0x9e31 | 0xc711 | 0x17fe | 0x444e |
| 0x9f60 | 0xb5e4 | 0xd28c | 0x8b91 | 0xa791 | 0x2821 | 0x6951 | 0xbd99 | 0x2311 |
| 0x9f70 | 0xd0e1 | 0x7c61 | 0x3151 | 0xef85 | 0x2f0d | 0xa2b1 | 0xa3d1 | 0x7e99 |

|        | +0x0   | +0x2   | +0x4   | +0x6   | +0x8   | +0xa   | +0xc   | +0xe   |
| ------ | ------ | ------ | ------ | ------ | ------ | ------ | ------ | ------ |
| 0x0dec | 0x1e89 | 0xf021 | 0x19b4 | 0x8dee | 0xbd3c | 0xaa38 | 0x5fd1 | 0xbb32 |
| 0xded0 | 0xa8e6 | 0xe044 | 0x56c9 | 0xd352 | 0x014d | 0xc8d4 | 0xb371 | 0x8a09 |
| 0xdee0 | 0x9380 | 0xcb6c | 0x8009 | 0x2a38 | 0x284d | 0x7e4d | 0xa4f6 | 0xb638 |
| 0xdef0 | 0x3d0c | 0xcb49 | 0xe285 | 0x5e51 | 0xe73e | 0x8d59 | 0x3c40 | 0xe049 |

# Otázka #8 – Přerušení

Otázka #8 – Přerušení

1) linkování programu
2) plánování vláken
3) vzájemné zablokování několika vláken (deadlock)
4) předání parametrů při volání funkce
5) výjimky

# Otázka #9 – File Allocation Table (FAT)

Mějme souborový systém FAT16 s velikostí bloků `4` KiB. Níže je uvedena relevantní část FAT tabulky.

| offset |   +0 |   +1 |   +2 |   +3 |   +4 |   +5 |   +6 |   +7 |   +8 |   +9 |
| ------ | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- |
| 10     | `14` | `12` | `52` | `48` | `-1` | `24` | `0`  | `25` | `57` | `-1` |
| 20     | `29` | `11` | `-1` | `30` | `-1` | `20` | `41` | `37` | `35` | `19` |
| 30     | `26` | `0`  | `46` | `22` | `-1` | `18` | `54` | `32` | `34` | `0`  |
| 40     | `13` | `21` | `27` | `33` | `15` | `0`  | `40` | `10` | `-1` | `0`  |
| 50     | `0`  | `23` | `55` | `17` | `42` | `-1` | `38` | `47` | `43` | `0`  |

Struktura FAT je již načtená v RAM a přístupy do ní nebudou způsobovat čtení z disku.

Soubor `liball.so` je dlouhý `37382` B a začíná na bloku `51`. Aplikace soubor otevře, provede operaci **seek** na pozici `22000` a operací **read** přečte `8` KiB. Uveďte indexy všech bloků (ve správném pořadí), které budou touto operací načteny z disku.

# Otázka #10 – Semafor

Označ tvrzení, která platí pro synchronizační primitivum zvané semafor.

1) Operace DOWN má být zavolána na začátku kritické sekce, operace UP na konci kritické sekce.
2) Operace DOWN se zablokuje tehdy, pokud je čítač na 0.
3) Operace UP se nikdy nezablokuje.
4) Použití semaforů nemůže způsobit zablokování (deadlock).
5) Je to aktivní synchronizační primitivum.


1230 + 42 + 314 + 640