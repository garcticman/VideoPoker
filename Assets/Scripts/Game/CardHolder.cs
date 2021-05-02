using System;
using System.Collections.Generic;
using Game.Interfaces;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CardHolder : MonoBehaviour
    {
        [NonSerialized] public bool IsFilled;
        
        private ICardDeck _cardDeck;
        private SpriteRenderer[] _cards;
        private HashSet<int> _holdedCards = new HashSet<int>();

        [Inject]
        private void Construct(ICardDeck cardDeck)
        {
            _cardDeck = cardDeck;
            _cards = GetComponentsInChildren<SpriteRenderer>();

            InitTable();
        }
        
        private void InitTable()
        {
            var cardsBack = _cardDeck.GetCardBack();
            foreach (var t in _cards)
            {
                t.sprite = cardsBack;
            }
        }

        public void FillCards()
        {
            var cardsData = _cardDeck.DealCards(_cards.Length);
            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i].sprite = cardsData[i].cardSprite;
            }
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
