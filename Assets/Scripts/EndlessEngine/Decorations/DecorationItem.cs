// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 8:46

namespace Assets.Scripts.EndlessEngine.Decorations {
    internal class DecorationItem : HidingItem<DecorationItem> {
        protected override DecorationItem Instance {
            get {
                return this;
            }
        }
    }
}