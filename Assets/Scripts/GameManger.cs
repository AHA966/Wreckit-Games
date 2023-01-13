using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManger : MonoBehaviour
{

    //public GameObject[,] gameGrid;
    //public Color PlayerColor = GridCell.getColor();

    public GameObject playerPrefab;

    //public GameObject myPrefab;
    //public GameObject prefab;
    //public Vector3 position;
    //public Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
            Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
            PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    /*
    **<summary> Checks Grid to see how many squares the Player has filled according to their color <summary>
    */
    void Update()
    {   
        /**
         for (int y = 0; y < 8; y++){
            for(int x = 0; x < 8; x++)
            {
                GridCell gridCell = gameGrid[x,y].GetComponent<GridCell>();
                
                if(gridCell.getGridCellColor() == gridCell.getPlayerColor())
                {
                    
                }
            }
        }
        **/

    }
}
