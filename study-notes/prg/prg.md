# Preparation for programming part of the state exam

## TODOs

- [ ] write down past exams that contain quest for this topic

## Topics

- [x] Koncepty pro abstrakci, zapouzdření a polymorfismus.
  - související konstrukty programovacích jazyků
    - třídy, rozhraní, metody, datové položky, dědičnost, viditelnost
  - (dynamický) polymorfismus, statické a dynamické typování
  - jednoduchá dědičnost
    - Ⓥ virtuální a nevirtuální metody v C#
  - vícenásobná dědičnost a její problémy
    - Ⓥ interfaces v C#
  - implementace rozhraní (interface)
  - vhodné použití uvedených konceptů
- [x] Primitivní a objektové typy a jejich reprezentace.
  - číselné a výčtové typy
  - Ⓥ hodnotové a referenční typy v C#
  - Ⓥ reference, imutabilní typy a boxing v C#
- [x] Generické typy a funkcionální prvky (procedurálních programovacích jazyků).
  - Ⓥ generické typy v C# (bez omezení typových parametrů)
  - Ⓥ typy reprezentující funkce v C#
  - lambda funkce a funkcionální rozhraní
- [x] Manipulace se zdroji a mechanizmy pro ošetření chyb.
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

- numeric types (value type)
  ```cs
  // integral types
  sizeof(byte); // 8-bit
  sizeof(short); // 16-bit
  sizeof(int); // 32-bit
  sizeof(long); // 64-bit

  // floating point types
  sizeof(float); // 32-bit
  sizeof(double); // 64-bit
  sizeof(decimal); // 128-bit (for precise floating calculations in decadic numeral system)
  ```

- enumeration types (value type)
  - `enum MY_ENUM { VALUE1, VALUE2, ... }`
  - backed by an integer

- primitive vs object types in C#
  
  - primitive (value types)
    - variable points directly to the data
    - get passed to functions by value
    - e.g. integral types, enum, **struct**

  - object types (reference types)
    - **reference**: address that points to a heap
    - variable only stores a reference to the actual data of the object
    - classes, interfaces, strings, **arrays**, delegates, wrapper types
    - passed by reference

- immutable types
  - not possible to change their internal state
  - e.g. strings, record types (by default, but can be mutable as well)
  - typical misconception: you can assign new value to an immutable variable, you just cannot change the state of the immutable object inside

- **nullable types** (value type)
  - not allocated on heap
  - small overhead (just an additional bool)

- boxing
  - when we pass a primitive value type to a parameter/variable of type object 
  - object is created which wraps the value inside of itself
  - conversions:
    - value -> object: is implicit
    - object -> value: **must be done explicitly**

## Generic types, functional elements of programming languages

### Delegates (reference type)

- data type for passing functions as parameters or storing them as data
- **built-in delegates**
  - `Action<in T1, in T2, ...>` for procedures (no return type)
  - `Func<in T1, in T2, ... ,out TResult>` for functions with return types
- user declared delegates (when we want more control than what the built-in delegates offer)
  - `delegate TResult DELEGATE_NAME(T1 par1, T2 par2)`

- for example you can create a foreach loop over functions and invoke all of them
  ```cs
  static void TestFunction(Func<string, string> func, string str) { /* do domething */;}

  foreach (var func in functions)
  {
      TestFunction(func,name);
  }
  ```

### Lambdas

- anonymous functions (no need to name the function which we are passing to a parameter of delegate type)
- syntax
  - explicitly typed: `(T1 par1, T2 par2, ... ) => { \* some code here *\ }`
  - implicitly typed: `(par1, par2) => { \* some code here *\ }`

## Resource manipulation, error handling mechanisms

### Resource manipulation

- manipulating files, network connections, database connections etc.
- why care:
  - resources like this are non-memory-managed (the GC does not know about them; we want it that way to have control over these things?)
  - must be explicitly released (because it is hard to automate this, GC would not know when to release?)
- using
  - allows to use a reasors inside a block and then have it automatically closed at the end of the block (equivalent to with keyword in Python)
  - the object for which we use it must implement **IDisposable**
  - syntax: `using (var disposableObj = new DisposableClass()) { \* use the disposable class *\ }`
  - improved syntax: `using var disposableObj = new DisposableClass();`
    - then the object gets disposed when the current block ends

### Exceptions
- structured object representing a runtime error and its metadata (type, message, stack trace)
- why:
  - programs don't always work as expected
  - it is good to have well structured information about what went wrong and where it went wrong
  - allows separation of program (business) logic vs error handling logic (catching can be done at a further place from where the error actually happened)
  - more readable code (we clearly show intent; try -> what should happen, catch -> what to do when it goes wrong)
- are thrown using the keyword `throw`
  - if not catched using `try-catch-finally` syntax, they cause the program to crash

- exception handling
  - stopping the propagation of an exception and acting in accordance to it
  - why:
    - we don't want the program to crash (especially with applications which run a long time)
      - crash could mean we lose some data
      - it can be annoying for the user

## Object lifecycle, memory management

### Allocation and deallocation

- automatic -> for objects on stack
- manual or automatic using garbage collection -> object on heap
- static -> objects with lifetime of the entire program
  - in C# keyword `static`

### Initialization

- for classes, initialization done using constructors

- constructors
  - why:
    - enforce that objects get created with a valid internal state
    - define a kind of contract how an object should be created

- base class (inherited) constructor calling
  - when we want to use the parent class constructor
  - syntax: `public MY_CLASS(T1 par1, ...) : base(arg1, arg2, ...)`

### Destruction

- no destructors in C#?
  - but we can implement IDisposable and implement some logic for disposal

### Memory management

- in C# memory cannot be freed explicitly

- reference counting
  - GC counts how many references point to an object
  - when no reference points to it -> gets garbage collected
  - problem: cycles in reference pointers
    - I guess C# GC has some mechanism to detect these cycles
  - NOT USED IN C#, **C# GC uses tracing -> cycles are not a problem**
  - tracing
    - start with roots (statically allocated vars, stack vars, CPU Registers)
    - mark all references reachable from the roots
    - sweep all unreachable objects

- garbage collector
  - takes care of automatic deallocation of object on the heap
  - why:
    - heap is big but still limited
    - since we cannot deallocate manually in C#, we need this to be done automatically
  - only run when necessary (if we don't allocate much, it doesn't need to run at all)
  - the heap is split into three layers
    - one for short lived object, medium lived object, long lived objects
    - the difference between the layers is, how often they get garbage collected

## Threads and synchronization

## Implementation of basic elements of object oriented languages

## Native and interpreted runtime, compilation, program linking

## Past exams

### Spring 2025 (matrix calculation library)

- [example solution](../../study-notes/prg/MtxLib/Program.cs)

- naming conventions
  - `interface INeco`
  - Pascal case for functions

- inheritance
  - `class SUB : SUPER`

- generic type syntax:
  - `class NECO<T> where T : INecoJineho<T>`

- overloaded operators
  - `public static RETURN_TYPE operator SYMBOL(T1, T2)`
  - need to be declared in the class of the parameter (unary types)

- idioms
  - `record`
    - provides you with default implementations of field
    - provides basic functions like ToString etc.
  - `=>`
    - allows you to write a one-liner body of your function
  - `var`
    - automatically derives type of whatever goes into the variable

### Summer 2024 (semaphores)

### Autumn 2024 (representation of types)

### Spring 2023 - i (object design)

### Autumn 2023 (architecture of pc's and os's)

### Autumn 2022 (object design)

