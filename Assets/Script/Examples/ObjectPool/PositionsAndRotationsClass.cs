using UnityEngine;

namespace Neogoma.Hobodream.Examples.ObjectPool
{
    public class PositionsAndRotationsClass
    {
        private Vector3 position;

        /// <summary>
        /// Position of the object
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return position;
            }
        }

        private Quaternion rotation;

        /// <summary>
        /// Rotation of the object
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                return rotation;
            }
        }

        private PrimitiveType primitive;
        
        public PrimitiveType Primitive
        {
            get
            {
                return primitive;
            }
        }

        public PositionsAndRotationsClass(PrimitiveType type)
        {
            position = Random.onUnitSphere * Random.Range(0, 10);
            rotation = Random.rotation;
            primitive = type;
        }
    }

    
}
