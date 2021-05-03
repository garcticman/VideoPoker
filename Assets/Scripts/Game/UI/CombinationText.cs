using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CombinationText : MonoBehaviour
    {
        private Animator _animator;
        private Text _text;
        private static readonly int Action = Animator.StringToHash("Action");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _text = GetComponent<Text>();
        }

        public void SetCombination(SignalCombinationMade signal)
        {
            _animator.SetTrigger(Action);
            _text.text = signal.CombinationName;
        }
    }
}
