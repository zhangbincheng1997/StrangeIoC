using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class CubeMediator : Mediator
{
    [Inject]
    public CubeView cubeView { get; set; }

    // 全局dispatcher CONTEXT_DISPATCHER
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        cubeView.Init();

        dispatcher.AddListener(MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.AddListener(MediatorEvent.ClickDown, OnClickDown);

        dispatcher.Dispatch(CommandEvent.RequestScore);  // 通过dispatcher派发命令
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(MediatorEvent.ClickDown, OnClickDown);
    }

    public void OnScoreChange(IEvent evt)
    {
        int score = (int)evt.data;
        cubeView.UpdateScore(score);
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(CommandEvent.UpdateScore);
    }
}
