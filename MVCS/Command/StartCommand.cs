using strange.extensions.command.impl;
using UnityEngine;

public class StartCommand : Command
{
    public override void Execute()
    {
        Debug.Log("StartCommand - Execute");

        AudioManager.Instance.Init();
        PoolManager.Instance.Init();
        LocalizationManager.Instance.Init();
    }
}
