/*Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой 
строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

Console.Clear();
int SetNumber(string numberName)
{
    Console.Write($"Введите значение {numberName}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

int[,] GetMatrix(int rows, int colums, int mixValue, int maxValue)
{
    int[,] matrix = new int[rows, colums];
    if (rows != colums)
    {
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                matrix[i, j] = random.Next(mixValue, maxValue + 1);
            }
        }
        return matrix;
    }
    else 
    Console.WriteLine("Массив не прямоугольный, 'элементы не будут определены! Попробуйте еще раз");
    return matrix;

}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void NumberRowMinSumElements(int[,] matrix)
{
    int minRow = 0;
    int minSumRow = 0;
    int sumRow = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        minRow += matrix[0, i];
    }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++) sumRow += matrix[i, j];
        if (sumRow < minRow)
        {
            minRow = sumRow;
            minSumRow = i;
        }
        sumRow = 0;
    }
    Console.WriteLine($"номер строки с наименьшей суммой элементов: {minSumRow + 1} строка");
}

int rows = SetNumber("rows");
int colums = SetNumber("columns");
int minValue = SetNumber("min");
int maxValue = SetNumber("max");

int[,] matrix = GetMatrix(rows, colums, minValue, maxValue);
PrintMatrix(matrix);
Console.WriteLine();
NumberRowMinSumElements(matrix);
PrintMatrix(matrix);