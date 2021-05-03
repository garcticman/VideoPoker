using System.Collections.Generic;
using Game.Interfaces;
using Game.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Combinations")]
    public class CombinationsData : ScriptableObject
    {
        [SerializeField] private List<Combination> combinations = new List<Combination>();

        public List<Combination> Combinations
        {
            get => combinations;
            private set => combinations = value;
        }
    }
}