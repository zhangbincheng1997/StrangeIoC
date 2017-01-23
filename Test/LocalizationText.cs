using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    public string key;

    void Start()
    {
        string value = LocalizationManager.Instance.GetValue(key);
        GetComponent<Text>().text = value;
    }
}
