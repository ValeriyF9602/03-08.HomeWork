/******************************************************

Задача 58
Задайте две матрицы. Напишите программу, которая будет 
находить произведение двух матриц.

Например, даны 2 матрицы:

2 4 | 3 4
3 2 | 3 3

Результирующая матрица будет:

18 20
15 18

******************************************************/


/*

Предисловие

n x m * m x k = n x k

*/


int[] RandLength() 
{
    int[] array = new int[3];
    Random rand = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = rand.Next(2, 6);
    }
    return array;
}

int[,] GenerateMatrix(int rows, int cols, int leftRange, int rightRange) // Метод генерации матрицы целых чисел
{
    int[,] matrix = new int[rows, cols];
    Random rand = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }

    return matrix;
}

void MultiplyMatrices(int[,] matrixA, int[,] matrixB, string text) // Метод перемножения матриц
{
    int[,] matrixAB = new int[matrixA.GetLength(0), matrixB.GetLength(1)]; // (n x m * m x k = n x k)

    if (matrixA.GetLength(1) == matrixB.GetLength(0)) // количество столбцов первой матрицы  =  количество строк второй матрицы
    {
        Console.WriteLine($"{text} ({matrixAB.GetLength(0)} x {matrixAB.GetLength(1)}):");
        Console.WriteLine();

        int slotSum;
        for (int i = 0; i < matrixAB.GetLength(0); i++)
        {
            for (int j = 0; j < matrixAB.GetLength(1); j++)
            {
                slotSum = 0;

                for (int k = 0; k < matrixA.GetLength(1); k++)
                {
                    slotSum += matrixA[i, k] * matrixB[k, j];
                }
                Console.Write($"{slotSum}\t");
            }
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Условие умножения матриц не выполнено!");
    }
}

void PrintMatrix(int[,] matrix, string text) // Метод вывода матрицы целых чисел
{
    Console.WriteLine($"{text} ({matrix.GetLength(0)} x {matrix.GetLength(1)}):");
    Console.WriteLine();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}


int[] size = RandLength();

Console.WriteLine();
int[,] a = GenerateMatrix(size[1], size[0], 0, 9);
PrintMatrix(a, "Матрица A");

Console.WriteLine();
int[,] b = GenerateMatrix(size[0], size[2], 0, 9);
PrintMatrix(b, "Матрица B");

Console.WriteLine();
MultiplyMatrices(a, b, "Матрица AB");