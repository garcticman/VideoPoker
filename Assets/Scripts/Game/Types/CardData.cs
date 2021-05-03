using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Types
{
    [Serializable]
    public struct CardData
    {
        public Sprite cardSprite;
        public byte rank;
        public Suits suite;
    }

    [Serializable]
    public struct Card
    {
        public CardData data;
        public SpriteRenderer renderer;
    }
}