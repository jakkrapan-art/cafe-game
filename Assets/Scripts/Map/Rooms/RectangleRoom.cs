using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRoom : BuildingConstructor
{
  [SerializeField]
  private int _width = 0;

  [SerializeField]
  private int _height = 0;

  public override List<Tile> Build(Vector3Int startCell)
  {
    List<Tile> createdTiles = new List<Tile>();
    for (int i = 0; i < _width; i++)
    {
      for (int j = 0; j < _height; j++)
      {
        int x = startCell.x + i;
        int y = startCell.y + j;

        NormalTile tile = new NormalTile(x, y);
        createdTiles.Add(tile);
      }
    }

    return createdTiles;
  }
}
