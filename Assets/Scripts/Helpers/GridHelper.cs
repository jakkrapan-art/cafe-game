using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridHelper : MonoBehaviour
{
  #region Singleton
  private static GridHelper _instance = null;
  public static GridHelper Instance
  {
    get
    {
      if (!_instance)
      {
        var go = new GameObject("GridHelper");

        DontDestroyOnLoad(go);

        var helper = go.AddComponent<GridHelper>();
        helper.Setup();
         _instance = helper;
      }

      return _instance;
    }
  }
  #endregion

  private GridLayout _gridLayout = null;
  private Tilemap _tilemap = null;

  private void Setup()
  {
    var loadedTemplate = Resources.Load<Grid>("Templates/Grid");
    _gridLayout = Instantiate(loadedTemplate, transform);
    _tilemap = _gridLayout.transform.GetComponentInChildren<Tilemap>();
  }

  public Vector3 CellToWorldPoint(Vector3Int cell) => _gridLayout.CellToWorld(cell);
  public Vector3Int WorldToCell(Vector3 worldPoint) => _gridLayout.WorldToCell(worldPoint);
  public Vector3 GetCenterCellPosition(Vector3Int cell)
  {
    var worldPoint = _gridLayout.CellToWorld(cell);
    var cellSize = _gridLayout.cellSize;
    return new Vector3(worldPoint.x + (1 - cellSize.x), worldPoint.y + (1 - cellSize.y) , worldPoint.z);
  }

  public void SetTile(Vector3Int cell, TileBase tile)
  {
    if (!_tilemap) return;

    _tilemap.SetTile(cell, tile);
  }
}
