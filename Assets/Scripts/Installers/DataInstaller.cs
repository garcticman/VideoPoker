using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "DataInstaller", menuName = "Installers/DataInstaller")]
    public class DataInstaller : ScriptableObjectInstaller<DataInstaller>
    {
        [SerializeField] private CardsData cardsData;
        public override void InstallBindings()
        {
            Container.Bind<CardsData>().FromInstance(cardsData).AsSingle();
        }
    }
}