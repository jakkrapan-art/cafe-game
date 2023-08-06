using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
  private float _duration = 0.5f;
  private float _start = 0;
  public IdleState(Entity entity, StateMachine stateMachine) : base(entity, stateMachine)
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
      Tile tile = _entity.CurrentTile;
      int random = Random.Range(0, tile.AdjacentTiles.Count);
      Tile target = tile.GetAdjacentTile(random);

      if(target != null) _stateMachine.ChangeState(((CharacterEntity)_entity).MoveState, new MoveStateParam(target));
    }
  }
}
