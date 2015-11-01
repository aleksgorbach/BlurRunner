// Created 01.11.2015
// Modified by Александр 01.11.2015 at 18:52

namespace Assets.Scripts.Engine.Scrollers {
    using UnityEngine;

    internal interface IScrollerItem {
        RectTransform Transform { get; }
    }
}