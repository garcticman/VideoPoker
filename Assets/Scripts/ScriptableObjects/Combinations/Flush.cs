using Game.Types;
using UnityEngine;

namespace ScriptableObjects.Combinations
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Combinations/Flush")]
    public class Flush : Combination
    {
        public override int CheckCombination(CardData[] cards)
        {
            var currentSuite = cards[0].suite;
            for (int i = 1; i < cards.Length; i++)
            {
                if (currentSuite != cards[i].suite)
                {
                    return 0;
                }
            }

            return combinationRank;
        }
    }
}
