using Signals;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class CoinButton : MonoBehaviour
    {
        private SlotMachine _slotMachine;
        
        [Inject]
        private void Construct(SlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }
        
        public void CoinButtonPressed()
        {
            _slotMachine.CoinButtonPressed();
        }
    }
}
