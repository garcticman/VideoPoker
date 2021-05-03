using System;
using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CardsData")]
    public class CardsData : ScriptableObject
    {
        [SerializeField] private Sprite backVisual;

        public Sprite BackVisual
        {
            get => backVisual;
            private set => backVisual = value;
        }

        [SerializeField] private List<CardData> cards = new List<CardData>();

        public List<CardData> Cards
        {
            get => cards;
            private set => cards = value;
        }
    }
}