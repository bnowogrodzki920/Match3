using UnityEngine;
using UnityEngine.UI;
using Grid.Items;

namespace Grid
{

    public class GridSlot : MonoBehaviour
    {
        [SerializeField]
        private ItemObject currentItem;
        [SerializeField]
        private Image image;  

        public ItemObject CurrentItem => currentItem;

        public void SetData(ItemObject item)
        {
            if (item == null) return;
            this.image.sprite = item.sprite;
            this.image.color = item.color;
            this.currentItem = item;
        }

        public void Move(int x, int y)
        {

        }
    }
}