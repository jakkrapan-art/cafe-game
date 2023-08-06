using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingConstructor : MonoBehaviour
{
  protected List<Tile> _tiles = new List<Tile>();
  protected bool _isFlipped = false;

  public Vector3 Position => transform.position;

  public abstract List<Tile> Build(Vector3Int startCell);

  public virtual List<Tile> Remove()
  {
    return _tiles;
  }

  public void Flip()
  {
    _isFlipped = !_isFlipped;
  }
}
