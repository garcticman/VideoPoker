using Signals;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class DealButton : MonoBehaviour
    {
        private SlotMachine _slotMachine;

        [Inject]
        private void Construct(SlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }
        public void SwitchGameObjectState(SignalOpenCloseCards openCloseCards)
        {
            if (openCloseCards.ForceClose)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }

        public void OnDealButtonPressed()
        {
            _slotMachine.Deal();
        }
    }
}
