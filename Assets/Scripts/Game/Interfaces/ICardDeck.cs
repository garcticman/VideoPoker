using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace Game.Interfaces
{
    public interface ICardDeck
    {
        public Card[] DealCards(int count);
        public Sprite GetCardBack();
    }
}