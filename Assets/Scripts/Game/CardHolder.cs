using Game.Interfaces;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CardHolder : MonoBehaviour
    {
        private ICardDeck _cardDeck;
        private SpriteRenderer[] _cards;

        [Inject]
        private void Construct(ICardDeck cardDeck)
        {
            _cardDeck = cardDeck;
            _cards = GetComponentsInChildren<SpriteRenderer>();
            
            FillCards();
        }

        private void FillCards()
        {
            var cardsData = _cardDeck.DealCards(_cards.Length);

            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i].sprite = cardsData[i].cardSprite;
            }
        }
    }
}
