// Created 22.10.2015
// Modified by  30.11.2015 at 14:01

namespace Assets.Scripts.State.Levels {
    #region References

    using Data;

    #endregion

    internal class Level : ILevel {
        private readonly LevelData _data;

        public Level(LevelData data) {
            _data = data;
        }

        public int Number {
            get { return _data.LevelNumber; }
        }

        public string Background {
            get { return _data.Background; }
        }

        public int HeroAge {
            get { return _data.HeroAge; }
        }

        public string HeroPrefab {
            get { return _data.Hero; }
        }

        public string SceneName {
            get { return _data.Scene; }
        }
    }
}