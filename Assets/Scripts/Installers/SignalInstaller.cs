using Game;
using Game.UI;
using Signals;
using Zenject;

namespace Installers
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalCoinsChanged>();
            Container.BindSignal<SignalCoinsChanged>()
                .ToMethod<UserCoins>(coins => coins.OnCointCountChanged)
                .FromResolve();
            
            Container.DeclareSignal<SignalCreditChanged>();
            Container.BindSignal<SignalCreditChanged>()
                .ToMethod<Credit>(coins => coins.OnCreditChanged)
                .FromResolve();
            
            Container.DeclareSignal<SignalOpenCards>();
            Container.BindSignal<SignalOpenCards>()
                .ToMethod<HoldButtonsContainer>(cont => cont.SwitchGameObjectState)
                .FromResolve();
            Container.BindSignal<SignalOpenCards>()
                .ToMethod<DealButton>(button => button.SwitchGameObjectState)
                .FromResolve();
        }
    }
}