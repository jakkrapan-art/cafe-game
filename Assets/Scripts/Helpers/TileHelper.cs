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

    while (queue.Count > 0)
    {
      Tile current = queue.Dequeue();

      if (current.Equals(target))
      {
        visited.Push(current);
        break;
      }

      visited.Push(current);

      foreach (var adjacent in current.AdjacentTiles)
      {
        if (visited.Contains(adjacent) || parentDict.ContainsKey(adjacent) || !adjacent.Walkable) continue;

        parentDict.Add(adjacent, current);
        queue.Enqueue(adjacent);
      }
    }

    if (!parentDict.ContainsKey(target)) return null;

    from.SetWalkable(true);
    target.SetWalkable(false);

    List<Tile> path = new List<Tile>();
    Tile tile = visited.Pop();
    path.Add(tile);
    while(tile != null)
    {
      path.Add(tile);
      tile = parentDict[tile];
    }

    if (path.Contains(from)) path.Remove(from);
    path.Reverse();
    return path;
  }
}
