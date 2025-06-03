# Preparation for programming part of the state exam

## TODOs

- [ ] write down past exams that contain quest for this topic

## Topics

- [ ] Koncepty pro abstrakci, zapouzdření a polymorfismus.
  - související konstrukty programovacích jazyků
    - třídy, rozhraní, metody, datové položky, dědičnost, viditelnost
  - (dynamický) polymorfismus, statické a dynamické typování
  - jednoduchá dědičnost
    - Ⓥ virtuální a nevirtuální metody v C#
  - vícenásobná dědičnost a její problémy
    - Ⓥ interfaces v C#
  - implementace rozhraní (interface)
  - vhodné použití uvedených konceptů
- [ ] Primitivní a objektové typy a jejich reprezentace.
  - číselné a výčtové typy
  - Ⓥ hodnotové a referenční typy v C#
  - Ⓥ reference, imutabilní typy a boxing v C#
- [ ] Generické typy a funkcionální prvky (procedurálních programovacích jazyků).
  - Ⓥ generické typy v C# (bez omezení typových parametrů)
  - Ⓥ typy reprezentující funkce v C#
  - lambda funkce a funkcionální rozhraní
- [ ] Manipulace se zdroji a mechanizmy pro ošetření chyb.
  - správa životního cyklu zdrojů v případě výskytu chyb
    - Ⓥ using v C#
  - konstrukce pro obsluhu a propagaci výjimek
- [ ] Životní cyklus objektů a správa paměti.
  - alokace (alokace statická, na zásobníku, na haldě)
  - inicializace (konstruktory, volání zděděných konstruktorů)
  - destrukce (destruktory, finalizátory)
  - explicitní uvolňování objektů, reference counting, garbage collector
- [ ] Vlákna a podpora synchronizace.
  - reprezentace vláken v programovacích jazycích
  - specifikace funkce vykonávané vláknem a základní operace na vlákny
  - časově závislé chyby a mechanizmy pro synchronizaci vláken
- [ ] Implementace základních prvků objektových jazyků.
  - základní objektové koncepty v konkrétním jazyce
  - implementace a interní reprezentace primitivních typů
  - implementace a interní reprezentace složených typů a objektů
  - implementace dynamického polymorfismu (tabulka virtuálních metod)
- [ ] Nativní a interpretovaný běh, řízení překladu a sestavení programu.
  - reprezentace programu, bytecode, interpret jazyka
  - just-in-time (JIT) a ahead-of-time (AOT) překlad
  - proces sestavení programu, oddělený překlad, linkování
  - staticky a dynamicky linkované knihovny
  - běhové prostředí procesu a vazba na operační systém

## Concepts for abstraction, encapsulation and polymorphism

- [ ] Koncepty pro abstrakci, zapouzdření a polymorfismus.
  - související konstrukty programovacích jazyků
    - třídy, rozhraní, metody, datové položky, dědičnost, viditelnost
  - (dynamický) polymorfismus, statické a dynamické typování
  - jednoduchá dědičnost
    - Ⓥ virtuální a nevirtuální metody v C#
  - vícenásobná dědičnost a její problémy
    - Ⓥ interfaces v C#
  - implementace rozhraní (interface)
  - vhodné použití uvedených konceptů

### Concepts for abstraction

- functions !!! (procedural abstraction)
  - also concept for abstraction <- we don't have to know about its inner implementation in order to use it
  - function
    - should return a value 
    - pure function: no side-effects and two identical inputs should yield identical result
  - procedure
    - can have side-effects and does not have to return a value
  - subroutine
    - general term for both of the two above

- for each loops etc. (control abstraction)
  - we do not have to care about details of the loop on the machine (no counter, or checking that we reached end of the list)

- classes
  - **defines common structure**
  - represent an abstract notion of something that should be used in program
  - instances of it can be created and are called objects
  - why (only reasons that have to do with abstraction):
    - easier to think about them
      - we can just think about methods and fields and how they should work without having to implement them right away
      - can have named fields that belong to the object
    - can have methods which can be used but implemented later (we don't need to worry about the concrete things)

- abstract classes
  - **defines common structure and partial contract**
  - **cannot be instantiated**
  - hybrid between normal class and interface
  - means that some methods are left unimplemented with the intention, that whatever concrete object that inherits the class has to provide implementation or delegate the implementation to some further child

- interfaces
  - **enforces a full contract**
  - represent some contract (i.e. how a thing must behave)
  - so then we are guaranteed that anything that implements this contract can do certain things
  - allows us to design the contracts and work with them without knowing the concrete implementation

### Concepts for encapsulation

- **bundling**
  - way to bundle related data together so they are not spread across the program (easier to work with the program without getting lost in the code)

- **data integrity**
  - valid internal state is protected by disallowing modification of private data from outside

- classes
  - objects store their data **and behavior**
  - visibility settings
    - private
      - for information that we do not want to be accessed from outside of the object (maybe just some inner details)
      - it is more secure -> nobody can accidentally change the value from code outside of the class
      - also helps effective coding -> autocomplete does not show us irrelevant fields
    - protected (has to do with inheritance)
    - public
      - for methods that should be called on the object from outside

- interfaces
  - **encapsulation doesn't apply on them directly**
  - they facilitate and enforce data hiding (by having object of interface type, we cannot get to internal data of the class implementing that interface) -> encapsulation indirectly

### Concepts for polymorphism

- polymorphism
  - related to abstraction (because if we know an object of some type can do something, we can call that on all children classes without having to be able to know how they implement it)
  - means that a method called an a class can do different things based on what concrete inherited type is stored inside it
  - why:
    - code reuse
      - if we know some class is similar like another (just extended) we can just use inheritance to add more features without having to copy everything
      - if we have multiple classes that do similar thing (for example peaple with some salary), then we don't have to deal with each one of them in specific way but can use their shared interface on all of them 
    - modularity
      - we can add similar classes with same interface and than later even change the implementation inside without having to be able to rewrite the code that uses it
    - maintainability
      - reduce branching (we don't need to call different functions based on the subtype by asking for the type using an if)
      - method overloading: we can write multiple add,print functions with same name and the compiler dispatches the right one (in the future, if the type we called the function on changes, we do not have to rewrite the function name)

- types of polymorphism
  - **ad-hoc polymorphism** (compile time)
    - method overloading: mutliple methods can have the same name but different list of parameters
    - operator overloading: different operations performed based on the data types involved in the operation
  - **parametric polymorphism** (compile time)
    - generic methods or generic classes
      - we use a variable that can stand for multiple related types (type variable)
    - templates in C++
  - **subtype polymorphism** (runtime)
    - we can call functions on supertype variables without knowing what the concrete subtype will be
    - also each subtype can have the function implemented in a different way
    - method overriding: special type of polymorphism where a subclass provides a new implementation even though the superclass already had some kind of implementation 
      - **dynamic dispatch**: the method by which overriden method calls are resolved at runtime (what concrete implementation should be called?)

## Primitive and object types, their representation

## Generic types, functional elements of programming languages

## Resource manipulation, error handling mechanisms

## Object lifecycle, memory management

## Threads and synchronization

## Implementation of basic elements of object oriented languages

## Native and interpreted runtime, compilation, program linking

## Past exams

### Spring 2025 (matrix calculation library)

### Summer 2024 (semaphores)

### Autumn 2024 (representation of types)

### Spring 2023 - i (object design)

### Autumn 2023 (architecture of pc's and os's)

### Autumn 2022 (object design)

