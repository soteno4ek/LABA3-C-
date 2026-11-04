using System;

internal class Matrix
{
    private int[,] _data;

    public Matrix(int n, int m)
    {
        if (n <= 0 || m <= 0)
        {
            throw new ArgumentException("Размер > 0");
        }
        else
        {
            _data = new int[n, m];
        }
    }
    public Matrix(int n, int m, bool isKeyBoard) : this(n, m)
    {
        Validator v = new Validator();
        int diff = 0;
        int i = 0;
        int j = 0;

        for (diff = m - 1; diff >= -(n - 1); diff--)
        {
            for (i = 0; i < n; i++)
            {
                j = i + diff;
                if (j >= 0 && j < m)
                {
                    _data[i, j] = v.ReadInt("Элемент: ");
                }
            }
        }
    }

    public Matrix(int n, bool isRandom) : this(n, n)
    {
        Random rnd = new Random();
        int i = 0;
        int j = 0;
        int k = 0;
        int temp = 0;

        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                _data[i, j] = rnd.Next(-50, 50);
            }
        }

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n - 1; i++)
            {
                for (k = 0; k < n - i - 1; k++)
                {
                    if (_data[k, j] < _data[k + 1, j])
                    {
                        temp = _data[k, j];
                        _data[k, j] = _data[k + 1, j];
                        _data[k + 1, j] = temp;
                    }
                }
            }
        }
    }

    public Matrix(int n, string spiralMode) : this(n, n)
    {
        int current = 1;
        int row = n / 2;
        int col = n / 2;
        int stepLength = 1;
        int direction = 0;
        int i = 0;
        int j = 0;

        _data[row, col] = current;

        while (current < n * n)
        {
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < stepLength; j++)
                {
                    if (direction == 0) col--;
                    else if (direction == 1) row++;
                    else if (direction == 2) col++;
                    else if (direction == 3) row--;

                    if (row >= 0 && row < n &&
                        col >= 0 && col < n)
                    {
                        current++;
                        _data[row, col] = current;
                    }

                    if (current >= n * n) return;
                }
                direction = (direction + 1) % 4;
            }
            stepLength++;
        }
    }

    public int Rows
    {
        get { return _data.GetLength(0); }
    }

    public int Columns
    {
        get { return _data.GetLength(1); }
    }

    public override string ToString()
    {
        string result = "";
        int i = 0;
        int j = 0;
        for (i = 0; i < Rows; i++)
        {
            for (j = 0; j < Columns; j++)
            {
                result += _data[i, j] + "\t";
            }
            result += "\n";
        }
        return result;
    }

    public void PrintFibonacci()
    {
        int f1 = 1;
        int f2 = 1;
        int need = f1;
        int count = 0;
        int next = 0;
        int i = 0;
        int j = 0;

        for (i = 0; i < Rows; i++)
        {
            for (j = 0; j < Columns; j++)
            {
                Console.Write(_data[i, j] + " ");
                count++;
                if (count == need)
                {
                    Console.WriteLine();
                    count = 0;
                    next = f1 + f2;
                    f1 = f2;
                    f2 = next;
                    need = f1;
                }
            }
        }
        Console.WriteLine();
    }

    public Matrix Transpose()
    {
        Matrix result = new Matrix(Columns, Rows);
        int i = 0;
        int j = 0;

        for (i = 0; i < Rows; i++)
        {
            for (j = 0; j < Columns; j++)
            {
                result._data[j, i] = _data[i, j];
            }
        }
        return result;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        Matrix result = new Matrix(a.Rows, a.Columns);
        int i = 0;
        int j = 0;

        for (i = 0; i < a.Rows; i++)
        {
            for (j = 0; j < a.Columns; j++)
            {
                result._data[i, j] = a._data[i, j] + b._data[i, j];
            }
        }
        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        Matrix result = new Matrix(a.Rows, a.Columns);
        int i = 0;
        int j = 0;

        for (i = 0; i < a.Rows; i++)
        {
            for (j = 0; j < a.Columns; j++)
            {
                result._data[i, j] = a._data[i, j] - b._data[i, j];
            }
        }
        return result;
    }

    public static Matrix operator *(int number, Matrix a)
    {
        Matrix result = new Matrix(a.Rows, a.Columns);
        int i = 0;
        int j = 0;

        for (i = 0; i < a.Rows; i++)
        {
            for (j = 0; j < a.Columns; j++)
            {
                result._data[i, j] = number * a._data[i, j];
            }
        }
        return result;
    }
}