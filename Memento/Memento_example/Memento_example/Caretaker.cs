using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_example {
    internal class Caretaker {
        private List<IMemento> mementos = new List<IMemento>();

        private Race race = null;

        public Caretaker(Race race) { 
            this.race = race;
        }

        public void Backup() {
            Console.WriteLine("Saving current Race state...");
            this.mementos.Add(this.race.Save());
        }

        public void Undo() {
            if (this.mementos.Count == 0) {
                return;
            }

            var memento = this.mementos.Last();
            this.mementos.Remove(memento);

            Console.WriteLine("Undo 1 state.");

            try {
                this.race.Restore(memento);
            }
            catch (Exception) {
                this.Undo();
            }
        }
    }
}
