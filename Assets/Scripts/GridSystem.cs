using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{

    private int cellSize;
    private int width;
    private int height;
    private GridObject[,] gridObjectArray;
    public GridSystem(int width, int height, int cellSize)
    {

        this.cellSize = cellSize;
        this.width = width;
        this.height = height;

        gridObjectArray = new GridObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < width; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] = new GridObject(this, gridPosition);

            }
        }

    }
    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize), Mathf.RoundToInt(worldPosition.z / cellSize));
    }
    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < width; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));

            }
        }

    }
    public GridObject GetGridObject(GridPosition gridPosition)
    {
        Debug.Log(gridObjectArray[gridPosition.x, gridPosition.z]);
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }

}
