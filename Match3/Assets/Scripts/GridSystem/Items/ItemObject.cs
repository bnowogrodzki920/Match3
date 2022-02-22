using UnityEngine;

namespace Grid.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
    public class ItemObject : ScriptableObject
    {
        public Sprite sprite;
        public Color color;
    }
}