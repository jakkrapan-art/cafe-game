using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType
{
  Normal,
}

[System.Serializable]
public abstract class Tile
{
  private Dictionary<Tile, bool> _adjacentTiles = new Dictionary<Tile, bool>();
  private Vector3Int _cell = default;
  private bool _walkable = true;

  #region getter
  public List<Tile> AdjacentTiles
  {
    get
    {
      List<Tile> noneBlockedTiles = new List<Tile>();
      foreach (var item in _adjacentTiles)
      {
        if (item.Value) continue;

        noneBlockedTiles.Add(item.Key);
      }

      return noneBlockedTiles;
    }
  }
  public Tile GetAdjacentTile(int index) 
  {
    index = Mathf.Clamp(index, 0, AdjacentTiles.Count);
    return AdjacentTiles[index]; 
  }
  public Vector3Int Cell => _cell;
  public bool Walkable => _walkable;
  #endregion

  #region setter
  public void SetWalkable(bool walkable) { _walkable = walkable; }
  #endregion

  public Tile(int x, int y) { _cell = new Vector3Int(x, y); }

  public void AddAdjecent(Tile tile)
  {
    if (_adjacentTiles.ContainsKey(tile)) return;

    _adjacentTiles.Add(tile, false);
    tile.AddAdjecent(this);
  }

  public void RemoveAdjacent(Tile tile)
  {
    if (!_adjacentTiles.ContainsKey(tile)) return;

    _adjacentTiles.Remove(tile);
    tile.RemoveAdjacent(this);
  }
}
