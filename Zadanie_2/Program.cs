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

int[] array2 = new int[row];

for (int i = 0; i < array.GetLength(0); i++)
{
    int sum = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        sum += array[i, j];
    }
    array2[i] = sum;
}

Console.WriteLine($"Сумма элементов в каждой строке {string.Join(",", array2)}.");

int imin = 0;
int min = array2[0];

for (int i = 0; i < array2.Length; i++)
{
    if (array2[i] < min)
    {
        min = array2[i];
        imin = i;
    }
}

Console.Write($"Ответ: Cтрока с наименьшей суммой элементов: {imin + 1} строка.");

for (int i = 0; i < array2.Length; i++)
{
    if (imin == i)
    {
        continue;
    }
    if (array2[imin] == array2[i])
    {
        Console.Write($" Cумма элементов {i + 1} строки равна сумме элементов в {imin + 1} строке.");
    }
}