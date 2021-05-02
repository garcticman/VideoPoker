using Signals;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class CoinButton : MonoBehaviour
    {
        private SignalBus _signalBus;
        
        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void CoinButtonPressed()
        {
            _signalBus.Fire(new SignalCoinButton());
        }
    }
}
