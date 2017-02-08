using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void RequestScore(string url)
    {
        Debug.Log("RequestScore from " + url);

        OnReceiveScore();
    }

    public void OnReceiveScore()
    {
        int score = Random.Range(0, 100);

        dispatcher.Dispatch(ServiceEvent.RequestScore, score);
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("UpdateScore to " + url);
    }
}
