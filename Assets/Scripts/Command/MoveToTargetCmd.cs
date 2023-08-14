public class MoveToTargetCmd : TileCommand
{
  private Tile _target;
  public MoveToTargetCmd(CharacterEntity character, Tile target) : base(character)
  {
    _target = target;
  }

  public override void Execute()
  {
    _character.StateMachine.ChangeState(_character.MoveState, new MoveStateParam(_target));
  }

  public override void Undo()
  {
    throw new System.NotImplementedException();
  }
}
