using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace ScriptableObjects.Combinations
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Combinations/Straight")]
    public class Straight : Combination
    {
        public override int CheckCombination(CardData[] cards)
        {
            var sortedByRank = SortByRank(cards);
            for (int i = 1; i < sortedByRank.Count; i++)
            {
                if (sortedByRank[i].rank - sortedByRank[i - 1].rank != 1)
                {
                    return 0;
                }
            }

            return combinationRank;
        }
    }
}