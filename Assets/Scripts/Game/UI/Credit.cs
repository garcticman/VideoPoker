using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class Credit : MonoBehaviour
    {
        [SerializeField] private Text text;
        
        public void OnCreditChanged(SignalCreditChanged coins)
        {
            text.text = coins.Coins.ToString();
        }
    }
}
