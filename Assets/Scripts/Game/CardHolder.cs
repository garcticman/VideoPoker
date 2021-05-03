using System;
using System.Collections.Generic;
using Game.Interfaces;
using Game.Types;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CardHolder : MonoBehaviour
    {
        [NonSerialized] public bool IsFilled;
        
        private ICardDeck _cardDeck;
        private Card[] _cards;
        private HashSet<int> _holdedCards = new HashSet<int>();

        [Inject]
        private void Construct(ICardDeck cardDeck)
        {
            _cardDeck = cardDeck;
            
            InitCardsVisual();
            InitTable();
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
        
        private void InitTable()
        {
            var cardsBack = _cardDeck.GetCardBack();
            foreach (var card in _cards)
            {
                card.renderer.sprite = cardsBack;
            }
        }

        public void FillCards()
        {
            var cardsData = _cardDeck.DealCards(_cards.Length);
            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i].data = cardsData[i];
                _cards[i].renderer.sprite = cardsData[i].cardSprite;
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
