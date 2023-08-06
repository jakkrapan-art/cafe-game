using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileCommand : ICommand
{
  protected CharacterEntity _entity;

  public TileCommand(CharacterEntity entity)
  {
    _entity = entity;
  }

  public abstract void Execute();
  public abstract void Undo();
}
