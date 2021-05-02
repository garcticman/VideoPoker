using Game;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public Canvas mainSceneCanvas;
        public CardHolder cardHolderPrefab;
        public override void InstallBindings()
        {
            Container.InstantiatePrefabForComponent<CardHolder>(cardHolderPrefab);
        }
    }
}