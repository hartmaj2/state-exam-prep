# Preparation for Computer architecture and operating system architecture question

## TODOS:
- [ ] try virtual address translation example (from past exams)
- [ ] try example with PIO (from past exams)

## Topics
- [x] Základní architektura počítače, reprezentace čísel, dat a programů.
  - reprezentace a přístup k datům v paměti, adresa, adresový prostor
  - ukládání jednoduchých a složených datových typů
  - základní aritmetické a logické operace

- [x] Instrukční sada, vazba na prvky vyšších programovacích jazyků.
  - Implementovat běžné programové konstrukce vyšších jazyků (přiřazení, podmínka, cyklus, volání funkce)
  pomocí instrukcí procesoru
  - Zapsat běžnou konstrukci vyššího jazyka (přiřazení, podmínka, cyklus, volání funkce), která odpovídá
zadané sekvenci (vysvětlených) instrukcí procesoru

- [x] Podpora pro běh operačního systému.
  - privilegovaný a neprivilegovaný režim procesoru
  - jádro operačního systému

- [x] Rozhraní periferních zařízení a jejich obsluha.
  - Popsat roli řadiče zařízení při programem řízené obsluze zařízení (PIO), pro zadané adresy a funkce vstupních
  a výstupních portů implementovat programem řízenou obsluhu zadaného zařízení (myš, disk)
  - Popsat roli přerušení při programem řízené obsluze zařízení (PIO), na úrovni vykonávání instrukcí popsat
  reakci procesoru (hardware) a operačního systému (software) na žádost o přerušení

- [x] Základní abstrakce, rozhraní a mechanizmy OS pro běh programů, sdílení prostředků a vstup/výstup.
  - neprivilegované (uživatelské) procesy
  - sdílení procesoru
    - procesy, vlákna, kontext procesu a vlákna
    - přepínání kontextu, kooperativní a preemptivní multitasking
    - plánování běhu procesů a vláken, stavy vlákna
  - sdílení paměti
    - Vysvětlit rozdíl mezi virtuální a fyzickou adresou a identifikovat, zda se v zadaném kontextu či frag-
    mentu kódu používá virtuální nebo fyzická adresa
    - Na zadaném příkladu identifikovat a vysvětlit význam komponent virtuální a fyzické adresy (číslo
    stránky, číslo rámce, offset)
    - Pro konkrétní adresy a obsah jednoúrovňové stránkovací tabulky řešit úlohy překladu adres
    - Vysvětlit roli virtuálních adresových prostorů v ochraně paměti procesů a vláken
  - sdílení úložného prostoru
    - soubory, analogie s adresovým prostorem
    - abstrakce a rozhraní pro práci se soubory

- [ ] Paralelismus, vlákna a rozhraní pro jejich správu, synchronizace vláken.
  - časově závislé chyby (race conditions)
  - kritická sekce, vzájemné vyloučení
  - základní sychronizační primitiva, jejich rozhraní a použití
    - zámky
    - aktivní a pasivní čekání

## Overview of computer architecture

### Harvard vs Von Neumann architecture

- Harvard architecture
  - advantages: 
    - can use separate buses for data and code which means we can access data and code simultaneously -> higher speed

- Von Neumann architecture
  - advantages:
    - hardware is multipurpose -> overall cheaper machine
    - code-as-data:
      - code can be compiled by other programs without having to store it using some other bus to the code memory
  - disadvantages:
    - data and code have to be read from the same bus -> can be slower because of this bottleneck

## Representation of data in memory

### Signed vs unsigned numbers
- unsigned are stored normally
- signed numbers are stored s.t. when adding, we don't have to perform any special operation if the number is negative, we simply add the numbers together
- called the two's complement method
- 1000 -> ... -> 1110 -> 1111 -> 0000 -> 0001 -> 0010 -> ... -> 0111

### Aligned vs unaligned accesss
- aligned: data stored at address which is multiple of its alignment (and the alignment is just the size in cases of the primitive types)
- unaligned: we would want to access a double type data starting at 0x0007 for example
- but formally, this is defined in therm of the size of the object that is aligned, if the object size is k, then the access is aligned iff the address is a multiple of k

### Virtual vs physical address

- physical address space refers to the physical RAM (NOT THE DISK!)

- virtual address space
  - somehow managed by a so called MMU (Memory Management Unit)

- advantages:
  - programs A and B can be written to use same addresses but they get translated to different physical addresses (the MMU does the translation using a Active Page Table)
  - program isolation (A and B only see their own address space and cannot access anything else)
  - programs can use even addresses not availible physically without causing a crash (MMU then maps some pages to disk (swap))

### Address space

- address space
  - set of addresses that can be accessed

- virtual address space is implemented using the MMU
  - when the process starts, the OS reads some data from the process to see how many pages it needs
  - then it configures the MMU with a so called page table 
  - page allocation is based on:
    - static program metadata
    - runtime program behavior

