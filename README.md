# StrangeIoC

---

## StrangeIoc
> * `Root` : ContextView
> * `GameView` : MVCSContext
> * `Model` : 模型类自身
> * `View` : View层控制视图，Mediator枚举类和Mediator层
> * `Command` : CommandEvent枚举和Command类
> * `Service` : ServiceEvent枚举和Service类
```
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
```

## AudioManager
```
......
private string savePath = "AudioInfo";
private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
private AudioManager()
{
    // audioDict.Clear();
    TextAsset audioInfo = Resources.Load<TextAsset>(savePath);
    string[] lines = audioInfo.text.Split('\n');
    foreach (string line in lines)
    {
        if (!string.IsNullOrEmpty(line))
        {
            string[] pro = line.Split(',');
            string key = pro[0];
            AudioClip value = Resources.Load<AudioClip>(pro[1]);
            audioDict.Add(key, value);
        }
    }
}
```

## PoolManager
```
// GameObjectPool
......
public GameObject GetInstance()
{
    foreach (GameObject go in goList)
    {
        if (!go.activeInHierarchy)
        {
            go.SetActive(true);
            return go;
        }
    }
    if(goList.Count > maxCount)
    {
        goList.RemoveAt(0);
        GameObject.Destroy(goList[0]);
    }
    GameObject goTemp = GameObject.Instantiate(goPrefab) as GameObject;
    goList.Add(goTemp);
    return goTemp;
}

// PoolManager
......
private string savePath = "PoolInfo";
private Dictionary<string, GameObjectPool> poolDict = new Dictionary<string, GameObjectPool>();
private PoolManager()
{
    // poolDict.Clear();
    GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(savePath);
    foreach (GameObjectPool pool in poolList.poolList)
    {
        poolDict.Add(pool.poolName, pool);
    }
}
```

## Localization
```
......
public const string Language = English;
private const string Chinese = "Localization/Chinese";
private const string English = "Localization/English";
private LocalizationManager()
{
    // langDict.Clear();
    TextAsset langInfo = Resources.Load<TextAsset>(Language);
    string[] lines = langInfo.text.Split('\n');
    foreach (string line in lines)
    {
        if (!string.IsNullOrEmpty(line))
        {
            string[] pro = line.Split('=');
            string key = pro[0];
            string value = pro[1];
            langDict.Add(key, value);
        }
    }
}
```

## FSM
> * `enum` Transition 状态转换条件
> * `enum` StateId 状态唯一标识
> * FSMState(State基类)
`Dictionary<Transition, StateId>` map
`FSMSystem` fsm
`void` AddTransition(Transition trans, StateId id)
`void` RemoveTransition(Transition trans)
`StateId` GetState(Transition trans)
`virtual void` DoBeforeEnter() { }  // 进入状态之前
`virtual void` DoBeforeExit() { }  // 离开状态之前
`abstract void` DoUpdate();  // 状态中
> * FSMSystem(状态机管理类)
`FSMState` currentState
`Dictionary<StateId, FSMState>` stateDict
`void` AddState(FSMState state)
`void` RemoveState(FSMState state)
`void` DoTransition(Transition trans)
`void` StartState(StateId id)
> * NPCController
> * ChaseState
> * PatrolState
> * PlayerMove
```
// PlayerMove控制人物走动
......
void Update()
{
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
    {
        Vector3 targetPos = new Vector3(h, 0, v);
        mRigidbody.velocity = targetPos * speed;
        transform.rotation = Quaternion.LookRotation(targetPos);
    }
    else
    {
        mRigidbody.velocity = Vector3.zero;
    }
}
```

## protobuf
```
......
using ProtoBuf;
// 序列化
using (FileStream fs = File.Create(savePath))
{
    Serializer.Serialize<User>(fs, user1);
}
// 反序列化
using (FileStream fs = File.OpenRead(savePath))
{
    user2 = Serializer.Deserialize<User>(fs);
}
```
