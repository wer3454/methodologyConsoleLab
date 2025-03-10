GameLCM a = new();
a.Play();
GeometricProgressionGame.Play();
class GameLCM
{
    public readonly int length;
    public readonly int min;
    public readonly int max;
    public GameLCM(int _lenght, int _min, int _max)
    {
        length = _lenght;
        min = _min;
        max = _max;
    }
    public GameLCM()
    {
        length = 5;
        min = 1;
        max = 10;
    }
    public void Play()
    {
        List<int> numbers = Makelist();
        Console.WriteLine("Найдите НОК чисел: " + string.Join(" ", numbers));
        long userAnswer;
        long correctLcm = FindLCM(numbers);
        while (true)
        {
            Console.Write("Ваш ответ: ");
            if (long.TryParse(Console.ReadLine(), out userAnswer)) break;
            Console.WriteLine("Ошибка: Введите числовое значение.");
        }
        if (userAnswer == correctLcm)
            Console.WriteLine("Верно!");
        else
            Console.WriteLine($"Неверно. Правильный ответ: {correctLcm}");
    }
    private List<int> Makelist()
    {
        Random random = new();
        HashSet<int> uniqueNumbers = new HashSet<int>();
        while (uniqueNumbers.Count < length)
        {
            uniqueNumbers.Add(random.Next(min, max + 1));
        }
        List<int> Numbers = [.. uniqueNumbers];
        Numbers.Sort();
        return Numbers;
    }
    private static long FindLCM(List<int> numbers)
    {
        return numbers.Aggregate((long)numbers[0], (lcm, num) => LCM(lcm, num));
    }
    private static long LCM(long a, long b)
    {
        return (a / GCD(a, b)) * b;
    }
    private static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
class GeometricProgressionGame
{
    public static void Play()
    {
        Random random = new();
        int length = random.Next(5, 11);
        int start = random.Next(1, 10);
        int ratio = random.Next(2, 5);

        List<int> progression = [];
        for (int i = 0; i < length; i++)
            progression.Add(start * (int)Math.Pow(ratio, i));

        int hiddenIndex = random.Next(0, length);
        int correctAnswer = progression[hiddenIndex];
        progression[hiddenIndex] = -1;

        Console.WriteLine("Геометрическая прогрессия: " + string.Join(" ", progression.Select(n => n == -1 ? ".." : n.ToString())));

        int userAnswer;
        while (true)
        {
            Console.Write("Введите скрытое число: ");
            if (int.TryParse(Console.ReadLine(), out userAnswer))
            break;
            Console.WriteLine("Ошибка: Введите числовое значение.");
        }

        if (userAnswer == correctAnswer)
            Console.WriteLine("Верно!");
        else
            Console.WriteLine($"Неверно. Правильный ответ: {correctAnswer}");
    }
}