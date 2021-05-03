using Game.Types;
using UnityEngine;

namespace ScriptableObjects.Combinations
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Combinations/RoyalFlush")]
    public class RoyalFlush : Combination
    {
        public override int CheckCombination(CardData[] cards)
        {
            var sortedByRank = SortByRank(cards);
            if (sortedByRank[0].rank != 10)
            {
                return 0;
            }
            
            for (int i = 1; i < sortedByRank.Count; i++)
            {
                if ((sortedByRank[i].rank - sortedByRank[i - 1].rank > 1) ||
                    sortedByRank[i].suite != sortedByRank[i - 1].suite)
                {
                    return 0;
                }
            }

            return combinationRank;
        }
    }
}
