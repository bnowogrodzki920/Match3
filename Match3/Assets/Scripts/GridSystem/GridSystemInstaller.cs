using UnityEngine;
using Zenject;

namespace Grid
{
    public class GridSystemInstaller : MonoInstaller
    {
        [SerializeField]
        private GridController.Settings settings;
        [SerializeField]
        private GridView gridView;

        public override void InstallBindings()
        {
            Container.Bind<IGridController>().FromSubContainerResolve().ByMethod(InstallSystem).AsSingle().NonLazy();
        }

        private void InstallSystem(DiContainer subContainer)
        {
            subContainer.Bind<IGridController>().To<GridController>().FromNew().AsSingle();
            subContainer.Bind<IGridView>().FromInstance(gridView).AsSingle();
            subContainer.Bind<GridController.Settings>().FromInstance(settings).AsSingle();
        }
    }
}