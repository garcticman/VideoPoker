using Signals;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class HoldButtonsContainer : MonoBehaviour
    {
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
    }
}
