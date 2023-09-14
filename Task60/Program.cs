/*Задача 60. ...Сформируйте трёхмерный массив из
неповторяющихся двузначных чисел. Напишите программу,
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

Console.Clear();
int SetNumber(string numberName)
{
    Console.Write($"Введите значение {numberName}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

int[,,] GetMatrix3D(int rows, int colums, int width)
{
    int[,,] matrix = new int[rows, colums, width];
    int[] temp = new int[matrix.GetLength(0) * matrix.GetLength(1) * matrix.GetLength(2)];
    //  создаем одномерный массив из количества элементов трехмерного массива
    if (temp.Length <= 99)   // условие наполнения трехмерного массива неповторяющимися целыми двузначными числами
    {
        for (int i = 0; i < temp.GetLength(0); i++)
        {
            temp[i] = new Random().Next(10, 100);
            if (i >= 1)
            {
                for (int j = 0; j < i; j++)
                {
                    while (temp[i] == temp[j])  // цикл для заполнения одномерного массива неповторяющимися двузначными значениями
                    {
                        temp[i] = new Random().Next(10, 100);
                        j = 0;
                    }
                }
            }
        }

        int count = 0;
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int z = 0; z < matrix.GetLength(2); z++)
                {
                    matrix[x, y, z] = temp[count];
                    count++;
                }
            }
        }
    }
    return matrix;
}

void PrintMatrix3D(int[,,] matrix)
{
    if ((matrix.GetLength(0) * matrix.GetLength(1) * matrix.GetLength(2)) <= 99)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int k = 0; k < matrix.GetLength(2); k++)
                {
                    Console.Write($"{matrix[i, j, k]}({i}, {j}, {k})     ");
                }

            }
            Console.WriteLine();
        }
    }
    else Console.WriteLine("Ошибка ввода размерности массива: X * Y * Z не должно превышать 99");
}

int rows = SetNumber("rows");
int colums = SetNumber("columns");
int width = SetNumber("width");

int[,,] matrix = GetMatrix3D(rows, colums, width);
PrintMatrix3D(matrix);
