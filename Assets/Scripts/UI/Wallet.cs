using Services.Progress;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Wallet: MonoBehaviour
    {
        public TextMeshProUGUI yellowText;
        public TextMeshProUGUI blueText;
        public TextMeshProUGUI pinkText;
        public TextMeshProUGUI greenText;
        public TextMeshProUGUI skyText;
        public TextMeshProUGUI orangeText;
        public TextMeshProUGUI redText;
        
        public void UpdateCoins(Progress progress)
        {
            yellowText.text = progress.YellowCoins.ToString();
            blueText.text = progress.BlueCoins.ToString();
            pinkText.text = progress.PinkCoins.ToString();
            greenText.text = progress.GreenCoins.ToString();
            skyText.text = progress.SkyCoins.ToString();
            orangeText.text = progress.OrangeCoins.ToString();
            redText.text = progress.RedCoins.ToString();
        }
    }
}