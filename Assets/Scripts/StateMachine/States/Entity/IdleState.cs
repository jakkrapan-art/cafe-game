using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
  private float _duration = 4f;
  private float _start = 0;
  public IdleState(StateMachine stateMachine, CharacterEntity character) : base(stateMachine, character)
  {
  }

  public override void EnterState(IStateParam stateParam = null)
  {
    base.EnterState(stateParam);

    _start = Time.time;
  }

  public override void FrameUpdate()
  {
    base.FrameUpdate();

    if(Time.time >= _start + _duration)
    {
      Tile target = _character.Building.GetRandomTile();;

      if(target != null)
      {
        _stateMachine.ChangeState(_character.FindPathState, new FindPathStateParam(target));
      }
    }
  }
}
