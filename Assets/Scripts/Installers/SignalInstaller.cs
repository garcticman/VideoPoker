using Game;
using Game.UI;
using MiscUtil.Collections.Extensions;
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
            
            Container.DeclareSignal<SignalOpenCloseCards>();
            Container.BindSignal<SignalOpenCloseCards>()
                .ToMethod<HoldButtonsContainer>(cont => cont.SwitchGameObjectState)
                .FromResolve();
            Container.BindSignal<SignalOpenCloseCards>()
                .ToMethod<DealButton>(button => button.SwitchGameObjectState)
                .FromResolve();
            
            Container.DeclareSignal<SignalResetHoldButtons>();
            Container.BindSignal<SignalResetHoldButtons>()
                .ToMethod<HoldButton>(holdButton => holdButton.ResetToInitial)
                .FromResolveAll();
            
            Container.DeclareSignal<SignalCombinationMade>();
            Container.BindSignal<SignalCombinationMade>()
                .ToMethod<CombinationText>(text => text.SetCombination)
                .FromResolve();
        }
    }
}