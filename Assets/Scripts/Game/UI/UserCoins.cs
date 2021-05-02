using System.Runtime.InteropServices;
using MiscUtil.Collections.Extensions;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class UserCoins : MonoBehaviour
    {
        [SerializeField] private Text text;
        
        public void OnCointCountChanged(SignalCoinsChanged coins)
        {
            text.text = coins.Coins.ToString();
        }
    }
}
