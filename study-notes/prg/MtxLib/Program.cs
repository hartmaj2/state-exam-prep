using static System.Console;
using System.Diagnostics;
using System.Threading;

var sem = new SemaphoreSlim(5);

int tasks_amount = 20;
var rand = new Random();

List<long> numbers_to_factorize = [23_567_385_546, 39_567_385_542, 47_567_385_547, 56_567_385_549];

int fin = numbers_to_factorize.Count;
for (int i = 0; i < tasks_amount - fin; ++i)
{
    numbers_to_factorize.Add(rand.NextInt64(10_000_000_000, 100_000_000_000));
}

Write($"{numbers_to_factorize.Count}\n");

static List<long> FactorizeAndPrint(long number, SemaphoreSlim sem)
{
    sem.Wait();

    Write($"{Thread.CurrentThread.ManagedThreadId} entered \n");

    List<long> factors = [];
    long i = 2; // if this is an integer I get an overflow :)
    while (number != 1)
    {
        if (number % i == 0)
        {
            factors.Add(i);
            number /= i;
            continue;
        }
        i++;
    }

    PrintList(factors);

    sem.Release();

    Write($"{Thread.CurrentThread.ManagedThreadId} exited \n");
    return factors;
}

static void PrintList<T>(List<T> list)
{
    foreach (T elem in list)
    {
        Write($"{elem}, ");
    }
    WriteLine();
}

static void FactorizeWithThreading(List<long> nums_to_fact, SemaphoreSlim sem)
{
    List<Thread> threads = [];

    foreach (var num in nums_to_fact)
    {
        var t = new Thread(() => FactorizeAndPrint(num, sem));
        threads.Add(t);
        t.Start();
    }

    foreach (var t in threads)
    {
        t.Join();
    }
}

static void FactorizeUsingThreadPool(List<long> nums_to_fact, SemaphoreSlim sem)
{
    CountdownEvent countdown = new CountdownEvent(nums_to_fact.Count);
    foreach (var num in nums_to_fact)
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            FactorizeAndPrint(num, sem);
            countdown.Signal();
        });
    }
    countdown.Wait();
}

var stopwatch = new Stopwatch();

stopwatch.Start();

FactorizeWithThreading(numbers_to_factorize,sem);

stopwatch.Stop();
Write($"{stopwatch.ElapsedMilliseconds}\n"); // took 12907 milliseconds

delegate void MyCoolFunc();