namespace Assets.Scripts.State.Progress {
    class LevelProgress : ILevelProgress {
        public int Number { get; private set; }
        public int Stars { get; private set; }

        public LevelProgress(int number, int stars) {
            Number = number;
            Stars = stars;
        }
    }
}
