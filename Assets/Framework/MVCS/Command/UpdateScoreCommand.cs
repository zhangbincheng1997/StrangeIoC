using strange.extensions.command.impl;
using UnityEngine;

public class UpdateScoreCommand : EventCommand
{
    [Inject]
    public ScoreModel scoreModel { get; set; }

    [Inject]
    public IScoreService scoreService { get; set; }

    private string url = "http://www.littlredhat1997.com/";

    public override void Execute()
    {
        ++scoreModel.score;
        scoreService.UpdateScore(url, scoreModel.score);

        dispatcher.Dispatch(MediatorEvent.ScoreChange, scoreModel.score);
    }
}
