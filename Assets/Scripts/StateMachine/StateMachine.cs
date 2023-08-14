using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
  protected State _currentState;

  public void Initial(State initialState, IStateParam stateParam = null)
  {
    _currentState = initialState;
    initialState.EnterState(stateParam);
  }

  public void ChangeState(State state, IStateParam stateParams = null)
  {
    if(_currentState != null)
    {
      _currentState.ExitState();
    }

    _currentState = state;
    state.EnterState(stateParams);
  }

  public void FrameUpdate()
  {
    _currentState.FrameUpdate();
  }

  public void PhysicsUpdate()
  { 
    _currentState.PhysicsUpdate();
  }
}
