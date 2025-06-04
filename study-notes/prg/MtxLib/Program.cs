using System.Runtime.CompilerServices;

static void OperateOn(Element elem, Operation op)
{
    op.Call(elem);
    switch (elem)
    {
        case Type type:
            foreach (var field in type.fields) { OperateOn(field, op); }
            foreach (var method in type.methods) { OperateOn(method, op); }
            break;
    }
}

Type cislo = new Type("Cislo", [], []);
Type typ1 = new Type("Hovno", [new Method("Smrdim",null,null)], [new Field("smrdivost",cislo)]);

PrintName printitko = new PrintName();

OperateOn(typ1, printitko);

interface Operation
{
    public void Call(Element el);
}


abstract record class Element(string name);

record class Type(string name, List<Method>? methods, List<Field>? fields) : Element(name);

record class Method(string name, Type? returnType, List<Type>? parameterTypes) : Element(name);

record class Field(string name, Type? type) : Element(name);

class PrintName : Operation
{
    public void Call(Element el)
    {
        switch (el)
        {
            case Type t:
                Console.WriteLine($"I am {el.name}");
                break;
            case Field f:
                Console.WriteLine($"I am {el.name}");
                break;
            case Method m:
                Console.WriteLine($"I perform {el.name}");
                break;

        }
    }
}