using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Grid.Items;
using System.Linq;

namespace Grid
{
    public class GridController : IGridController
    {
        private IGridView view;
        private Vector2 gridSize;
        private GridSlotBackgroundView gridSlotBackgroundViewPrefab;
        private GridSlot gridSlotPrefab;
        private GridSlotsHolder slotsHolder;
        private List<ItemObject> items;
        private List<SpecialItem> specialItems;
        private Dictionary<Vector2, GridSlot> slots;

        [Inject]
        private void Construct(IGridView view,
                               Settings settings)
        {
            this.view = view;
            this.gridSize = settings.gridSize;
            this.gridSlotBackgroundViewPrefab = settings.gridSlotBackgroundViewPrefab;
            this.gridSlotPrefab = settings.gridSlotPrefab;
            this.slotsHolder = settings.slotsHolder;
            SetupItemList(settings.itemsPath);
            SetupGridBackground();
            SetupGrid();
        }

        private void SetupItemList(string path)
        {
            this.items = Resources.LoadAll<ItemObject>(path).ToList();
            this.specialItems = new List<SpecialItem>();
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if(items[i] is SpecialItem)
                {
                    specialItems.Add((SpecialItem)items[i]);
                    items.Remove(items[i]);
                }
            }
        }

        private void SetupGridBackground()
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    Object.Instantiate(gridSlotBackgroundViewPrefab, GetWorldPosition(view.transform.GetChild(0), x,y), Quaternion.identity, view.transform.GetChild(0));
                }
            }
        }

        public void SetupGrid()
        {
            slots = new Dictionary<Vector2, GridSlot>();
            for (int y = 0; y < gridSize.y; y++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    var slot = Object.Instantiate(gridSlotPrefab, slotsHolder.transform);
                    slot.transform.position = GetWorldPosition(slotsHolder.transform, x, y);
                    slot.SetData(GetRandomItem());
                    slots.Add(new Vector2(x, y), slot);
                }
            }

            int randX = (int)Random.Range(0, gridSize.x);
            int randY = (int)Random.Range(0, gridSize.y);
            SetSlotToSpecial(new Vector2(randX, randY), SpecialItem.SpecialItemType.DESTROY_ALL_OF_TYPE);
            randX = (int)Random.Range(0, gridSize.x);
            randY = (int)Random.Range(0, gridSize.y);
            SetSlotToSpecial(new Vector2(randX, randY), SpecialItem.SpecialItemType.DESTROY_NEIGHBOURS);
        }

        private void SetSlotToSpecial(Vector2 key, SpecialItem.SpecialItemType specialItemType)
        {
            slots[key].SetData(specialItems.Find(x => x.type == specialItemType));
        }

        private Vector2 GetWorldPosition(Transform relativeTransform, int x, int y)
        {
            return new Vector2((relativeTransform.position.x - gridSize.x) / 2f + x * 50, (relativeTransform.position.y - gridSize.y) / 2f + y * 50);
        }

        private ItemObject GetRandomItem()
        {
            return items[Random.Range(0, items.Count)];
        }

        [System.Serializable]
        public class Settings
        {
            public Vector2 gridSize = new Vector2(8,8);
            public string itemsPath = "";
            public GridSlot gridSlotPrefab;
            public GridSlotsHolder slotsHolder;
            public GridSlotBackgroundView gridSlotBackgroundViewPrefab;
        }
    }
}