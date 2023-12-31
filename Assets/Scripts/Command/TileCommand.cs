using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileCommand : ICommand
{
  protected CharacterEntity _character;

  public TileCommand(CharacterEntity entity)
  {
    _character = entity;
  }

  public abstract void Execute();
  public abstract void Undo();
}
