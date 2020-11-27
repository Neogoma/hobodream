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
            SetupDatas(allCubes,cubeObjectPool);
        }

        /// <summary>
        /// Randomly generates sphere
        /// </summary>
        public void GenerateSpheres()
        {
            SetupDatas(allSpheres,sphereObjectPool);
            
        }

        private void SetupDatas(List<PositionsAndRotationsClass> listToFill,PositionAndRotationsObjectPool poolToUse)
        {
            ClearDatas();

            int numberOfItems = Random.Range(1, maximumRandomToGenerate);

            for (int i = 0; i < numberOfItems; i++)
            {
                listToFill.Add(new PositionsAndRotationsClass());
            }

            poolToUse.AddItems(listToFill.ToArray());
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