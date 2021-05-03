using System.Collections.Generic;
using System.Linq;
using Game.Types;
using UnityEngine;

namespace ScriptableObjects.Combinations
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Combinations/ThreeOfAKind")]
    public class ThreeOfAKind : Combination
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

            return rankToCount.Any(x => x.Value == 3) ? combinationRank : 0;
        }
    }
}
