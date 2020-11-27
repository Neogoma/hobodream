using UnityEngine;

namespace Neogoma.Hobodream.Examples.ObjectPool
{
    /// <summary>
    /// Class example that will
    /// </summary>
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


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        public PositionsAndRotationsClass()
        {
            position = Random.onUnitSphere * Random.Range(0, 10);
            rotation = Random.rotation;
            
        }
    }

    
}
