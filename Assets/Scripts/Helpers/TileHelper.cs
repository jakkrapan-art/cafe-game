using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileHelper
{
  public static List<Tile> GetShortestPath(Tile from, Tile target)
  {
    Stack<Tile> visited = new Stack<Tile>();
    Queue<Tile> queue = new Queue<Tile>();
    Dictionary<Tile, Tile> parentDict = new Dictionary<Tile, Tile>();

    queue.Enqueue(from);
    parentDict.Add(from, null);
    
    while(queue.Count > 0)
    {
      Tile current = queue.Dequeue();
      visited.Push(current);

      foreach (var adjacent in current.AdjacentTiles)
      {
        if(adjacent.Equals(target))
        {
          visited.Push(adjacent);
          break;
        }

        if (visited.Contains(adjacent)) continue;

        parentDict.Add(adjacent, current);
        queue.Enqueue(adjacent);
      }
    }

    if (!visited.Contains(target)) return null;

    List<Tile> path = new List<Tile>();
    Tile tile = visited.Pop();
    while(tile != null)
    {
      path.Add(tile);
      tile = parentDict[tile];

      if (tile == null) return null;
    }

    path.Reverse();
    return path;
  }
}
