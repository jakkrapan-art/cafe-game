using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPathStateParam : IStateParam
{
  public Tile Target { get; private set; }

  public FindPathStateParam(Tile target)
  {
    Target = target;
  }
}

public class FindPathState : CharacterState
{
  private TileCommandDecoder _tileDecoder;
  private Queue<Tile> _path = new Queue<Tile>();

  public FindPathState(StateMachine stateMachine, CharacterEntity character, string animationName) : base(stateMachine, character, animationName)
  {
    _tileDecoder = new TileCommandDecoder(character);
  }

  public override void EnterState(IStateParam stateParam = null)
  {
    base.EnterState(stateParam);
    FindPathStateParam param = (FindPathStateParam)stateParam;
    List<Tile> shortestPath = TileHelper.GetShortestPath(_character.CurrentTile, param.Target);

    if(shortestPath == null) 
    {
      ChangeToIdle();
      return;
    }

    _path = new Queue<Tile>(shortestPath);
    MoveToTarget();
  }

  private void MoveToTarget()
  {
    if (_path.Count == 0)
    {
      ChangeToIdle();
      return;
    }

    var tile = _path.Dequeue();
    if (tile == null) return;

    _stateMachine.ChangeState(_character.MoveState, new MoveStateParam(tile, MoveToTarget));
  }

  public override void ExitState()
  {
    base.ExitState();
  }

  public override void FrameUpdate()
  {
    base.FrameUpdate();
  }

  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();
  }

  private void ChangeToIdle()
  {
    _stateMachine.ChangeState(_character.IdleState);
  }
}
