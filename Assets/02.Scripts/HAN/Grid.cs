using UnityEngine;
using System.Collections.Generic;

public class Cell
{
    public bool canMove;
    public Vector2 pos;
    public int x, y;

    public int gCost;
    public int hCost;
    public Cell parent;

    public int fCost => gCost + hCost;

    public Cell(bool canMove, Vector2 pos, int x, int y)
    {
        this.canMove = canMove;
        this.pos = pos;
        this.x = x;
        this.y = y;
    }
}
public class Grid : MonoBehaviour
{
    public int gridWidth = 20;
    public int gridHeight = 12;
    public float cellSize = 1f;
    public LayerMask obstacleMask;

    public Cell[,] cells;

    void Awake()
    {
        BuildGrid();
    }

    void BuildGrid()
    {
        cells = new Cell[gridWidth, gridHeight];

        Vector2 origin = transform.position;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 cellPos = origin + new Vector2(
                    (x + 0.5f) * cellSize,
                    (y + 0.5f) * cellSize
                );

                bool canMove = !Physics2D.OverlapCircle(
                    cellPos,
                    cellSize * 0.4f,
                    obstacleMask
                );

                cells[x, y] = new Cell(canMove, cellPos, x, y);
            }
        }
    }

    public Cell FromWorld(Vector2 worldPos)
    {
        Vector2 local = worldPos - (Vector2)transform.position;

        int x = Mathf.FloorToInt(local.x / cellSize);
        int y = Mathf.FloorToInt(local.y / cellSize);

        x = Mathf.Clamp(x, 0, gridWidth - 1);
        y = Mathf.Clamp(y, 0, gridHeight - 1);

        return cells[x, y];
    }

    public List<Cell> GetAround(Cell cell)
    {
        List<Cell> result = new List<Cell>();

        TryAdd(cell.x - 1, cell.y, result);
        TryAdd(cell.x + 1, cell.y, result);
        TryAdd(cell.x, cell.y - 1, result);
        TryAdd(cell.x, cell.y + 1, result);

        return result;
    }

    void TryAdd(int x, int y, List<Cell> list)
    {
        if (x < 0 || x >= gridWidth || y < 0 || y >= gridHeight)
            return;

        list.Add(cells[x, y]);
    }
}
