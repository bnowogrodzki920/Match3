using UnityEngine;
using Zenject;

namespace Grid
{
    public class GridController : IGridController
    {
        private IGridView view;
        private Vector2 gridSize;

        [Inject]
        private void Construct(IGridView view, Settings settings)
        {
            this.view = view;
            this.gridSize = settings.gridSize;
            SetupGrid();
        }

        public void SetupGrid()
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {

                }
            }
        }

        [System.Serializable]
        public class Settings
        {
            public Vector2 gridSize = new Vector2(8,8);
        }
    }
}