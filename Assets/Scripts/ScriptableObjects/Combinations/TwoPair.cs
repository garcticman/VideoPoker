using System.Collections.Generic;
using System.Linq;
using Game.Types;
using UnityEngine;

namespace ScriptableObjects.Combinations
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Combinations/TwoPair")]
    public class TwoPair : Combination
    {
        public override int CheckCombination(CardData[] cards)
        {
            Dictionary<int, int> rankToCount = new Dictionary<int, int>();
            foreach (var card in cards)
            {
                if (rankToCount.ContainsKey(card.rank))
                {
                    rankToCount[card.rank]++;
                }
                else
                {
                    rankToCount.Add(card.rank, 1);
                }
            }

            var pairs = rankToCount.Where(x => x.Value == 2);
            var pairCount = pairs.Count();
            return pairCount >= 2 ? combinationRank : 0;
        }
    }
}
