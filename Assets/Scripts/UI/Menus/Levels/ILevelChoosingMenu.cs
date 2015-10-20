namespace Assets.Scripts.UI.Menus.Levels {
    using System.Collections.Generic;
    using State.Levels;

    internal interface ILevelChoosingMenu {
        IEnumerable<ILevel> Levels { set; } 
    }
}