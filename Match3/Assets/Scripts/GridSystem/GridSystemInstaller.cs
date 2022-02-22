using UnityEngine;
using Zenject;

namespace Grid
{
    public class GridSystemInstaller : MonoInstaller
    {
        [SerializeField]
        private GridController.Settings settings;

        public override void InstallBindings()
        {
            Container.Bind<IGridController>().FromSubContainerResolve().ByMethod(InstallSystem).AsSingle().NonLazy();
        }

        private void InstallSystem(DiContainer subContainer)
        {

        }
    }
}