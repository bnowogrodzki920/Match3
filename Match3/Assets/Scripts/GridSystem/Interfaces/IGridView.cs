using UI;
using UnityEngine;

namespace Grid
{
    public interface IGridView : IView
    {
        Transform transform { get; }
        void SetData();
    }
}