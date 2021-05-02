using Game;
using Game.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private CardHolder cardHolderPrefab;

        [SerializeField] private UserCoins userCoins;
        [SerializeField] private Credit credit;
        [SerializeField] private HoldButtonsContainer holdButtonsContainer;
        [SerializeField] private DealButton dealButton;

        public override void InstallBindings()
        {
            var cardHolder = Container.InstantiatePrefabForComponent<CardHolder>(cardHolderPrefab);
            Container.Bind<CardHolder>().FromInstance(cardHolder);

            Container.BindInstance(userCoins);
            Container.BindInstance(credit);
            Container.BindInstance(holdButtonsContainer);
            Container.BindInstance(dealButton);

            Container.Bind<SlotMachine>().AsSingle().NonLazy();
        }
    }
}