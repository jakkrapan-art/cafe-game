using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCommandDecoder
{
  private CharacterEntity _entity;
  public TileCommandDecoder(CharacterEntity entity)
  {
    _entity = entity;
  }

  public TileCommand Decode(Tile tile)
  {
    switch(tile) 
    {
      case NormalTile normal:
        return new MoveToTargetCmd(_entity, normal);
      default: return null;
    }
  }
}
