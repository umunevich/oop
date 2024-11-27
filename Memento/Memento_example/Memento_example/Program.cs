using Memento_example;

namespace Memento {
    class Program {
        public static Random random = new Random();
        public static void Main(string[] args) {
            Race race = new Race();
            Caretaker caretaker = new Caretaker(race);


            for (int i = 0; i < 5; i++) {
                Console.WriteLine("Check-point");
                caretaker.Backup();
                race.Drive();
                Console.ReadKey();
            }

            Console.WriteLine("Let's undo. ");
            Console.ReadKey();

            for (int i = 0; i < 5; i++) {
                caretaker.Undo();
                Console.ReadKey();
            }
        }
    }
}