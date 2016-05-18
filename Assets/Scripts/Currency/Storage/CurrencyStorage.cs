namespace Assets.Scripts.Currency.Storage {
    using System;

    class CurrencyStorage : ICurrencyStorage {
        public int GetBalanse(CurrencyType currencyType = CurrencyType.Coins) {
            throw new NotImplementedException();
        }

        public event Action<int, CurrencyType> NotEnoughRequestedCurrency;
        public bool Spend(int amount, CurrencyType currencyType = CurrencyType.Coins) {
            throw new NotImplementedException();
        }
    }
}
