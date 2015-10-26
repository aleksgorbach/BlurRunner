// Created 26.10.2015
// Modified by Александр 26.10.2015 at 21:25

namespace DataContracts.Models.Levels {
    public enum Difficulty {
        Easy,
        Medium,
        Hard,
        Extremal
    }

    public class LevelData {
        public int Number { get; set; }
        public Difficulty Difficulty { get; set; }
        public float Length { get; set; }
    }
}