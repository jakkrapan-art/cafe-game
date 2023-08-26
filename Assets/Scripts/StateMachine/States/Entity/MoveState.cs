using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveStateParam : IStateParam
{
  public Tile target;
  public Action onTargetReached;
  public MoveStateParam(Tile target, Action onTargetReached = null)
  {
    this.target = target;
    this.onTargetReached = onTargetReached;
  }
}

public class MoveState : CharacterState
{
  private Tile _target;
  private float _moveSpeed;
  private MoveStateParam param;

  private bool _isMoving = false;
  public MoveState(StateMachine stateMachine, CharacterEntity character, string animationName, float speed) : base(stateMachine, character, animationName)
  {
    _moveSpeed = speed;
  }

  public override void EnterState(IStateParam param)
  {
    base.EnterState(param);

    _character.CurrentTile.SetWalkable(true);

    this.param = (MoveStateParam)param;
    _target = this.param.target;
    _target.SetWalkable(false);
    _isMoving = true;
  }

  public override void ExitState()
  {
    base.ExitState();
  }

  public override void FrameUpdate()
  {
    if(!_isMoving)
    {
      _character.SetCurrentTile(_target);

      if (param.onTargetReached != null)
      {
        param.onTargetReached.Invoke();
      }
      else
      {
        _stateMachine.ChangeState(_character.IdleState);
      }
    }
  }

  public override void PhysicsUpdate()
  {
    var targetPos = GridHelper.Instance.GetCenterCellPosition(_target.Cell);
    if(!Mathf.Approximately(Vector3.Distance(_character.transform.position,  targetPos), 0))
    {
      _character.MoveToTarget(targetPos, _moveSpeed);
    }
    else
    {
      _isMoving = false;
    }
  }
}
