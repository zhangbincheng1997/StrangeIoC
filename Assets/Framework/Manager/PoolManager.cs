using UnityEngine;
using System.Collections.Generic;

public class PoolManager
{
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }
    }

    private string savePath = "PoolInfo";
    private Dictionary<string, GameObjectPool> poolDict = new Dictionary<string, GameObjectPool>();

    private PoolManager()
    {
        // poolDict.Clear();

        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(savePath);
        foreach (GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.poolName, pool);
        }
    }

    public void Init()
    {
        // NONE
    }

    public GameObject GetInstance(string poolName)
    {
        GameObjectPool pool;
        poolDict.TryGetValue(poolName, out pool);
        if (pool != null)
        {
            return pool.GetInstance();
        }
        else
        {
            Debug.LogWarning(poolName + "  Non-existent");
            return null;
        }
    }
}
