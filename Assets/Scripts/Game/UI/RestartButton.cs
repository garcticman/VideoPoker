using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class RestartButton : MonoBehaviour
    {
        private SlotMachine _slotMachine;
        
        [Inject]
        private void Construct(SlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }

        public void Restart()
        {
            _slotMachine.Restart();
        }
    }
}
