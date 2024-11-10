class Program {
    public static void Main(String[] args) {
        Linq2();
        Linq3();
    }

    public static void Linq2() {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var lowNums =
            from num in numbers
            where num > 5
            select num;

        Console.WriteLine("Numbers < 5: ");
        foreach (int x in lowNums) { 
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    public static void Linq3() {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var numsPlusOne =
            from num in numbers
            select num + 1;

        Console.WriteLine("Numbers + 1: ");
        foreach (int x in numsPlusOne) {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}