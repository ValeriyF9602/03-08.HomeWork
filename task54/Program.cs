/****************************************************************

Задача 54 
Задайте двумерный массив. Напишите программу, которая упорядочит 
по убыванию элементы каждой строки двумерного массива.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4

В итоге получается вот такой массив:

7 4 2 1
9 5 3 2
8 4 4 2

****************************************************************/


int[,] GenerateMatrix() // генерация матрицы целых чисел
{
    Random rand = new Random();
    int[,] matrix = new int[rand.Next(4, 8), rand.Next(4, 8)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(0, 10);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix) // вывод матрицы целых чисел
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

void SortRowsOfMatrix(int[,] matrix) // метод сортировки по убыванию элементов КАЖДОЙ СТРОКИ матрицы
{
    int temp, maxCol;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1) - 1; col++)
        {
            maxCol = col + 1;

            for (int subCol = col + 1; subCol < matrix.GetLength(1); subCol++)
            {
                if (matrix[row, subCol] > matrix[row, maxCol]) maxCol = subCol;
            }
            if (matrix[row, maxCol] > matrix[row, col])
            {
                temp = matrix[row, col];
                matrix[row, col] = matrix[row, maxCol];
                matrix[row, maxCol] = temp;
                continue;
            }
            else if (col + 1 == maxCol) continue; // есть ли смысл в этом сравнении?
            
            // Что сложнее для компьютера?
            // а) проверить это равенство и если оно отвечает истине — завершить итерацию;
            // б) не проводить сравнение и просто перезаписать себя же на себя.

            temp = matrix[row, col + 1];
            matrix[row, col + 1] = matrix[row, maxCol];
            matrix[row, maxCol] = temp;
        }
    }
}

Console.WriteLine();
int[,] myMatrix = GenerateMatrix();
PrintMatrix(myMatrix);
Console.WriteLine();
Console.WriteLine("Сортировка элементов каждой СТРОКИ матрицы по убыванию (по условии задачи):");
Console.WriteLine();
SortRowsOfMatrix(myMatrix);
PrintMatrix(myMatrix);
Console.WriteLine();