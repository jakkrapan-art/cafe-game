using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestScene : SceneBase
{
  private Building _building = null;

  public TileBase testFloorTile = null;

  [SerializeField]
  private CharacterEntity _characterEntity = null;
  public int TestCharacterCount = 10;

  protected override void InitialSetup()
  {
    _building = Building.Create(0, 0, 10, 10, testFloorTile);

    int spawnCount = 0;
    do
    {
      var tile = _building.GetRandomTile();
      if (tile is NormalTile == false || !tile.Walkable) continue;
      _building.SpawnCharacter(_characterEntity, tile);
      spawnCount++;
    } while (spawnCount < TestCharacterCount);
  }

  protected override void SetupCamera()
  {
    Camera cam = Camera.main;
    Vector3 buildingCenter = _building.CenterPosition;
    cam.transform.position = new Vector3(buildingCenter.x, buildingCenter.y, cam.transform.position.z);
  }
}
