// Created 13.12.2015
// Modified by Александр 13.12.2015 at 20:03

namespace Assets.Scripts.Currency.Storage {
    #region References

    using System;

    #endregion

    internal interface ICurrencyStorage {
        int GetBalanse(CurrencyType currencyType = CurrencyType.Coins);

        /// <summary>
        /// Fired when not enough requested currency
        /// </summary>
        event Action<int, CurrencyType> NotEnoughRequestedCurrency;

        bool Spend(int amount, CurrencyType currencyType = CurrencyType.Coins);
    }
}