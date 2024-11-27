using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_example {
    internal interface IMemento {
        public float GetPlayerPos();
        public float GetOponentPos();
        public float GetTime();
        public int GetCountLap();
        public int GetPoints();
    }

    class ConcreteMemento : IMemento {
        private float playerPos;
        private float oponentPos;
        private float time;
        private int countLap;
        private int points;

        public ConcreteMemento(float playerPos, float oponentPos, float time, int countLap, int points) {
            this.playerPos = playerPos;
            this.oponentPos = oponentPos;
            this.time = time;
            this.countLap = countLap;
            this.points = points;
        }

        public float GetPlayerPos() { return playerPos; }
        public float GetOponentPos() { return oponentPos; }
        public float GetTime() { return time; }
        public int GetCountLap() { return countLap; }
        public int GetPoints() { return points; }
    }
}
