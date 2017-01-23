using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public interface IScoreService
{
    IEventDispatcher dispatcher { get; set; }

    void RequestScore(string url);  // 请求分数
    void OnReceiveScore();  // 接受到服务端的分数
    void UpdateScore(string url, int score);  // 更新分数
}
