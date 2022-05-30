using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Columns
{
    public List<GameObject> elements = new List<GameObject>();
}
 
[System.Serializable]
public class Grid
{
    public List<Columns> gridList = new List<Columns>();
}


public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField] 
    private Vector2 gridSize;
    [SerializeField] 
    private Vector2 gridOffset;

    public Grid grid = new Grid();
    [ContextMenu("CreateGrid")]
    
    public void CreateGrid()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            grid.gridList[i] = new Columns();
            
            for (int j = 0; j < gridSize.y; j++)
            {
                GameObject tempTile = PrefabUtility.InstantiatePrefab(tile) as GameObject;
                
                tempTile.name = "[" + i + "," + j + "]";
                
                grid.gridList[i].elements.Add(tempTile);
                
                Vector2 tempPos = new Vector2(i,j);
                if (j > 0)
                    tempPos.y += gridOffset.y * j;
                if (i > 0)
                    tempPos.x += gridOffset.x * i;
               
                tempTile.transform.position = tempPos;
            }
            
        }
    }

    [ContextMenu("GetRandomTile")]
    public GameObject GetRandomAvailableTile()
    {
        var availableTiles = new List<GameObject>();

        for (int i = 0; i < gridSize.x * gridSize.y; i++)
        {
            for (int j = 0; j < grid.gridList[i%(int)gridSize.y].elements.Count; j++)
            {
                if (!grid.gridList[i%(int)gridSize.y].elements[j].GetComponent<Tile>().isNumberOn)
                {
                    availableTiles.Add(grid.gridList[i%(int)gridSize.y].elements[j]);
                }        
            }
        }

        var rndTile = Random.Range(0,availableTiles.Count);
        
        Debug.Log(availableTiles[rndTile]);
        return availableTiles[rndTile];
    }
}
