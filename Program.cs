
//Задание 1
//static double functionx(double x)
//{
//    Random Rnd = new Random();
//    int a = Rnd.Next(-50, 51);
//    Console.WriteLine("Значение a = " + a);

//    if (x < 0)
//        return x + Math.Pow(Math.Sin(1 / (x - a) + 4), 2);
//    else
//    {
//        if (x == a)
//            throw new DivideByZeroException();
//        if (x == -a)
//            throw new DivideByZeroException();
//        if (a * a < x * x)
//            throw new ArgumentException();
//        return (a * x) / Math.Sqrt(Math.Pow(a, 2) - Math.Pow(x, 2));
//    }
//}

//try
//{
//    Console.WriteLine("Значение F(x),когда x = 10\n" + functionx(10.0));
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Произошло деление на ноль. Значение F(x) = infinity");
//}
//catch (ArgumentException)
//{
//    Console.WriteLine("Подкоренное выражение отрицательное");
//}

//Задание 2
//static void InpArray(double[] array, int k1, int k2)
//{
//    for (int i = k1; i < k2; i++)
//    {
//        Console.WriteLine($"Введите значение для индекса {i}: ");
//        array[i] = Convert.ToDouble(Console.ReadLine());
//    }
//}
//static void FillWithRnd(double[] array, int k1, int k2)
//{
//    Random rnd = new Random();
//    for (int i = k1; i <= k2; i++)
//    {
//        array[i] = rnd.Next(1, 100);
//    }
//}

//static void PrintArray(double[] array)
//{
//    for (int i = 0; i < array.Length; i++)
//    {
//        Console.Write(array[i] + " ");
//    }
//    Console.WriteLine();
//}

//double[] array = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
//Console.WriteLine("Исходный массив:");
//PrintArray(array);

//Ввод с консоли части элементов массива
//Console.WriteLine("\nВведите диапазон индексов для изменения (k1 и k2):");
//int k1 = Convert.ToInt32(Console.ReadLine());
//int k2 = Convert.ToInt32(Console.ReadLine());
//InpArray(array, k1, k2);
//Console.WriteLine("\nМассив после изменения:");
//PrintArray(array);

//Заполнение случайными числами части массива
//Console.WriteLine("\nВведите диапазон индексов для заполнения случайными числами (k1 и k2):");
//k1 = Convert.ToInt32(Console.ReadLine());
//k2 = Convert.ToInt32(Console.ReadLine());
//FillWithRnd(array, k1, k2);
//Console.WriteLine("\nМассив после заполнения случайными числами:");
//PrintArray(array);

//Задание 3
//Console.Write("Введите k1: ");
//int k1 = Convert.ToInt32(Console.ReadLine());
//Console.Write("Введите k2: ");
//int k2 = Convert.ToInt32(Console.ReadLine());
//Console.Write("Введите n: ");
//int n = Convert.ToInt32(Console.ReadLine());

//double[] x = new double[n];
//InpArray(x, k1, k2);
//FillWithRnd(x, 0, k1 - 1);
//FillWithRnd(x, k2 + 1, n - 1);
//Console.WriteLine("Массив x:");
//foreach (double elem in x)
//    Console.Write(elem + " ");
//Console.WriteLine();
//double[] y = new double[n];
//for (int i = 0; i < n; i++)
//{
//    try
//    {
//        y[i] = functionx(x[i]);
//    }
//    catch (ArgumentException)
//    {
//        Console.WriteLine($"Аргумент x[{i}] не попадает в область определения функции.");
//    }
//    catch (DivideByZeroException)
//    {
//        Console.WriteLine($"Деление на ноль при вычислении y[{i}].");
//    }
//}
//Console.WriteLine("Массив y:");
//foreach (double el in y)
//    Console.Write(el + " ");
//Console.WriteLine();

