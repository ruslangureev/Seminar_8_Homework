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

Console.Write("Введите количество строк: ");
int row = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int column = int.Parse(Console.ReadLine());

while (row < 0 || column < 0)
{
    if (row < 0)
    {
        Console.Write("Вы ввели отрицательное количество строк. Введите заново количество строк: ");
        row = int.Parse(Console.ReadLine());
    }
    if (column < 0)
    {
        Console.Write("Вы ввели отрицательное количество столбцов. Введите заново количество столбцов: ");
        column = int.Parse(Console.ReadLine());
    }
}

Console.Write("Введите минимальное значение диапазона генерации случайных чисел: ");
int minMeaning = int.Parse(Console.ReadLine());
Console.Write("Введите максимальное значение диапазона генерации случайных чисел: ");
int maxMeaning = int.Parse(Console.ReadLine());

while (minMeaning > maxMeaning)
{
    Console.Write("Вы ввели минимальное значение диапазона генерации случайных чисел больше чем максимальное. ");
    Console.WriteLine("Сформировать такой диапазон генерации случайных чисел невозможно.");
    Console.Write("Введите минимальное значение диапазона генерации случайных чисел меньше чем максимальное: ");
    minMeaning = int.Parse(Console.ReadLine());
    Console.Write("Введите максимальное значение диапазона генерации случайных чисел: ");
    maxMeaning = int.Parse(Console.ReadLine());
}

int[,] array = FillArray(row, column, minMeaning, maxMeaning);
Console.WriteLine("Двумерный массив, заполненный случайными числами: ");
PrintArray(array);
Console.WriteLine();

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int k = j + 1; k < array.GetLength(1); k++)
        {
            if (array[i, j] < array[i, k])
            {
                int temp = array[i, j];
                array[i, j] = array[i, k];
                array[i, k] = temp;
            }
        }
    }
}

Console.WriteLine("Двумерный массив, упорядоченный по убыванию элементов в каждой строке: ");
PrintArray(array);