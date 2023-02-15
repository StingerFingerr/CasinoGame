using Services.Progress;
using TMPro;
using UnityEngine;

namespace GamePlay
{
    public class WheelItem: MonoBehaviour
    {
        public int reward;
        public CoinType type;
        public TextMeshProUGUI rewardText;

        private void Awake() => 
            rewardText.text = reward.ToString();
    }
}