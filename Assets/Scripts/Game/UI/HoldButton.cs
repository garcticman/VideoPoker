using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;
using Button = UnityEngine.UIElements.Button;

namespace Game.UI
{
    public class HoldButton : MonoBehaviour
    {
        [SerializeField] private byte id;

        public byte ID => id;

        private Text _text;
        private CardHolder _cardHolder;
        private bool _isHolded;

        [Inject]
        private void Construct(CardHolder cardHolder)
        {
            _text = GetComponentInChildren<Text>(true);
            _cardHolder = cardHolder;
        }

        public void HoldPressed()
        {
            if (_isHolded)
            {
                ResetToInitial();
            }
            else
            {
                SetToHolded();
            }
        }

        public void ResetToInitial()
        {
            _isHolded = false;
            _text.text = "Hold";
            _cardHolder.DiscardCard(id);
        }

        private void SetToHolded()
        {
            _isHolded = true;
            _text.text = "Discard";
            _cardHolder.HoldCard(id);
        }
    }
}
