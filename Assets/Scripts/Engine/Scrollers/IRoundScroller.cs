namespace Assets.Scripts.Engine.Scrollers {
    using System;

    internal interface IRoundScroller {
        IScrollerItem Current { get; }

        void AddItem(IScrollerItem item);

        void ScrollNext();

        void ScrollPrevious();

        event Action<IScrollerItem> CurrentChanged;
    }
}