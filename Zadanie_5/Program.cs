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

int row = 4;
int column = 4;
int[,] array = new int[row, column];
Console.WriteLine("Начальное значение будет задано случайным числом из заданного диапазона. ");
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

int k = new Random().Next(minMeaning, maxMeaning);

for (int j = 0; j < array.GetLength(1); j++)
{
    array[0, j] = k;
    k++;
}

for (int i = 1; i < array.GetLength(0); i++)
{
    array[i, array.GetLength(1) - 1] = k;
    k++;
}

for (int j = 2; j >= 0; j--)
{
    array[array.GetLength(0) - 1, j] = k;
    k++;
}

for (int i = 2; i > 0; i--)
{
    array[i, 0] = k;
    k++;
}

for (int j = 1; j < array.GetLength(1) - 1; j++)
{
    array[array.GetLength(0) - 3, j] = k;
    k++;
}

for (int j = 2; j > 0; j--)
{
    array[array.GetLength(0) - 2, j] = k;
    k++;
}
Console.WriteLine("Массив 4 на 4 заполненый спирально:");
PrintArray(array);
