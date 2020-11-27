using System.Collections.Generic;
using UnityEngine;


namespace Neogoma.Hobodream.Examples.ObjectPool
{
    /// <summary>
    /// Example for the object pool
    /// </summary>
    public class ObjectPoolExample : MonoBehaviour
    {
        public Transform cubePoolRoot;
        public Transform spherePoolRoot;

        public GameObject cubePrefab;
        public GameObject spherePrefab;

        public int maximumRandomToGenerate=100;

        private PositionAndRotationsObjectPool cubeObjectPool;
        private List<PositionsAndRotationsClass> allCubes = new List<PositionsAndRotationsClass>();
        private List<PositionsAndRotationsClass> allSpheres = new List<PositionsAndRotationsClass>();
        

        private PositionAndRotationsObjectPool sphereObjectPool;

        public void Awake()
        {
            cubeObjectPool = new PositionAndRotationsObjectPool(cubePrefab, cubePoolRoot);

            sphereObjectPool = new PositionAndRotationsObjectPool(spherePrefab, spherePoolRoot);

        }

        /// <summary>
        /// Randomly generates the cubes
        /// </summary>
        public void GenerateCubes()
        {
            ClearDatas();

            int numberOfItems=Random.Range(1, maximumRandomToGenerate);

            for (int i = 0; i < numberOfItems; i++)
            {
                allCubes.Add(new PositionsAndRotationsClass(PrimitiveType.Cube));
            }

            cubeObjectPool.AddItems(allCubes.ToArray());
        }

        /// <summary>
        /// Randomly generates sphere
        /// </summary>
        public void GenerateSpheres()
        {
            ClearDatas();

            int numberOfItems = Random.Range(1, maximumRandomToGenerate);

            for (int i = 0; i < numberOfItems; i++)
            {
                allSpheres.Add(new PositionsAndRotationsClass(PrimitiveType.Sphere));
            }

            sphereObjectPool.AddItems(allSpheres.ToArray());
        }


        private void ClearDatas()
        {
            cubeObjectPool.Clean();
            sphereObjectPool.Clean();


            allSpheres.Clear();
            allCubes.Clear();
        }
    }
}