int[,] FillArray(int row, int column, int min, int max)
{
    int[,] fill = new int[row, column];
    for (int i = 0; i < fill.GetLength(0); i++)
    {
        for (int j = 0; j < fill.GetLength(1); j++)
        {
            fill[i, j] = new Random().Next(min, max);
        }
    }
    return fill;
}

void PrintArray(int[,] print)
{
    for (int i = 0; i < print.GetLength(0); i++)
    {
        for (int j = 0; j < print.GetLength(1); j++)
        {
            Console.Write(print[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int MinMax(int min, int max)
{
    while (min > max)
    {
        Console.Write("Вы ввели минимальное значение диапазона генерации случайных чисел больше чем максимальное. ");
        Console.WriteLine("Сформировать такой диапазон генерации случайных чисел невозможно.");
        Console.Write("Введите минимальное значение диапазона генерации случайных чисел меньше чем максимальное: ");
        min = int.Parse(Console.ReadLine());        
    }
    return min;
}

Console.Write("Введите количество строк в первой матрице: ");
int rowArray1 = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов в первой матрице: ");
int columnArray1 = int.Parse(Console.ReadLine());
Console.Write("Введите количество строк во второй матрице: ");
int rowArray2 = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов во второй матрице: ");
int columnArray2 = int.Parse(Console.ReadLine());

while (rowArray1 < 0 || columnArray1 < 0 || rowArray2 < 0 || columnArray2 < 0 || columnArray1 != rowArray2)
{
    if (rowArray1 < 0)
    {
        Console.Write("Вы ввели отрицательное количество строк в первой матрице. Введите заново количество строк: ");
        rowArray1 = int.Parse(Console.ReadLine());
    }
    if (columnArray1 < 0)
    {
        Console.Write("Вы ввели отрицательное количество столбцов в первой матрице. Введите заново количество столбцов: ");
        columnArray1 = int.Parse(Console.ReadLine());
    }
    if (rowArray2 < 0)
    {
        Console.Write("Вы ввели отрицательное количество строк во второй матрице. Введите заново количество строк: ");
        rowArray2 = int.Parse(Console.ReadLine());
    }
    if (columnArray2 < 0)
    {
        Console.Write("Вы ввели отрицательное количество столбцов во второй матрице. Введите заново количество столбцов: ");
        columnArray2 = int.Parse(Console.ReadLine());
    }
    if (columnArray1 != rowArray2)
    {
        Console.WriteLine("Умножить две матрицы можно только в том случае, если число столбцов первой равняется числу строк второй.");
        Console.Write("Введите количество столбцов в первой матрице: ");
        columnArray1 = int.Parse(Console.ReadLine());
        Console.Write("Введите количество строк во второй матрице: ");
        rowArray2 = int.Parse(Console.ReadLine());
    }
}

Console.Write("Введите минимальное значение диапазона генерации случайных чисел в первой матрице: ");
int minMeaningArray1 = int.Parse(Console.ReadLine());
Console.Write("Введите максимальное значение диапазона генерации случайных чисел в первой матрице: ");
int maxMeaningArray1 = int.Parse(Console.ReadLine());

minMeaningArray1 = MinMax(minMeaningArray1, maxMeaningArray1);

Console.Write("Введите минимальное значение диапазона генерации случайных чисел во второй матрице: ");
int minMeaningArray2 = int.Parse(Console.ReadLine());
Console.Write("Введите максимальное значение диапазона генерации случайных чисел во второй матрице: ");
int maxMeaningArray2 = int.Parse(Console.ReadLine());

minMeaningArray2 = MinMax(minMeaningArray2, maxMeaningArray2);

int[,] array1 = FillArray(rowArray1, columnArray1, minMeaningArray1, maxMeaningArray1);
int[,] array2 = FillArray(rowArray2, columnArray2, minMeaningArray2, maxMeaningArray2);

Console.WriteLine("Первая матрица, заполненная случайными числами: ");
PrintArray(array1);
Console.WriteLine();

Console.WriteLine("Вторая матрица, заполненная случайными числами: ");
PrintArray(array2);
Console.WriteLine();

int[,] array3 = new int[array1.GetLength(0), array2.GetLength(1)];

for (int i = 0; i < array3.GetLength(0); i++)
{
    for (int j = 0; j < array3.GetLength(1); j++)
    {
        for (int k = 0; k < array1.GetLength(1); k++)
        {
            array3[i, j] += array1[i, k] * array2[k, j];
        }
    }
}

Console.WriteLine("ответ: Произведение двух матриц: ");
PrintArray(array3);