### Storing primitive vs composite data types

- primitive data type
  - fixed size
  - usually cpu can operate on them directly (without needing to split them into parts)
  - usually one-to-one correspondence between the bits in program and in physical memory

- composite data type
  - variable size based on what it is composed of
  - sometimes must be padded (for data alignment)

- storing structs in C++
  - inner alignment 
    - each field of ALIGNMENT k must be stored at an address which is a multiple of k
  - outer alignment
    - the whole struct must be stored at address which is a multiple of l where l is the ALIGNMENT of the largest field inside of the struct
  - inner padding
    - added so that the inner alignment is preserved
  - outer padding
    - added so that size of the struct is a multiple of l where l is the ALIGNMENT of the largest field inside the struct

- code to test how alignment really works [link](../../Study/pcos/struct_alignment.c)

### Basic arithmetic and logical operations

- arithmetic operations
  - add, subtract, multiply, divide
  - some processors can also operate on vectors (SIMD - Single Instruction Multiple Data)

- logic operations
  - bitwise and,or,xor
  - shifts, rotations

- shift
  - can be arithmetic or logical
    - both perform same when shifting left (de facto multiplying by two)
    - when shifting right: arithmetic shift preserves sign for signed numbers to preserve the meaning of dividing by two

- CPU flags
  - signal when operations overflow
    - CF (Carry Flag) - unsigned overflow
    - OF (Overflow Flag) - signed overflow 
  - sub vs subs
  - add vs adds 

## Instruction set, connection to concepts from higher level languages

- implement higher language constructions
  - variable assignment, condition, cycle, function call

- figure out what are the corresponding higher language constructions to given processor instructions
  - variable assignment, condition, cycle, function call

- RISC vs CISC
  - reduced/complex instruction set computer
  - RISC:
    - fewer instructions
    - more registers
    - operations just on data in registers (not straight on values stored inside memory)
    - usually no backward compatibility
      - does not need to include old instructions
      - but means that software has to be adjusted for the new versions (cannot run old software on new machine)
  - CISC:
    - more instructions:
      - memory-to-memory - operations that perform something directly on data from memory (no need to load to a register beforehand)


- RISC example instructions:
  - mov r1, #immediate
  - str [addr], r1
  - ldr r1, [addr]
  - sub r3, r2, r1        ; r3 = r2 - r1
  - subs r3, r2, r1       ; same as above but also sets flags
  - b.ne    0x100000364   ; branch according to a flag set by subs, adds or similar

  - mov vs ldr 
    - mov: presun z registru do registru nebo immediate do registru
    - ldr: presun z adresy do registru

### Dissasembly 

- we can run `gcc test.c; objdump --source a.out;` in terminal to see assembler c code

```
Disassembly of section __TEXT,__text:

0000000100000328 <_main>:                               ; address where the main function is stored
100000328: d10043ff     sub     sp, sp, #0x10           ; allocate 16 bytes on the stack
10000032c: 528001c8     mov     w8, #0xe                ; =14
100000330: b9000fe8     str     w8, [sp, #0xc]
100000334: 52800000     mov     w0, #0x0                ; =0
100000338: 910043ff     add     sp, sp, #0x10
10000033c: d65f03c0     ret
```

- line is in format: `<addres of instruction>: <opcode in hex>   <instr_name>    op1, op2, op3 ; <some comment>`


## Operating system runtime support

- CPU modes (privileged vs non-privileged cpu mode)
  - there exist instructions that should not be performed by just any process (related to paging etc.)
    - these instructions should only be perormed by kernel -> privileged, Kernel mode
  - some instructions are safe to be used by any process -> non-privileged, User mode

- Kernel
  - the most low level part of the OS which is responsible for:
    - memory allocation to processes (memory management)
    - process scheduling (process management)
    - device driver
    - system calls

- what part of OS is not Kernel
  - terminal/shell sessions
  - GUI maybe
  - some other tools


## Interface for peripherals and how to use them

### Controller

- serves as a intermediary between CPU and the device 

- why controllers?
  - standardization of the interface (CPU only needs to know how to talk to the controller, not each specific device)
  - frees CPU from having to busy wait for devices for example (the controller can do that instead and than even use DMA so CPU does not have to do anything actively)

- PIO vs DMA
  - PIO (Programmed Input/Output)
    - means that the communication with the controller is done by CPU actively through a program (not necessarily written in a high level language)
  - DMA (Direct Memory Access)
    - the controller writes directly to Main Memory after being configured by CPU, the data transfer is then done by the controller itself

- interrupts
  - can be sent by the controller when some data is ready to be read by the CPU
  - both OS and CPU react to it
    - CPU
      - responds by switching to kernel mode
      - transfers control to interrupt handler of the OS
    - OS
      - identify source and reason for the interrupt
      - read data or transfer data accordingly
      - wake up processes (e.g. a program was sleeping because it was waiting for the output, now it can be woken up)
      - handle errors if necessary


