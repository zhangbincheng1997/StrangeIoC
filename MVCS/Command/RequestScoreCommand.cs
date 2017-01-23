using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService scoreService { get; set; }

    [Inject]
    public ScoreModel scoreModel { get; set; }

    private string url = "http://www.littlredhat1997.com/";

    public override void Execute()
    {
        Retain();  // 对象不销毁

        scoreService.dispatcher.AddListener(ServiceEvent.RequestScore, OnComplete);

        scoreService.RequestScore(url);
    }

    public void OnComplete(IEvent evt)
    {
        scoreModel.score = (int)evt.data;
        dispatcher.Dispatch(MediatorEvent.ScoreChange, evt.data);

        scoreService.dispatcher.RemoveListener(ServiceEvent.RequestScore, OnComplete);

        Release();  // 对象销毁
    }
}
