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
        [SerializeField] private CombinationText combinationText;
        
        public override void InstallBindings()
        {
            var cardHolder = Container.InstantiatePrefabForComponent<CardHolder>(cardHolderPrefab);
            Container.Bind<CardHolder>().FromInstance(cardHolder);

            Container.BindInstance(userCoins);
            Container.BindInstance(credit);
            Container.BindInstance(holdButtonsContainer);
            Container.BindInstance(dealButton);
            Container.BindInstance(combinationText);

            BindHoldButtons();

            Container.Bind<SlotMachine>().AsSingle().NonLazy();
        }

        private void BindHoldButtons()
        {
            var holdButtons = holdButtonsContainer.GetComponentsInChildren<HoldButton>();
            foreach (var button in holdButtons)
            {
                Container.BindInstance(button).AsTransient();
            }
        }
    }
}