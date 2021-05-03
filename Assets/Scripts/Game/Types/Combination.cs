using System.Collections.Generic;
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
        
        protected List<CardData> SortByRank(CardData[] cards)
        {
            var sortedByRank = new List<CardData>(cards);
            sortedByRank.Sort((x, y) => x.rank.CompareTo(y.rank));
            
            return sortedByRank;
        }
    }
}