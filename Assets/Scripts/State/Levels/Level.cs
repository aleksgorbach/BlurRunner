// Created 20.10.2015
// Modified by Александр 20.10.2015 at 18:54

namespace Assets.Scripts.State.Levels {
    internal class Level : ILevel {
        private readonly int _number;

        public Level(int number) {
            _number = number;
        }

        public int Number {
            get { return _number; }
        }
    }
}