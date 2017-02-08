using UnityEngine;
using System.Collections.Generic;

// 状态机管理类
public class FSMSystem
{
    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    private Dictionary<StateId, FSMState> stateDict = new Dictionary<StateId, FSMState>();

    public void AddState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("State is Null");
            return;
        }
        if (!stateDict.ContainsKey(state.StateId))
        {
            state.fsm = this;
            stateDict.Add(state.StateId, state);
        }
        else
        {
            Debug.LogError("State is Existence");
        }
    }

    public void RemoveState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("state is Null");
            return;
        }
        if (stateDict.ContainsKey(state.StateId))
        {
            stateDict.Remove(state.StateId);
        }
        else
        {
            Debug.LogError("State is Non-Existence");
        }
    }

    public void DoTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("Transition is Non-Existence");
            return;
        }
        StateId id = currentState.GetState(trans);
        if (id == StateId.NullStateId)
        {
            Debug.LogWarning("Transition???");
        }
        else
        {
            FSMState state;
            stateDict.TryGetValue(id, out state);
            // 状态改变
            currentState.DoBeforeExit();
            currentState = state;
            state.DoBeforeEnter();
        }
    }

    public void StartState(StateId id)
    {
        FSMState state;
        stateDict.TryGetValue(id, out state);
        if (state != null)
        {
            state.DoBeforeEnter();
            currentState = state;
        }
        else
        {
            Debug.LogError("State is Non-Existence");
        }
    }
}
