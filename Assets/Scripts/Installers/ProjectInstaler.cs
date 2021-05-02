using Game;
using Game.Interfaces;
using Zenject;

namespace Installers
{
    public class ProjectInstaler : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Bind<ICardDeck>().To<PokerCardDeck>().AsSingle().NonLazy();
        }
    }
}