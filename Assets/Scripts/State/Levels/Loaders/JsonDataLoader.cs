namespace Assets.Scripts.State.Levels.Loaders {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    internal class JsonDataLoader : ILevelLoader {
        private readonly string _json;

        public JsonDataLoader(string json) {
            _json = json;
        }

        public void Load() {
            var levels = new LevelsParser().Parse(_json);
            if (Loaded != null) {
                Loaded(levels.ToList());
            }
        }

        public event Action<List<LevelData>> Loaded;
    }

    public class LevelsParser {
        public IEnumerable<LevelData> Parse(string json) {
            var obj = new JSONObject(json);
            foreach (var entry in obj.list) {
                yield return new LevelData {
                    Background = entry["background"].ToString().Trim('\"'),
                    LevelNumber = int.Parse(entry["level"].ToString().Trim('\"')),
                    HeroAge = int.Parse(entry["age"].ToString().Trim('\"')),
                    Hero = entry["hero"].ToString().Trim('\"'),
                    Scene = entry["scene"].ToString().Trim('\"')
                };
            }
        }
    }
}