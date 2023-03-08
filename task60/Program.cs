/**************************************************************************

Задача 60
Сформируйте трёхмерный массив двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2

66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)

**************************************************************************/


/*

ПРЕДИСЛОВИЕ

Суда по примеру в условии задачи, третье значение обозначает этаж (уровень, страницу, матрицу), 
первая и вторая — строку и столбец соответственно —> (строка, столбец, № этажа).

В выводе так и будет представлено.

*/


int[,,] GenerateCube()
{
    Random rand = new Random();
    int[,,] cube = new int[rand.Next(2, 7), rand.Next(2, 7), rand.Next(2, 6)];

    Console.WriteLine();
    Console.WriteLine($"Массив размером {cube.GetLength(0)} x {cube.GetLength(1)} x {cube.GetLength(2)}");

    for (int k = 0; k < cube.GetLength(2); k++) // этаж (уровень, страница, матрица)
    {
        for (int i = 0; i < cube.GetLength(0); i++) // строка
        {
            for (int j = 0; j < cube.GetLength(1); j++) // столбец
            {
                cube[i, j, k] = rand.Next(10, 100); // двузначные числа
            }
        }
    }
    return cube;
}

void PrintCube(int[,,] cube)
{
    Console.WriteLine();
    for (int k = 0; k < cube.GetLength(2); k++) // этаж (уровень, страница, матрица)
    {
        for (int i = 0; i < cube.GetLength(0); i++) // строка
        {
            for (int j = 0; j < cube.GetLength(1); j++) // столбец
            {
                Console.Write($"{cube[i, j, k]} —> ({i},{j},{k})\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine(); // отступ между этажами (уровенями, страницами, матрицами)
    }
}

int[,,] myCube = GenerateCube();
PrintCube(myCube);

