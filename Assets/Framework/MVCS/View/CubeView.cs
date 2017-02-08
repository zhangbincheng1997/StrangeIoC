using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    private Text scoreText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            OnClickDown();
        }
    }

    public void Init()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        Debug.Log(score);
    }

    private void OnClickDown()
    {
        dispatcher.Dispatch(MediatorEvent.ClickDown);
    }
}
