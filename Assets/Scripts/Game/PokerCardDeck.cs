using System;
using System.Collections.Generic;
using Game.Interfaces;
using Game.Types;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    public class PokerCardDeck : ICardDeck
    {
        private readonly CardsData _cardsData;
        private List<CardData> _deck;

        public PokerCardDeck(CardsData cardsData)
        {
            _cardsData = cardsData;

            _deck = new List<CardData>(cardsData.Cards);
        }

        public CardData[] DealCards(int count)
        {
            CardData[] onHandCards = new CardData[count];
            
            for (int i = 0; i < count; i++)
            {
                var cardIndex = Random.Range(0, _deck.Count);
                onHandCards[i] = _deck[cardIndex];
                _deck.RemoveAt(cardIndex);
            }

            return onHandCards;
        }

        public Sprite GetCardBack()
        {
            return _cardsData.BackVisual;
        }
    }
}