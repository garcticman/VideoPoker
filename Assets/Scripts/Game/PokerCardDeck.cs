using System;
using System.Collections.Generic;
using Game.Interfaces;
using Game.Types;
using ScriptableObjects;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    public class PokerCardDeck : ICardDeck
    {
        private readonly CardsData _cardsData;
        private List<Card> _deck;

        public PokerCardDeck(CardsData cardsData)
        {
            _cardsData = cardsData;

            _deck = new List<Card>(cardsData.Cards);
        }

        public Card[] DealCards(int count)
        {
            Card[] onHandCards = new Card[count];
            
            for (int i = 0; i < count; i++)
            {
                var cardIndex = Random.Range(0, _deck.Count);
                onHandCards[i] = _deck[cardIndex];
                _deck.RemoveAt(cardIndex);
            }

            return onHandCards;
        }
    }
}