## OS interface and mechanisms for program runtime

- privileged processes (user processes)
  - processes that run in user space
    - user space
      - where application software executes\

- kernel space
  - for kernel processes

### Processor sharing

- process vs thread
  - one process can run in multiple threads, thread is a way to do multiple parts of the process concurrently

- process
  - running program
  - has: address space, system resources etc.

- thread
  - smaller unit of execution inside a process
  - shares: address spaces and resources with the process it runs inside
  - has its own: stack, program counter, registers

- process context
  - everything required to switch between processes 
  - opened files, environment variables
  - virtual memory space (code, heap, global variables)
  - page tables (stored in RAM and managed by MMU, not part of process address space), scheduling info (ready, running, blocked)

- thread context
  - everything required to switch between threads
  - stack pointer
  - program counter
  - registers
  - thread-local storage (stored in RAM)

- context switching
  - why?
    - CPU can't run all processes that require attention at the same time
    - instead it switches between the processes to allow each process to compute for some time and then switches to another process
    - CPU can run SIGLE thread per CORE

- multitasking
  - what: system feature
  - what it does: multiple processes appear to run concurrently
  - how: by context switching handled by the OS
  - related concept: scheduling algorithms

- cooperative vs preemptive mutlitasking
  - cooperative
    - the processes itself decides when to yield control to the OS (but still the OS is involved!)
    - cheaper hardware implementation, harder to write cooperative software
    - used by embedded and real-time systems
  - preemptive
    - OS interrupts the processes by force

- runtime planning of processes and threads
  - by: priority, waiting time, historical behavior
  - can take into account other aspects (did the process yield or had to be terminated from outside last time?)

- thread states
  - running
    - currently executing code
  - blocked
    - waiting for some input or result of other thread etc.
  - ready
    - can start executing when allowed
  - terminated
    - waiting for parent process to reclaim data (exit code etc.)
    - then can release resources (opened files etc.)

### Memory sharing

- paging
  - virtual address space divided into fix-sized **pages** (usually 4kB)
  - physical address space divided into same-sized **frames**
  - os maintains a page table
    - contains mapping: page -> frame | None

- page table
  - each process has its own page table
  - the page table tells the process, where in the RAM it points when using some virtual address

- single vs multilevel paging
  - single-level paging
    - means each process has table where it can look up the mapping: page number -> frame number directly
    - problem: takes more memory since even unused pages have entries in the memory (maybe not filled with frame number but they're there nonetheless)
  - multi-level paging:
    - have a page directory (first level page table)
      - smaller than if we had just a single page table
      - translates page_dir_index -> page_table_starting_physical
    - multiple page tables (second level)
      - only the ones that are currently used have to be allocated -> this saves space 
      - disadvantage: speed (but this is outweighed by TLB - Translation Lookaside Buffer)

- virtual to physical address translation
  - we get virtual address in format: [ page number | offset ]
  - we need to find out what is the frame number corresponding to the page number
  - this can be found in the page table
  - then use the frame number to form physical address as [ frame number | offset ]

- translation for two-level paging
  - derive offset based on page/frame size (e.g. 4KB -> 2^12 -> 12-bit offset) ... O
  - the rest is split equally:
    - first part -> page directory (first-level page table) index ... A
    - second part -> second-level page table index ... B
  - take p.d. index (A) and count this many entries from the p.d. start (this will be given to you)
    - at that index take the data and remove the offset part ... C
  - now look at address C and count B entries away from it to find the first part of the physical address ... D
  - combine D and O ... your final physical address

### Storage sharing

- analogy filesystem vs address space
  - both are linear sequences of bytes
  - so file is linear address space over persistent storage

- files
  - unit of data with which user can interact
    - eg. text document, image, sound file, source code, configuration file, compiled code
  - file type
    - tells the OS how to interpret the data
    - os finds this out by file header (first few bytes of the file)

- file descriptor
  - NOT THE SAME AS FILE HEADER
  - small integer that identifies an open file (probably an address to memory where the metadata is contained)
  - it points to following metadata:
    - current offset in the program (because the program moves across the file as it reads/writes it)
    - access mode (read/write)
    - pointer to other file metadata
  - why so much indirection:
    - multiple processes can work with same file at same time -> only store the information which allows to retrieve the shared file information from a shared memory location

- file handle
  - basically a token of temporary permission to access the file granted by the os
  - has the following usage:
    - track file state (locked etc.)
    - just an abstraction (no need to know where file stored, its format or whatever)

## Parallelism 

TODO: continue with this topic

### Subtopics

- [ ] Paralelismus, vlákna a rozhraní pro jejich správu, synchronizace vláken.
  - časově závislé chyby (race conditions)
  - kritická sekce, vzájemné vyloučení
  - základní sychronizační primitiva, jejich rozhraní a použití
    - zámky
    - aktivní a pasivní čekání