using System;

namespace Services.Progress
{
    [Serializable]
    public class Progress
    {
        public int YellowCoins;
        public int BlueCoins;
        public int PinkCoins;
        public int GreenCoins;
        public int SkyCoins;
        public int OrangeCoins;
        public int RedCoins;

        public int UpdateProgress(int addCoins, CoinType coinType) => coinType switch
        {
            CoinType.Yellow => YellowCoins += addCoins,
            CoinType.Blue => BlueCoins += addCoins,
            CoinType.Pink => PinkCoins += addCoins,
            CoinType.Green => GreenCoins += addCoins,
            CoinType.Sky => SkyCoins += addCoins,
            CoinType.Orange => OrangeCoins += addCoins,
            CoinType.Red => RedCoins += addCoins,
            _ => throw new ArgumentOutOfRangeException(nameof(coinType), $"Unknown coin type: {coinType}"),
        };
    }
}