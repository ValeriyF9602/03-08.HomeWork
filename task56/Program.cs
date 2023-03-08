/************************************************************

Задача 56
Задайте прямоугольный двумерный массив. Напишите программу,
которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт 
номер строки с наименьшей суммой элементов: 1 строка

************************************************************/


int[,] GenerateMatrix(int leftRange, int rightRange) // генерация матрицы целых чисел
{
    Random rand = new Random();
    int[,] matrix = new int[rand.Next(4, 11), rand.Next(2, 6)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix) // вывод матрицы целых чисел + сумма строк
{
    int sum;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum = 0;
        Console.Write($"({i + 1}):\t");

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
            sum += matrix[i, j];
        }
        Console.WriteLine($"| Сумма = {sum}");
    }
    Console.WriteLine();
    Console.WriteLine("*Сумма выведена для проверки");
}

void MinSumLine(int[,] matrix, int rightRange) // вывод матрицы целых чисел
{
    int sum, minRow = 0, minSum = rightRange * matrix.GetLength(1);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            minRow = i;
        }
    }
    Console.WriteLine($"Строка {minRow + 1} имеет наименьшую сумму ({minSum}) элементов");
}


const int LEFT_RANGE = 0;
const int RIGHT_RANGE = 9;

int[,] myMatrix = GenerateMatrix(LEFT_RANGE, RIGHT_RANGE);

Console.WriteLine();
PrintMatrix(myMatrix);

Console.WriteLine();

MinSumLine(myMatrix, RIGHT_RANGE);
Console.WriteLine();