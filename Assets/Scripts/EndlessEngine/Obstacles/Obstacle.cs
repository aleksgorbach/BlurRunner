// Created 20.11.2015
// Modified by  20.11.2015 at 13:37

namespace Assets.Scripts.EndlessEngine.Obstacles {
    internal class Obstacle : HidingItem<Obstacle> {
        protected override Obstacle Instance {
            get { return this; }
        }
    }
}