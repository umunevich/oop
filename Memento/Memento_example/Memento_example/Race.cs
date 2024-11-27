using Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_example {
    internal class Race {
        private float playerPos;
        private float oponentPos;
        private float time;
        private int countLap;
        private int points;

        public Race() {
            playerPos = 0;
            oponentPos = 0;
            time = 0;
            countLap = 0;
            points = 0;

            Console.WriteLine($"Race started. Points: {points} Lap: {countLap} Time: {time}s");
        }

        public void Drive() {
            Console.WriteLine("Driving...");

            playerPos += Math.Abs((float)Program.random.NextDouble()) * 100;
            oponentPos += Math.Abs((float)Program.random.NextDouble()) * 100;
            time += Math.Abs((float)Program.random.NextDouble()) * 100;
            countLap += Program.random.Next(0, 2);
            points += Program.random.Next(0, 100);

            string first = playerPos > oponentPos ? "You" : "Oponent";

            Console.WriteLine($"Current state: First {first} Points: {points} Lap: {countLap} Time: {time}s");
        }

        public IMemento Save() {
            return new ConcreteMemento(playerPos, oponentPos, time, countLap, points);
        }

        public void Restore(IMemento memento) {
            if (!(memento is ConcreteMemento)) {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            playerPos = memento.GetPlayerPos();
            oponentPos = memento.GetOponentPos();
            time = memento.GetTime();
            countLap = memento.GetCountLap();
            points = memento.GetPoints();

            string first = playerPos > oponentPos ? "You" : "Oponent";

            Console.WriteLine($"State changed: First {first} Points: {points} Lap: {countLap} Time: {time}s");

        }
    }
}
