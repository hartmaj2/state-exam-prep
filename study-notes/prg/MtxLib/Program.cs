using System.Numerics;
using static System.Console;

IMatrix<int> sparseMtx = new SparseMatrix<int>(10, 10);

WriteLine(sparseMtx.GetElem(1, 1));

/// <summary>
/// Matrix contract:
/// - get height, width
/// - getElem(x,y)
/// - arithmetic operations (addition, subtraction, multiplicaiton etc.)
/// </summary>
interface IMatrix<T> where T : INumber<T>
{
    int GetHeight();

    int GetWidth();

    T GetElem(int x, int y);

}

readonly record struct Coord(int X, int Y);

/// <summary>
/// Represents a matrix that is sparse i.e. consists of mostly zeroes. 
/// Comment the implementation.
/// Implement only the interface methods.
/// What is the big oh space complexity of this matrix representation
/// </summary>
/// <typeparam name="T"> Element of a field to be used inside the matrix </typeparam>
record class SparseMatrix<T>(int Height, int Widht) : IMatrix<T> where T : INumber<T>
{

    // will have a list with mapping -> location to value
    private readonly Dictionary<Coord, T> _elems = [];

    public T GetElem(int x, int y)
    {
        return T.AdditiveIdentity; // this is BEAUTIFUUUUUL
    }

    public void SetElem(int x, int y, T val) => _elems.Add(new Coord(x, y), val);

    public int GetHeight() => Height;

    public int GetWidth() => Widht;

    public static int operator !(SparseMatrix<T> mtx)
    {
        return 14;
    }


}

/// <summary>
/// Factory pattern:
/// - class that creates instances of other classes
/// - why is it useful?
///     - uses polymorphism so we can have just a single method with return type of the superclass
///     - then the factory can decide which concrete implementation of the supertype it should return
/// </summary>
static class MatrixFactory
{

    public static IMatrix<int> GetIdealMatrix(string mtxFilename)
    {
        var coords = GetCoords(mtxFilename);
        if (IsSparse(mtxFilename))
        {
            return new SparseMatrix<int>(coords.X, coords.Y);
        }
        return new DenseMatrix<int>(coords.X, coords.Y);
    }

    private static Coord GetCoords(string mtxFilename)
    {
        throw new NotImplementedException();
    }

    private static bool IsSparse(string mtxFilename)
    {
        throw new NotImplementedException();
    }
}

// HYPOTHETICAL CODE WITH NO IMPLEMENTATION PROVIDED
record class DenseMatrix<T>(int Height, int Widht) : IMatrix<T> where T : INumber<T>
{
    public T GetElem(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int GetHeight()
    {
        throw new NotImplementedException();
    }

    public int GetWidth()
    {
        throw new NotImplementedException();
    }

    public void Print()
    {
        throw new NotImplementedException();
    }
}

