// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:45

namespace Assets.Scripts.EndlessEngine.Ground.Decorations.UI {
    #region References

    using Ground.UI;

    #endregion

    internal interface IDecorationGeneratorUI {
        /// <summary>
        /// Add item to game
        /// </summary>
        /// <param name="created">Decoration item to add</param>
        /// <param name="block">Block that item has to matched with</param>
        void Add(DecorationItemUI created, GroundBlockUI block);
    }
}