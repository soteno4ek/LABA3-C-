using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

internal class FileTasks
{
    public static void FillFile(string path, int count)
    {
        Random rnd = new Random();
        int i = 0;
        int num = 0;
        BinaryWriter writer;

        try
        {
            writer = new BinaryWriter(File.Create(path));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        for (i = 0; i < count; i++)
        {
            num = rnd.Next(-50, 50);
            writer.Write(num);
        }
        writer.Close();
    }

    public static void Task4(string path, int count)
    {
        FillFile(path, count);
        BinaryReader reader;

        try
        {
            reader = new BinaryReader(File.OpenRead(path));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        int first = reader.ReadInt32();
        int max = first;
        int current = first;

        Console.WriteLine("Числа в файле: ");
        Console.Write(first + " ");

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            current = reader.ReadInt32();
            Console.Write(current + " ");

            if (current > max)
            {
                max = current;
            }
        }

        reader.Close();
        Console.WriteLine();
        Console.WriteLine("Разность: " + Math.Abs(first - max));
    }

    public static void FillToys(string path)
    {
        List<Toy> toys = new List<Toy>();
        toys.Add(new Toy
        {
            Name = "Кукла маленькая",
            Price = 500,
            MinAge = 3,
            MaxAge = 7
        });
        toys.Add(new Toy
        {
            Name = "Кукла средненькая",
            Price = 600,
            MinAge = 3,
            MaxAge = 5
        });
        toys.Add(new Toy
        {
            Name = "Кукла большенькая",
            Price = 700,
            MinAge = 5,
            MaxAge = 8
        });
        toys.Add(new Toy
        {
            Name = "Машинка",
            Price = 300,
            MinAge = 3,
            MaxAge = 5
        });

        XmlSerializer formatter = new XmlSerializer(typeof(List<Toy>));

        using (FileStream fs = File.Create(path))
        {
            formatter.Serialize(fs, toys);
        }
    }

    public static void Task5()
    {
        string path = "task5.xml";

        FillToys(path);

        List<Toy> loadedToys = null;
        XmlSerializer formatter = new XmlSerializer(typeof(List<Toy>));

        using (FileStream fs = File.OpenRead(path))
        {
            loadedToys = (List<Toy>)formatter.Deserialize(fs);
        }

        Console.WriteLine("\nИгрушки, прочитанные из файла:");
        foreach (Toy t in loadedToys)
        {
            Console.WriteLine($"{t.Name} | Цена: {t.Price} | " +
                $"Возраст: {t.MinAge}-{t.MaxAge}");
        }

        Console.WriteLine("\nПодходящие куклы для 6 лет:");
        double sum = 0;
        foreach (Toy t in loadedToys)
        {
            if (t.Name.Contains("Кукла") &&
                t.MinAge <= 6 && t.MaxAge >= 6)
            {
                Console.WriteLine($"- {t.Name} (Цена: {t.Price})");
                sum += t.Price;
            }
        }

        Console.WriteLine("Итоговая стоимость: " + sum);
    }

    public static void FillTextFile(string path, int count)
    {
        Random rnd = new Random();
        int i = 0;
        int num = 0;
        StreamWriter writer;

        try
        {
            writer = new StreamWriter(File.Create(path));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        for (i = 0; i < count; i++)
        {
            num = rnd.Next(-50, 50);
            writer.WriteLine(num);
        }
        writer.Close();
    }

    public static void Task6(string pathIn, string pathOut, int count)
    {
        FillTextFile(pathIn, count);
        StreamWriter writer;
        StreamReader reader;

        try
        {
            reader = new StreamReader(File.OpenRead(pathIn));
            writer = new StreamWriter(pathOut);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        string line = "";
        int num = 0;
        int result = 0;

        while ((line = reader.ReadLine()) != null)
        {
            num = int.Parse(line);
            result = num - 1;
            writer.WriteLine(result);
        }

        reader.Close();
        writer.Close();
    }

    public static void FillTextFile7(string path, int count)
    {
        Random rnd = new Random();
        int i = 0;
        int num = 0;
        StreamWriter writer;

        try
        {
            writer = new StreamWriter(File.Create(path));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        for (i = 0; i < count; i++)
        {
            num = rnd.Next(-50, 50);
            writer.Write(num + " ");
        }
        writer.Close();
    }

    public static void Task7(string path, int count)
    {
        FillTextFile7(path, count);
        StreamReader reader;

        try
        {
            reader = new StreamReader(File.OpenRead(path));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        string? text = reader.ReadToEnd();
        reader.Close();

        if (text == null) return;

        string[] parts = text.Split(' ',
            StringSplitOptions.RemoveEmptyEntries);

        int first = 0;
        int max = 0;
        int current = 0;
        int i = 0;

        for (i = 0; i < parts.Length; i++)
        {
            current = int.Parse(parts[i]);

            if (i == 0)
            {
                first = current;
                max = current;
            }
            else if (current > max)
            {
                max = current;
            }
        }

        Console.WriteLine("Разность первого и максимального: "
            + Math.Abs(first - max));
    }

    public static void FillTextFile8(string path)
    {
        StreamWriter writer;

        try
        {
            writer = new StreamWriter(File.Create(path));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        Console.WriteLine("Введите строки (пустая строка - конец):");
        string? line = Console.ReadLine();

        while (!string.IsNullOrEmpty(line))
        {
            writer.WriteLine(line);
            line = Console.ReadLine();
        }

        writer.Close();
    }

    public static void Task8(string pathIn, string pathOut)
    {
        FillTextFile8(pathIn);

        StreamReader reader;
        StreamWriter writer;

        try
        {
            reader = new StreamReader(File.OpenRead(pathIn));
            writer = new StreamWriter(pathOut);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            if (line.StartsWith("б"))
            {
                writer.WriteLine(line);
            }
        }

        reader.Close();
        writer.Close();
    }
}