using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : Entity
{
  [field: SerializeField] public IdleState IdleState { get; private set; }
  [field: SerializeField] public MoveState MoveState { get; private set; }
  [field: SerializeField] public FindPathState FindPathState { get; private set; }

  public Building Building { get; private set; }
  private Vector3 _targetPos = default;
  public Vector3 GetTargetPosition() => _targetPos;

  protected override void SetupState()
  {
    StateMachine = new StateMachine();

    IdleState = new IdleState(StateMachine, this);
    MoveState = new MoveState(StateMachine, this, 0.12f);
    FindPathState = new FindPathState(StateMachine, this);

    StateMachine.Initial(IdleState);
  }

  public void SetBuilding(Building building) => Building = building;

  public override void SetCurrentTile(Tile tile) => _currentTile = tile;
}
