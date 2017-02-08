using UnityEngine;
using System.Collections.Generic;

// 状态转换条件
public enum Transition
{
    NullTransition = 0,
    FindPlayer,
    LosePlayer,
}

// 状态唯一标识
public enum StateId
{
    NullStateId = 0,
    Patrol,
    Chase,
}

public abstract class FSMState
{
    protected StateId stateId;
    public StateId StateId { get { return stateId; } }

    protected Dictionary<Transition, StateId> map = new Dictionary<Transition, StateId>();

    public FSMSystem fsm;  // 状态机

    public void AddTransition(Transition trans, StateId id)
    {
        if (trans == Transition.NullTransition || id == StateId.NullStateId)
        {
            Debug.LogError("Transition or StateId is Non-Existence");
            return;
        }
        if (!map.ContainsKey(trans))
        {
            map.Add(trans, id);
        }
        else
        {
            Debug.LogError("Transition is Existence");
        }
    }

    public void RemoveTransition(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
        }
        else
        {
            Debug.LogWarning("Transition is Non-Existence");
        }
    }

    public StateId GetState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        else
        {
            return StateId.NullStateId;
        }
    }

    // 进入状态之前
    public virtual void DoBeforeEnter() { }

    // 离开状态之前
    public virtual void DoBeforeExit() { }

    // 状态中
    public abstract void DoUpdate();
}
