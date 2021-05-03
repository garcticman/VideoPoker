using ScriptableObjects;
using Signals;
using UnityEngine;
using Zenject;

namespace Game
{
    public class SlotMachine
    {
        private const int EnoughForGame = 5;

        private readonly SignalBus _signalBus;
        private readonly CardHolder _cardHolder;

        private int _usersCoins;
        private int UsersCoins
        {
            get => _usersCoins;
            set
            {
                _usersCoins = value;
                _signalBus.Fire(new SignalCoinsChanged() {Coins = value});
            }
        }

        private int _credit;
        private int Credit
        {
            get => _credit;
            set
            {
                _credit = value;
                _signalBus.Fire(new SignalCreditChanged() {Coins = value});
            }
        }
        
        public SlotMachine(SignalBus signalBus, CardHolder cardHolder)
        {
            _signalBus = signalBus;
            _cardHolder = cardHolder;

            UsersCoins = EnoughForGame;
            Credit = 0;
        }

        public void CoinButtonPressed()
        {
            if (_usersCoins > 0)
            {
                UsersCoins--;
                Credit++;
                
                if (_credit >= EnoughForGame && !_cardHolder.IsFilled)
                {
                    OpenCards();
                }
            }
        }

        private void OpenCards()
        {
            Credit -= EnoughForGame;
            _cardHolder.FillCards();
            _signalBus.Fire<SignalOpenCloseCards>();
        }

        public void Deal()
        {
            _cardHolder.FillCards();
            HandleCombinations();
            _cardHolder.ResetTable();
            _signalBus.Fire<SignalResetHoldButtons>();
            _signalBus.Fire<SignalOpenCloseCards>();
        }

        private void HandleCombinations()
        {
            var resultCombination = _cardHolder.TryGetCombination();
            if (resultCombination != null)
            {
                Debug.Log(resultCombination.name);
                UsersCoins += EnoughForGame + resultCombination.CombinationRank;
            }
        }
    }
}