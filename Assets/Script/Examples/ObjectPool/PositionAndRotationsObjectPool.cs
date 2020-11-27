using com.Neogoma.HoboDream;
using com.Neogoma.HoboDream.Util;
using UnityEngine;

namespace Neogoma.Hobodream.Examples.ObjectPool
{
    /// <summary>
    /// Example of implementation of the <see cref="AbstractGameobjectPoolManager{T}"/> using <see cref="PositionsAndRotationsClass"/>
    /// </summary>
    public class PositionAndRotationsObjectPool : AbstractGameobjectPoolManager<PositionsAndRotationsClass>
    {
        /// <inheritdoc/>
        public PositionAndRotationsObjectPool(GameObject prefab, Transform root, params IInteractiveElementListener[] listeners) : base(prefab, root, listeners)
        {
        }

        protected override void InitializeGameobject(GameObject node, IInteractiveElementListener[] listeners, PositionsAndRotationsClass item)
        {

            node.transform.position = item.Position;
            node.transform.rotation = item.Rotation;
            
        }

        protected override void UpdateGameObject(GameObject node, IInteractiveElementListener[] listeners, PositionsAndRotationsClass item)
        {
            node.transform.position = item.Position;
            node.transform.rotation = item.Rotation;

            node.SetActive(true);
        }
    }
}
