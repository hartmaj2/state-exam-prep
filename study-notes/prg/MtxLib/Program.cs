class Program
{
    private static Semaphore sem1;
    private static Semaphore sem2;
    private static void f1()
    {
        Console.Write("One");
        sem1.Release();
        sem2.WaitOne();
        Console.Write("Three");
        sem1.Release();
        sem2.WaitOne();
        Console.Write("Five");
    }

    private static void f2()
    {
        Thread.Sleep(1000);
        sem1.WaitOne();
        Console.Write("Two");
        sem2.Release();
        sem1.WaitOne();
        Console.Write("Four");
        sem2.Release();
        
    }

    static void Main(string[] args)
    {
        sem1 = new Semaphore(0, 1);
        sem2 = new Semaphore(0, 1);
        Thread t1 = new Thread(f1);
        
        Thread t2 = new Thread(f2);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
 }