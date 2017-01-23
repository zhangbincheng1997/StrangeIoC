using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class GameView : MVCSContext
{
    public GameView(MonoBehaviour view) : base(view) { }

    protected override void mapBindings()
    {
        // model 自身
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

        // mediator 视图 和 mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();

        // command 枚举 和 command
        commandBinder.Bind(CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(CommandEvent.UpdateScore).To<UpdateScoreCommand>();

        // service 接口 和 service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

        // start
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
