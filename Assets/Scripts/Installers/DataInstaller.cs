using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "DataInstaller", menuName = "Installers/DataInstaller")]
    public class DataInstaller : ScriptableObjectInstaller<DataInstaller>
    {
        [SerializeField] private CardsData cardsData;
        [SerializeField] private CombinationsData combinationsData;
        public override void InstallBindings()
        {
            Container.Bind<CardsData>().FromInstance(cardsData).AsSingle();
            Container.Bind<CombinationsData>().FromInstance(combinationsData).AsSingle();
        }
    }
}