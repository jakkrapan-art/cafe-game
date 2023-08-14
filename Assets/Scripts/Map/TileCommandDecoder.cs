using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCommandDecoder
{
  private CharacterEntity _character;
  public TileCommandDecoder(CharacterEntity entity)
  {
    _character = entity;
  }

  public TileCommand Decode(Tile tile)
  {
    switch(tile) 
    {
      case NormalTile normal:
        return new MoveToTargetCmd(_character, normal);
      default: return null;
    }
  }

  public List<TileCommand> Decode(List<Tile> tiles)
  {
    List<TileCommand> commands = new List<TileCommand>();
    foreach (Tile tile in tiles) 
    {
      var command = Decode(tile);
      if (command != null) commands.Add(command);
    }
    return commands;
  }
}
