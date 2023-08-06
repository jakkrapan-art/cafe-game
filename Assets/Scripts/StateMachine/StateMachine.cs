using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
  protected State _currentState;

  public void Initial(State initialState)
  {
    initialState.EnterState();
    _currentState = initialState;
  }

  public void ChangeState(State state, IStateParam stateParams = null)
  {
    if(_currentState != null)
    {
      _currentState.ExitState();
    }

    state.EnterState(stateParams);
    _currentState = state;
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
