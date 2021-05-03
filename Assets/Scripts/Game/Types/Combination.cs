using Game.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Types
{
    public abstract class Combination : ScriptableObject
    {
        [SerializeField] public string combinationName;

        public string CombinationName
        {
            get => combinationName;
            private set => combinationName = value;
        }

        [SerializeField] protected int combinationRank;
        public abstract int CheckCombination(CardData[] cards);
    }
}