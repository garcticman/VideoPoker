using System.Collections.Generic;
using Game.Types;

namespace Game.Interfaces
{
    public interface ICardDeck
    {
        public Card[] DealCards(int count);
    }
}