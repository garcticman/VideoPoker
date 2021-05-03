using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace Game.Interfaces
{
    public interface ICardDeck
    {
        public CardData[] DealCards(int count);
        public Sprite GetCardBack();
        void Reset();
    }
}