using Game.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Types
{
    public abstract class Combination : ScriptableObject
    {
        [SerializeField] protected string combinationName;

        public string CombinationName => combinationName;

        [SerializeField] protected int combinationRank;

        public int CombinationRank => combinationRank;

        public abstract int CheckCombination(CardData[] cards);
    }
}