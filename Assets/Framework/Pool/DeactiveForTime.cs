using UnityEngine;

public class DeactiveForTime : MonoBehaviour
{
    public float time = 2f;

    void OnEnable()
    {
        Invoke("Deactive", time);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
