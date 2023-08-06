using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetCmd : TileCommand
{
  private Tile _target;
  public MoveToTargetCmd(CharacterEntity entity, Tile target) : base(entity)
  {
    _target = target;
  }

  public override void Execute()
  {
    _entity.StateMachine.ChangeState(_entity.MoveState, new MoveStateParam(_target));
  }

  public override void Undo()
  {
    throw new System.NotImplementedException();
  }
}
