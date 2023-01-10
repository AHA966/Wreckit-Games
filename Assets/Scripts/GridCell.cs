using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class GridCell : MonoBehaviourPunCallbacks
{
    private int Posx;
    private int Posy;
    private bool touched = false;


    public Color PlayerColor = Color.red;

    //initialsied with Color not available so when comparing not comparing with uninitialised;
    public Color GridCellColor;
    //refernce to the object on the grid square
    public GameObject objectInThisGridSpace = null;

    //bool if the grid square is occupied or not
    public bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {   

        /**int PlayerNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        
        switch (PlayerNumber)
        {
            case 1:
                PlayerColor = Color.red;
                break;
            case 2:
                PlayerColor = Color.blue;
                break;
            case 3:
                PlayerColor = Color.green;
                break;
            case 4:
                PlayerColor = Color.magenta;
                break;
        
        }
        **/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(int x, int y){

        Posx = x;
        Posy = y;
    }

    public Vector2Int GetPosition(){
        return new Vector2Int(Posx,Posy); 
    }

    public void OnCollisionEnter (Collision other) 
     {
        print("Collision");
        if(other.gameObject.name == "Player")
        {

            if(touched == false)
            {
                GetComponentInChildren<SpriteRenderer>().material.color = PlayerColor;
                touched = true;

                Movement player = other.collider.GetComponent(typeof(Movement)) as Movement;
                Score text = other.collider.GetComponent(typeof(Score)) as Score;
                
                player.addTile();
                text.setScore(player.getScore());
        
            }
            
        }
     }

    public Color getPlayerColor()
    {
        return PlayerColor;
    }

    public Color getGridCellColor()
    {
        return GridCellColor;
    }
    
 
    public void OnCollisionExit (Collision other) 
     {
         print("CollisionExit");
     }


}
