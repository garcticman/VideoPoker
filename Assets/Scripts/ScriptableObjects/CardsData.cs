using System;
using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CardsData")]
    public class CardsData : ScriptableObject
    {
        [SerializeField] private List<Card> cards = new List<Card>();

        public List<Card> Cards
        {
            get => cards;
            private set => cards = value;
        }
    }
}