// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:54

namespace Assets.Scripts.Localization.Localizators {
    internal interface ILocalizator {
        string Localize(ILocalizable text);
    }
}