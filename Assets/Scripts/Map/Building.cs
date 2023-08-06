using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
  private List<BuildingConstructor> _constructors = new List<BuildingConstructor>();
  private Dictionary<Vector3Int, Tile> _tiles = new Dictionary<Vector3Int, Tile>();

  private Vector2Int _position = default;
  public Vector2Int Position => _position;
  private List<Entity> _entities = new List<Entity>();
  private Vector3 _centerPosition = default;
  public Vector3 CenterPosition => _centerPosition;

  public static Building Create(int x, int y, int width, int height, TileBase floor)
  {
    var go = new GameObject("Building");
    var building = go.AddComponent<Building>();
    building.SetPosition(new Vector2Int(x, y));

    var tileDict = building._tiles;
    for(int gridX = 0; gridX < width; gridX++)
    {
      for (int gridY = 0; gridY < height; gridY++)
      {
        if (tileDict.ContainsKey(new Vector3Int(gridX, gridY))) continue;

        Tile tile = new NormalTile(gridX, gridY);
        building._tiles.Add(new Vector3Int(gridX, gridY), tile);
        GridHelper.Instance.SetTile(new Vector3Int(gridX, gridY), floor);

        //add addjacents
        if (tileDict.TryGetValue(new Vector3Int(gridX, gridY - 1), out Tile btmTile)) btmTile.AddAdjecent(tile);
        if (tileDict.TryGetValue(new Vector3Int(gridX, gridY + 1), out Tile topTile)) topTile.AddAdjecent(tile);
        if (tileDict.TryGetValue(new Vector3Int(gridX - 1, gridY), out Tile leftTile)) leftTile.AddAdjecent(tile);
        if (tileDict.TryGetValue(new Vector3Int(gridX + 1, gridY), out Tile rightTile)) rightTile.AddAdjecent(tile);
      }
    }

    Vector3 center = GridHelper.Instance.GetCenterCellPosition(new Vector3Int(x + width / 2, y + height / 2));
    building._centerPosition = center;
    return building;
  }

  public void SpawnCharacter(CharacterEntity character, Tile tile)
  {
    var center = GridHelper.Instance.GetCenterCellPosition(tile.Cell);
    var spawned = Instantiate(character, center, Quaternion.identity);
    _entities.Add(spawned);
    spawned.SetCurrentTile(tile);
  }

  private void SetPosition(Vector2Int position)
  {
    _position = position;
  }

  /*public void AddConstructors(BuildingConstructor constructor) 
  {
    if (_constructors.Contains(constructor)) return;

    var tiles = constructor.Build(GridHelper.Instance.WorldToCell(constructor.Position));
    _tiles.AddRange(tiles);

    _constructors.Add(constructor);
  }

  public void RemoveConstructors(BuildingConstructor constructor)
  {
    if(!_constructors.Contains(constructor)) return;

    var tiles = constructor.Remove();
    foreach (var tile in tiles)
    {
      if(_tiles.Contains(tile)) _tiles.Remove(tile);
    }

    _constructors.Remove(constructor);
  }*/
  public Tile GetTile(Vector3Int cell)
  {
    if (_tiles.TryGetValue(cell, out Tile tile)) return tile;
    else return null;
  }
  public Tile GetRandomTile()
  {
    int randomNum = Random.Range(0, _tiles.Count);
    var list = _tiles.ToList();
    var tile = list[randomNum].Value;
    return tile;
  }
}
