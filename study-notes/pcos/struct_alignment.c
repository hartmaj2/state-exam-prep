/*
*   This program serves for purposes of testing, how much memory a given struct will take
*   Can also be used to see, what address will a given struct be stored at to see if it must be a multiple of certain number
*   We can also try to see, what are the inner paddings inside of the struct
*/
#include<stdio.h>

/// @brief Tests whether outer alignment can really be different from the size of the struct
void test_small_struct_alignment()
{
    char b; // comment or uncomment to see how the Small struct can be at non-multiples of 2 even though its size is 2 (because sometimes alignment != size)

    struct Small { 
        char u;
        char v;
    };

    struct Small s;
    printf("Address of small struct: %p\n",&s);
}

/// @brief Tests how struct inside of a different struct behaves with respect to inner padding
void test_inner_padding_multiple_structs()
{

    char a; // comment or uncomment to see if the struct Inner can lie at an address which is a multiple of 4

    // size: 8B
    // inner alignment 3b before y
    // the struct should begin at an address which is a multiple of 4
    struct Inner {
        char x;
        int y;
    };

    struct Inner i;

    printf("Size of the Inner struct: %lu\n",sizeof(struct Inner));
    printf("Address of x: %p\n",&i.x);
    printf("Address of y: %p\n",&i.y);
    printf("\n");

    // size: 20B
    // alignment: 4B
    // inner padding 3B before b
    // outer padding of 3B
    struct Outer {
        char a;
        struct Inner b;
        int c;
        char d;
    };

    struct Outer o;

    printf("Size of the Outer struct: %lu\n",sizeof(struct Outer));
    printf("Address of a: %p\n",&o.a);
    printf("Address of b: %p\n",&o.b);
    printf("Address of c: %p\n",&o.c);
    printf("Address of d: %p\n",&o.d);
    printf("\n");

}

/// @brief Simple test to see whether padding is really added before bigger types that come after small types
void test_inner_padding()
{

    // size: 24 B
    // outer alignment: 8B
    // outer padding: 4B
    struct S {
        char type;
        double deviation; // double is 64-bit
        int count; // int is 32-bit
    };

    struct S s;

    printf("Size of the struct is %lu bytes.\n",sizeof(struct S));

    printf("Address of the struct is: %p\n",&s);
    printf("Address of type field is: %p\n",&s.type);
    printf("Address of deviation field is: %p\n",&s.deviation);
    printf("Address of count field is: %p\n",&s.count);
    // TODO: test where the inner fields are stored relative to each other

}

void test_array_of_structs()
{

    struct S {
    char type;
    double deviation; // double is 64-bit
    int count; // int is 32-bit
    };

    int size = 20; // size of the array we will create
    struct S sa[size]; // create array of structs

    void* start_ptr = &sa[0];
    void* end_ptr = &sa[3].count;

    int difference = end_ptr - start_ptr;

    printf("The address of the start is: %p\n",(void*) start_ptr);
    printf("The address of the end is %p\n",(void*)end_ptr);

    printf("The offset in bytes between the two addresses is %d\n",difference);

    printf("The size of the struct is %lu bytes",sizeof(struct S));

}

int main()
{

    test_inner_padding_multiple_structs();  

    return 0;
}

