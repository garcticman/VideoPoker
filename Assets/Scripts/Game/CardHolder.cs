using System.Collections.Generic;
using System.Linq;
using Game.Interfaces;
using Game.Types;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CardHolder : MonoBehaviour
    {
        public bool IsFilled { get; private set; } = false;
        
        private readonly SortedList<int, Combination> _combinations = new SortedList<int, Combination>();

        private ICardDeck _cardDeck;
        private Card[] _cards;
        private readonly HashSet<int> _holdedCards = new HashSet<int>();

        [Inject]
        private void Construct(ICardDeck cardDeck, CombinationsData combinationsData)
        {
            _cardDeck = cardDeck;

            InitCombinations(combinationsData);
            InitCardsVisual();
            InitTable();
        }

        private void InitCombinations(CombinationsData combinationsData)
        {
            foreach (var data in combinationsData.Combinations)
            {   
                _combinations.Add(data.CombinationRank, data);
            }
        }
        private void InitCardsVisual()
        {
            var cardsRenderers = GetComponentsInChildren<SpriteRenderer>();
            _cards = new Card[cardsRenderers.Length];
            for (int i = 0; i < cardsRenderers.Length; i++)
            {
                _cards[i].renderer = cardsRenderers[i];
            }
        }
        
        public void InitTable()
        {
            var cardsBack = _cardDeck.GetCardBack();
            foreach (var card in _cards)
            {
                card.renderer.sprite = cardsBack;
            }
        }

        public void FillCards()
        {
            var cardsCount = _cards.Length - _holdedCards.Count;
            
            var cardsData = _cardDeck.DealCards(cardsCount);
            for (int i = 0, j = 0; i < _cards.Length; i++)
            {
                if (_holdedCards.Contains(i))
                {
                    continue;
                }
                
                _cards[i].data = cardsData[j];
                _cards[i].renderer.sprite = cardsData[j].cardSprite;
                
                j++;
            }

            IsFilled = true;
        }

        public Combination TryGetCombination()
        {
            var cardsData = _cards.Select(x => x.data).ToArray();
            foreach (var combination in _combinations.Reverse())
            {
                if (combination.Value.CheckCombination(cardsData) > 0)
                {
                    return combination.Value;
                }
            }

            return null;
        }

        public void ResetTable()
        {
            IsFilled = false;
            _holdedCards.Clear();
            _cardDeck.Reset();
        }

        public void HoldCard(int index)
        {
            _holdedCards.Add(index);
        }
        public void DiscardCard(int index)
        {
            _holdedCards.Remove(index);
        }
    }
}
