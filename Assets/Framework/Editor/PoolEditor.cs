using UnityEngine;
using UnityEditor;

public class PoolEditor
{
    private static string savePath = "Assets/Framework/Resources/PoolInfo.asset";

    [MenuItem("Manager/PoolManager")]
    public static void CreateGameObjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        AssetDatabase.CreateAsset(poolList, savePath);
        AssetDatabase.SaveAssets();
    }
}
