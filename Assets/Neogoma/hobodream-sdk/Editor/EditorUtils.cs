﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Neogoma.HoboDream.EditorTools
{
    /// <summary>
    /// Class used for editor utilities functions
    /// 用于编辑器实用程序功能的类
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class EditorUtils : MonoBehaviour
    {
        public struct ScriptAndAssociatedGameobject<T>
        {
            public T listener;
            public GameObject gameObject;


        }

        /// <summary>
        /// Use this method to get all loaded objects of some type, including inactive objects. 
        /// This is an alternative to Resources.FindObjectsOfTypeAll (returns project assets, including prefabs), and GameObject.FindObjectsOfTypeAll (deprecated).
        /// 使用此方法获取某些类型的所有已加载对象，包括非活动对象。
        ///这是Resources.FindObjectsOfTypeAll（返回项目资产，包括预制件）和GameObject.FindObjectsOfTypeAll（不建议使用）的替代方法。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> FindObjectsOfTypeAll<T>()
        {
            List<T> results = new List<T>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                if (s.isLoaded)
                {
                    var allGameObjects = s.GetRootGameObjects();
                    for (int j = 0; j < allGameObjects.Length; j++)
                    {
                        var go = allGameObjects[j];
                        results.AddRange(go.GetComponentsInChildren<T>(true));
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Finds the objects of type all with their associated gameobject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<ScriptAndAssociatedGameobject<T>> FindObjectsOfTypeAllWithGameobject<T>()
        {
            List<ScriptAndAssociatedGameobject<T>> results = new List<ScriptAndAssociatedGameobject<T>>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                if (s.isLoaded)
                {
                    
                    List<GameObject> allGameObjects = new List<GameObject>(s.GetRootGameObjects());

                    List<Transform> allTransforms = new List<Transform>();



                    for(int obc=0;obc<allGameObjects.Count; obc++)
                    {
                        Transform[] gochild= allGameObjects[obc].GetComponentsInChildren<Transform>();
                        allTransforms.Add(allGameObjects[obc].transform);

                        foreach(Transform newTransform in gochild)
                        {
                            if (!allTransforms.Contains(newTransform))
                            {
                                allTransforms.Add(newTransform);
                            }
                        }
                        //allTransforms.AddRange(gochild);
                    }


                    for (int j = 0; j < allTransforms.Count; j++)
                    {
                        var go = allTransforms[j];

                        T[] allcomponents = go.GetComponents<T>();

                        for(int x = 0; x < allcomponents.Length; x++)
                        {

                            ScriptAndAssociatedGameobject<T> combination;

                            combination.listener = allcomponents[x];
                            combination.gameObject = go.gameObject;
                            results.Add(combination);

                        }
                    }
                }
            }
            return results;
        }
    }
}