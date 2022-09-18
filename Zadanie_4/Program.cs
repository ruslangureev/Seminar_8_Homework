int RepeatNumber(int arg1, int arg2, int arg3, int[,,] repeat)
{
    int resul = 0;
    for (int k = 0; k < repeat.GetLength(2); k++)
    {
        for (int i = 0; i < repeat.GetLength(0); i++)
        {
            for (int j = 0; j < repeat.GetLength(1); j++)
            {
                if (i == arg1 && j == arg2 && k == arg3)
                {
                    continue;
                }
                if (repeat[arg1, arg2, arg3] == repeat[i, j, k])
                {
                    resul = 1;
                    return resul;
                }
            }
        }
    }
    return resul;
}

int QuantityNumber(int number)
{
    int quantity = 0;
    number = Math.Abs(number);
    while (number > 0)
    {
        number /= 10;
        quantity++;
    }
    return quantity;
}

Console.Write("Введите количество строк: ");
int row = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int column = int.Parse(Console.ReadLine());
Console.Write("Введите количество элементов длинны массива: ");
int size = int.Parse(Console.ReadLine());

while (row < 0 || column < 0 || size < 0)
{
    if (row < 0)
    {
        Console.Write("Вы ввели отрицательное количество строк. Введите заново количество строк в массиве: ");
        row = int.Parse(Console.ReadLine());
    }
    if (column < 0)
    {
        Console.Write("Вы ввели отрицательное количество столбцов. Введите заново количество столбцов в массиве: ");
        column = int.Parse(Console.ReadLine());
    }
    if (size < 0)
    {
        Console.Write("Вы ввели отрицательное количество элементов длинны массива. Введите заново количество элементов длинны массива: ");
        size = int.Parse(Console.ReadLine());
    }
}

Console.Write("Введите двузначное число, которое будет минимальным значением диапазона генерации случайных чисел: ");
int min = int.Parse(Console.ReadLine());
Console.Write("Введите двузначное число, которое будет максимальным значением диапазона генерации случайных чисел: ");
int max = int.Parse(Console.ReadLine());

int countMin = QuantityNumber(min);
int countMax = QuantityNumber(max);

while (min > max || countMin != 2 || countMax != 2 || (min < -9 && max > 9))
{
    if (min > max)
    {
        Console.Write("Вы ввели минимальное значение диапазона генерации случайных чисел больше чем максимальное. ");
        Console.WriteLine("Сформировать такой диапазон генерации случайных чисел невозможно.");
        Console.Write("Введите двузначное число, которое будет минимальным значением диапазона генерации случайных чисел: ");
        min = int.Parse(Console.ReadLine());
        Console.Write("Введите двузначное число, которое будет максимальным значением диапазона генерации случайных чисел: ");
        max = int.Parse(Console.ReadLine());
        countMin = QuantityNumber(min);
        countMax = QuantityNumber(max);
    }
    if (countMin != 2)
    {
        Console.Write("Вы ввели не двузначное число. ");
        Console.Write("Введите двузначное число, которое будет минимальным значением диапазона генерации случайных чисел: ");
        min = int.Parse(Console.ReadLine());
        countMin = QuantityNumber(min);
    }
    if (countMax != 2)
    {
        Console.Write("Вы ввели не двузначное число. ");
        Console.Write("Введите двузначное число, которое будет максимальным значением диапазона генерации случайных чисел: ");
        max = int.Parse(Console.ReadLine());
        countMax = QuantityNumber(max);
    }
    if (min < -9 && max > 9)
    {
        Console.WriteLine("Вы ввели значения диапазона генерации случайных чисел при которых он будет заполнен не двузначными числами. ");
        Console.Write("Введите двузначное число, которое будет минимальным значением диапазона генерации случайных чисел: ");
        min = int.Parse(Console.ReadLine());
        Console.Write("Введите двузначное число, которое будет максимальным значением диапазона генерации случайных чисел: ");
        max = int.Parse(Console.ReadLine());
        countMin = QuantityNumber(min);
        countMax = QuantityNumber(max);
    }
}

int[,,] array = new int[row, column, size];

for (int k = 0; k < array.GetLength(2); k++)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j, k] = new Random().Next(min, max);
            int resul = RepeatNumber(i, j, k, array);
            while (resul == 1)
            {
                array[i, j, k] = new Random().Next(min, max);
                resul = RepeatNumber(i, j, k, array);
            }
        }
    }
}

for (int k = 0; k < array.GetLength(2); k++)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j, k]} ({i},{j},{k})  ");
        }
        Console.WriteLine();
    }
}