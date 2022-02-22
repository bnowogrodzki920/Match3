using UnityEngine;

namespace Grid.Items
{
    [CreateAssetMenu(fileName = "New Special Item", menuName = "Items/New Special Item")]
    public class SpecialItem : ItemObject
    {
        public SpecialItemType type;

        public enum SpecialItemType
        {
            DESTROY_ALL_OF_TYPE,
            DESTROY_NEIGHBOURS,
            DESTROY_ROWS,
            DESTROY_ROW_VERTICAL,
            DESTROY_ROW_HORIZONTAL,
        }
    }
}