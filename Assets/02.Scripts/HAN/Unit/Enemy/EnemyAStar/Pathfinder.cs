using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Grid grid;

    List<Cell> openedCells = new List<Cell>();

    public List<Cell> GetPath(Vector2 start, Vector2 end)
    {
        Cell startCell = grid.FromWorld(start);
        Cell endCell = grid.FromWorld(end);

        List<Cell> open = new List<Cell>();
        HashSet<Cell> closed = new HashSet<Cell>();

        ResetUsedCells();

        startCell.gCost = 0;
        startCell.hCost = Dist(startCell, endCell);
        startCell.parent = null;

        open.Add(startCell);
        openedCells.Add(startCell);

        while (open.Count > 0)
        {
            Cell cur = open[0];

            for (int i = 1; i < open.Count; i++)
            {
                if (open[i].fCost < cur.fCost ||
                    open[i].fCost == cur.fCost && open[i].hCost < cur.hCost)
                {
                    cur = open[i];
                }
            }

            open.Remove(cur);
            closed.Add(cur);

            if (cur == endCell)
                return Build(startCell, endCell);

            foreach (Cell next in grid.GetAround(cur))
            {
                if (!next.canMove || closed.Contains(next))
                    continue;

                int newCost = cur.gCost + Dist(cur, next);

                if (!open.Contains(next) || newCost < next.gCost)
                {
                    next.gCost = newCost;
                    next.hCost = Dist(next, endCell);
                    next.parent = cur;

                    if (!open.Contains(next))
                    {
                        open.Add(next);
                        openedCells.Add(next);
                    }
                }
            }
        }
        return null;
    }

    void ResetUsedCells()
    {
        for (int i = 0; i < openedCells.Count; i++)
        {
            openedCells[i].gCost = 0;
            openedCells[i].hCost = 0;
            openedCells[i].parent = null;
        }
        openedCells.Clear();
    }

    List<Cell> Build(Cell start, Cell end)
    {
        List<Cell> path = new List<Cell>();
        Cell cur = end;

        while (cur != start)
        {
            path.Add(cur);
            cur = cur.parent;
        }

        path.Reverse();
        return path;
    }

    int Dist(Cell a, Cell b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }
}
