using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    private int height = 8;
    private int width = 8; 
    private float GridSpaceSize = 5f;

    [SerializeField] private GameObject gridCellPrefab; 
    private GameObject[,] gameGrid;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

//create grid when game starts
    private void CreateGrid()
    {
        gameGrid = new GameObject[height,width];

        if(gridCellPrefab == null){
            Debug.LogError("ERROR: GridCellPrefab is NULL");
            return;
        }

        for (int y = 0; y < height; y++){
            for(int x = 0; x < width; x++)
            {
                gameGrid[x,y] = Instantiate(gridCellPrefab, new Vector3(x * GridSpaceSize, y * GridSpaceSize), Quaternion.identity);
                gameGrid[x,y].GetComponent<GridCell>().SetPosition(x,y);
                gameGrid[x,y].transform.parent = transform;
                gameGrid[x,y].gameObject.name = x.ToString() + y.ToString(); 
            }
        }

        transform.rotation = Quaternion.Euler(90, 0f, 0f);
    }

    public Vector2Int GetGridPos(Vector3 worldPos){
        int x = Mathf.FloorToInt(worldPos.x / GridSpaceSize);
        int y = Mathf.FloorToInt(worldPos.z / GridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x,y);
    }

    public Vector3 GetWorldPosFromGrid(Vector2Int gridPos){
        float x = gridPos.x * GridSpaceSize;
        float y = gridPos.y * GridSpaceSize;

        return new Vector3(x, 0, y);
    }
}
