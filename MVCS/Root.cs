using strange.extensions.context.impl;
using UnityEngine;

public class Root : ContextView
{
    void Awake()
    {
        context = new GameView(this);
        // context.Start(); 
    }
}
