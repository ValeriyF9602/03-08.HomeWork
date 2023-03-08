/****************************************************************

Задача 62
Напишите программу, которая заполнит спирально массив 4 на 4.

Например, на выходе получается вот такой массив:

01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

****************************************************************/


int[,] GenerateSpiralMatrix() // Генерация спирально заполненной матрицы
{
    Random rand = new Random();
    int[,] matrix = new int[rand.Next(4, 5), rand.Next(4, 5)];
    // по условию 4 на 4, но этот метод заполнит массивы и других размеров
    int num = 1;

    for (int step = 0; num <= matrix.Length; step++)
    {

        for (int i = step; i < matrix.GetLength(1) - step; i++)
        {
            if (num > matrix.Length) return matrix;
            matrix[step, i] = num;
            num++;
        }
        for (int i = step + 1; i < matrix.GetLength(0) - step; i++)
        {
            if (num > matrix.Length) return matrix;
            matrix[i, matrix.GetLength(1) - step - 1] = num;
            num++;
        }
        for (int i = matrix.GetLength(1) - step - 2; i >= step; i--)
        {
            if (num > matrix.Length) return matrix;
            matrix[matrix.GetLength(0) - step - 1, i] = num;
            num++;
        }
        for (int i = matrix.GetLength(0) - step - 2; i > step; i--)
        {
            if (num > matrix.Length) return matrix;
            matrix[i, 0 + step] = num;
            num++;
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix) // вывод матрицы целых чисел
{
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


int[,] myMatrix = GenerateSpiralMatrix();
PrintMatrix(myMatrix);