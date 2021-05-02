using System;
using UnityEngine;

namespace Game.Types
{
    [Serializable]
    public struct Card
    {
        public Sprite cardSprite;
        public byte rank;
        public Suits suite;
    }
}