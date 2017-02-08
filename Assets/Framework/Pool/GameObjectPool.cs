using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class GameObjectPool
{
    [SerializeField]
    public string poolName;

    [SerializeField]
    private GameObject goPrefab;

    [SerializeField]
    private int maxCount;

    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();

    // 从池获取实例
    public GameObject GetInstance()
    {
        foreach (GameObject go in goList)
        {
            if (go != null && !go.activeInHierarchy)
            {
                go.SetActive(true);
                return go;
            }
        }

        if (goList.Count > maxCount)
        {
            goList.RemoveAt(0);
            GameObject.Destroy(goList[0]);
        }

        GameObject goTemp = GameObject.Instantiate(goPrefab) as GameObject;
        goList.Add(goTemp);
        return goTemp;
    }
}
