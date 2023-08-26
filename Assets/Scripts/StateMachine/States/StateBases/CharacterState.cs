using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
  protected CharacterEntity _character;
  protected string _animationName;
  public CharacterState(StateMachine stateMachine, CharacterEntity character, string animationName) : base(stateMachine)
  {
    _character = character;
    _animationName = animationName;
  }

  public override void EnterState(IStateParam stateParam = null)
  {
    base.EnterState(stateParam);
    _character.PlayAnimation(_animationName);
  }
}
