using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : Entity
{
  [field: SerializeField] public IdleState IdleState { get; private set; }
  [field: SerializeField] public MoveState MoveState { get; private set; }

  private Vector3 _targetPos = default;
  public Vector3 GetTargetPosition() => _targetPos;

  protected override void SetupState()
  {
    StateMachine = new StateMachine();

    IdleState = new IdleState(this, StateMachine);
    MoveState = new MoveState(this, StateMachine, 0.12f);

    StateMachine.Initial(IdleState);
  }

  public override void SetCurrentTile(Tile tile)
  {
    _currentTile = tile;
  }
}
