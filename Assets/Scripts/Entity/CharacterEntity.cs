using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterEntity : Entity, IAnimatable
{
  [field: SerializeField] public IdleState IdleState { get; private set; }
  [field: SerializeField] public MoveState MoveState { get; private set; }
  [field: SerializeField] public FindPathState FindPathState { get; private set; }

  public Building Building { get; private set; }
  public Animator Animator { get; protected set; }
  private string _currentAnimation = "";

  private Vector3 _targetPos = default;
  public Vector3 GetTargetPosition() => _targetPos;

  protected override void Awake()
  {
    base.Awake();
    Animator = GetComponent<Animator>();
  }

  protected override void SetupState()
  {
    StateMachine = new StateMachine();

    IdleState = new IdleState(StateMachine, this, "Idle");
    MoveState = new MoveState(StateMachine, this, "Move", 0.12f);
    FindPathState = new FindPathState(StateMachine, this, "Idle");

    StateMachine.Initial(IdleState);
  }

  public void SetBuilding(Building building) => Building = building;

  public override void SetCurrentTile(Tile tile) => _currentTile = tile;

  public void PlayAnimation(string name)
  {
    if (!Animator || Animator.GetBool(name)) return;

    if (!string.IsNullOrEmpty(_currentAnimation)) StopAnimation();
    {
      Animator.SetBool(name, true);
      _currentAnimation = name;
    }
  }

  public void StopAnimation()
  {
    if (Animator) Animator.SetBool(_currentAnimation, false);
  }
}
