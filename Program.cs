using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Validator v = new Validator();

        Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2");
        Console.WriteLine();
        Console.WriteLine("--- Задание 1 ---");
        Console.WriteLine("1. Заполнение двумерных массивов");
        Console.WriteLine();
        Console.WriteLine("--- Задание 2 ---");
        Console.WriteLine("2. Работа с двумерными массивами");
        Console.WriteLine();
        Console.WriteLine("--- Задание 3 ---");
        Console.WriteLine("3. Работа с двумерными массивами как с матрицами");
        Console.WriteLine();
        Console.WriteLine("--- Задание 4 ---");
        Console.WriteLine("4. Бинарные файлы");
        Console.WriteLine();
        Console.WriteLine("--- Задание 5 ---");
        Console.WriteLine("5. Бинарные файлы и структуры");
        Console.WriteLine();
        Console.WriteLine("--- Задание 6 ---");
        Console.WriteLine("6. Текстовые файлы");
        Console.WriteLine();
        Console.WriteLine("--- Задание 7 ---");
        Console.WriteLine("7. Решить задачу с использованием структуры «текстовый файл» ");
        Console.WriteLine();
        Console.WriteLine("--- Задание 8 ---");
        Console.WriteLine("8. Текстовый файл");

        bool running = true;
        int choice = 0;

        do
        {
            Console.WriteLine();
            choice = v.ReadInt("Введите номер: ");

            switch (choice)
            {
                case 1:
                    int n = v.ReadInt("Введите n: ");
                    int m = v.ReadInt("Введите m: ");

                    try
                    {
                        Matrix m1 = new Matrix(n, m, true);
                        Console.WriteLine("\nМассив 1 (Диагонали):");
                        Console.WriteLine(m1);

                        Matrix m2 = new Matrix(n, true);
                        Console.WriteLine("\nМассив 2 (Столбцы):");
                        Console.WriteLine(m2);

                        Matrix m3 = new Matrix(n, "spiral");
                        Console.WriteLine("\nМассив 3 (Спираль):");
                        Console.WriteLine(m3);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    break;

                case 2:
                    Matrix mFib = new Matrix(5, true);
                    Console.WriteLine("Матрица:");
                    Console.WriteLine(mFib);

                    Console.WriteLine("Вывод по Фибоначчи:");
                    mFib.PrintFibonacci();
                    break;

                case 3:
                    int n3 = v.ReadInt("Введите размер матриц n: ");
                    int mode3 = v.ReadInt("1. Рандом; 2. Вручную: ");

                    try
                    {
                        Matrix A;
                        Matrix B;
                        Matrix C;

                        if (mode3 == 1)
                        {
                            A = new Matrix(n3, true);
                            B = new Matrix(n3, true);
                            C = new Matrix(n3, true);
                        }
                        else
                        {
                            Console.WriteLine("Ввод матрицы A:");
                            A = new Matrix(n3, n3, true);
                            Console.WriteLine("Ввод матрицы B:");
                            B = new Matrix(n3, n3, true);
                            Console.WriteLine("Ввод матрицы C:");
                            C = new Matrix(n3, n3, true);
                        }

                        Console.WriteLine("\nМатрица A:");
                        Console.WriteLine(A);
                        Console.WriteLine("Матрица B:");
                        Console.WriteLine(B);
                        Console.WriteLine("Матрица C:");
                        Console.WriteLine(C);

                        Matrix res = 2 * A + (B - C.Transpose());
                        Console.WriteLine("Результат (2*A + (B - C^T)):");
                        Console.WriteLine(res);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    break;

                case 4:
                    int count4 = v.ReadPositiveInt(
                        "Сколько чисел создать в файле: ");
                    FileTasks.Task4("task4.bin", count4);
                    break;

                case 5:
                    FileTasks.Task5();
                    break;

                case 6:
                    int count6 = v.ReadPositiveInt(
                        "Сколько чисел сгенерировать: ");

                    string inPath6 = "task6_in.txt";
                    string outPath6 = "task6_out.txt";

                    FileTasks.Task6(inPath6, outPath6, count6);

                    Console.WriteLine(
                        "\nИсходный файл " + inPath6 + ":");
                    Console.WriteLine(
                        File.ReadAllText(inPath6).Replace("\r\n", " "));

                    Console.WriteLine(
                        "\nНовый файл " + outPath6 + ":");
                    Console.WriteLine(
                        File.ReadAllText(outPath6).Replace("\r\n", " "));
                    break;

                case 7:
                    int count7 = v.ReadPositiveInt(
                        "Сколько чисел сгенерировать: ");

                    string inPath7 = "task7_in.txt";

                    FileTasks.Task7(inPath7, count7);

                    Console.WriteLine("\nЧисла в файле (в одну строку):");
                    Console.WriteLine(File.ReadAllText(inPath7));
                    break;

                case 8:
                    string inPath8 = "task8_in.txt";
                    string outPath8 = "task8_out.txt";

                    FileTasks.Task8(inPath8, outPath8);

                    Console.WriteLine("\nИсходный текст:");
                    Console.WriteLine(File.ReadAllText(inPath8));

                    Console.WriteLine("\nСтроки, начинающиеся на 'б':");
                    Console.WriteLine(File.ReadAllText(outPath8));
                    break;

                case 0:
                    Console.WriteLine("Выход");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Нет такой задачи");
                    break;
            }
        } while (running);
    }
}