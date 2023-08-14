using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
  protected CharacterEntity _character;
  public CharacterState(StateMachine stateMachine, CharacterEntity character) : base(stateMachine)
  {
    _character = character;
  }
}
