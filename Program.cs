using System.Globalization;

Console.WriteLine("=== 1. Kalkulyator ===");
Calculator();

Console.WriteLine();
Console.WriteLine("=== 2. 1 dan N gacha bo'lgan sonlar yig'indisi ===");
SumToN();

Console.WriteLine();
Console.WriteLine("=== 3. Paritet tekshiruvi ===");
ParityCheck();

// 1. Foydalanuvchidan ikkita son va operatsiyani so'rab, natijani chiqaradi
static void Calculator()
{
    double a = ReadDouble("Input (1-son) = ");
    string op = ReadOperator("Input (operatsiya: +, -, *, /) = ");
    double b = ReadDouble("Input (2-son) = ");

    if (op == "/" && b == 0)
    {
        Console.WriteLine("Xatolik: nolga bo'lish mumkin emas!");
        return;
    }

    double result = op switch
    {
        "+" => a + b,
        "-" => a - b,
        "*" => a * b,
        "/" => a / b,
        _ => throw new InvalidOperationException()
    };

    Console.WriteLine($"Output = {result.ToString(CultureInfo.InvariantCulture)}");
}

// 2. N musbat butun sonni so'rab, 1 dan N gacha bo'lgan sonlar yig'indisini chiqaradi
static void SumToN()
{
    int n = ReadPositiveInt("Input (N) = ");

    long sum = 0;
    for (int i = 1; i <= n; i++)
    {
        sum += i;
    }

    Console.WriteLine($"Output = {sum}");
}

// 3. Kiritilgan sonning juft yoki toq ekanligini aniqlaydi
static void ParityCheck()
{
    long number = ReadLong("Input = ");

    // Manfiy sonlar uchun ham ishlaydi: -3 % 2 == -1 (toq), -4 % 2 == 0 (juft)
    string result = number % 2 == 0 ? "Juft" : "Toq";
    Console.WriteLine($"Output = \"{result}\"");
}

// ---------- Yordamchi metodlar (kiritishni tekshirish) ----------

static double ReadDouble(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string input = ReadLineOrExit().Trim().Replace(',', '.');
        if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            return value;
        Console.WriteLine("Xatolik: iltimos, to'g'ri son kiriting.");
    }
}

static string ReadOperator(string prompt)
{
    string[] allowed = { "+", "-", "*", "/" };
    while (true)
    {
        Console.Write(prompt);
        string input = ReadLineOrExit().Trim();
        if (allowed.Contains(input))
            return input;
        Console.WriteLine("Xatolik: faqat +, -, * yoki / kiriting.");
    }
}

static int ReadPositiveInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(ReadLineOrExit().Trim(), out int value) && value > 0)
            return value;
        Console.WriteLine("Xatolik: iltimos, musbat butun son kiriting.");
    }
}

static long ReadLong(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (long.TryParse(ReadLineOrExit().Trim(), out long value))
            return value;
        Console.WriteLine("Xatolik: iltimos, butun son kiriting.");
    }
}

// Kiritish oqimi tugasa (EOF), dastur cheksiz siklga tushmasdan to'xtaydi
static string ReadLineOrExit()
{
    string? line = Console.ReadLine();
    if (line == null)
    {
        Console.WriteLine();
        Console.WriteLine("Kiritish tugadi. Dastur yakunlandi.");
        Environment.Exit(0);
    }
    return line;
}