//Console.WriteLine("Точки, попадающие в заштрихованную область:");
//int count = 0;
//for (int i = 0; i < n; i++)
//{
//    if (y[i] != 0 && x[i] >= -4 && x[i] <= 4 && y[i] <= x[i])
//    {
//        Console.WriteLine($"({x[i]}, {y[i]})");
//        count++;
//    }
//}
//Console.WriteLine($"Всего точек: {count}");

//double length = 0;
//for (int i = 0; i < n - 1; i++)
//{
//    if (y[i] != 0 && y[i + 1] != 0)
//    {
//        double dx = x[i + 1] - x[i];
//        double dy = y[i + 1] - y[i];
//        length += Math.Sqrt(dx * dx + dy * dy);
//    }
//    else
//    {
//        Console.WriteLine("Невозможно построить ломаную линию, так как не все точки имеют значения.");
//        break;
//    }
//}
//Console.WriteLine($"Длина ломаной линии: {length}");

//Задание 4
static void InpArray(double[] array, int k1, int k2)
{
    if (k1 < 0 || k1 >= array.Length)
    {
        throw new InpArrayEx("Ошибка ввода массива", $"Неверное значение k1: {k1}");
    }

    if (k2 < 0 || k2 >= array.Length)
    {
        throw new InpArrayEx("Ошибка ввода массива", $"Неверное значение k2: {k2}");
    }

    if (k1 > k2)
    {
        throw new InpArrayEx("Ошибка ввода массива", $"Значение k1 не может быть больше k2: k1={k1}, k2={k2}");
    }

    try
    {
        for (int i = k1; i <= k2; i++)
        {
            Console.Write($"Введите x[{i}]: ");
            array[i] = Convert.ToDouble(Console.ReadLine());
        }
    }
    catch (FormatException ex)
    {
        throw new InpArrayEx("Ошибка ввода массива", "Неверный формат числа");
    }
}

static double Functionx(double x)
{
    if (x == 0)
    {
        throw new FunctionxEx("Ошибка вычисления функции", $"Неверное значение x: {x}");
    }

    return 1 / x;
}

static void FillWithRnd(double[] array, int startIndex, int endIndex)
{
    if (startIndex < 0 || startIndex >= array.Length)
    {
        throw new FillWithRndEx("Ошибка заполнения массива случайными числами", $"Неверное значение startIndex: {startIndex}");
    }

    if (endIndex < 0 || endIndex >= array.Length)
    {
        throw new FillWithRndEx("Ошибка заполнения массива случайными числами", $"Неверное значение endIndex: {endIndex}");
    }

    if (startIndex > endIndex)
    {
        throw
new FillWithRndEx("Ошибка заполнения массива случайными числами",
$"Значение startIndex не может быть больше endIndex: startIndex={startIndex}, endIndex={endIndex}");
    }
    try
    {
        Random rnd = new Random();
        for (int i = startIndex; i <= endIndex; i++)
        {
            array[i] = rnd.NextDouble();
        }
    }
    catch (Exception ex)
    {
        throw new FillWithRndEx("Ошибка заполнения массива случайными числами", "Ошибка при генерации случайного числа");
    }
}


try
{
    double[] array = new double[5];
    InpArray(array, 0, 4);
    Console.WriteLine("Массив успешно введен.");

    double result = Functionx(array[3]);
    Console.WriteLine($"Результат функции: {result}");

    FillWithRnd(array, 1, 3);
    Console.WriteLine("Массив успешно заполнен случайными числами.");
}
catch (InpArrayEx ex)
{
    Console.WriteLine($"Ошибка ввода массива: {ex.Reason}");
}
catch (FunctionxEx ex)
{
    Console.WriteLine($"Ошибка вычисления функции: {ex.Reason}");
}
catch (FillWithRndEx ex)
{
    Console.WriteLine($"Ошибка заполнения массива случайными числами: {ex.Reason}");
}
catch (Exception ex)
{
    Console.WriteLine($"Произошла ошибка: {ex.Message}");
}
    Console.ReadLine();