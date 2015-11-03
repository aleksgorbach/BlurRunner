// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:56

namespace Assets.Scripts.Localization.Locales {
    internal interface ILocale {
        string this[string key] { get; }
    }
}