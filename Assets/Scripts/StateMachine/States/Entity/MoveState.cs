using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveStateParam : IStateParam
{
  public Tile target;

  public MoveStateParam(Tile target)
  {
    this.target = target;
  }
}

public class MoveState : State
{
  private Tile _target;
  private float _moveSpeed;

  private bool _isMoving = false;
  public MoveState(Entity entity, StateMachine stateMachine, float speed) : base(entity, stateMachine)
  {
    _moveSpeed = speed;
  }

  public override void EnterState(IStateParam param)
  {
    base.EnterState(param);
    _target = ((MoveStateParam)param).target;

    _isMoving = true;
  }

  public override void ExitState()
  {
    base.ExitState();
  }

  public override void FrameUpdate()
  {
    base.FrameUpdate();

    if(!_isMoving)
    {
      _entity.SetCurrentTile(_target);
      _stateMachine.ChangeState(((CharacterEntity)_entity).IdleState);
    }
  }

  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();

    var targetPos = GridHelper.Instance.GetCenterCellPosition(_target.Cell);

    if(!Mathf.Approximately(Vector3.Distance(_entity.transform.position,  targetPos), 0))
    {
      _entity.MoveToTarget(targetPos, _moveSpeed);
    }
    else
    {
      _isMoving = false;
    }
  }
}
