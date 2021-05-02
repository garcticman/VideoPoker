using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class HoldButtonsContainer : MonoBehaviour
    {
        public void SwitchGameObjectState()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
