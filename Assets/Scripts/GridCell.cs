using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    private int Posx;
    private int Posy;
    private bool touched = false;

   

//refernce to the object on the grid square
    public GameObject objectInThisGridSpace = null;

//bool if the grid square is occupied or not
    public bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {   
    
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
        if(other.gameObject.name == "Player"){

            if(touched == false){
                GetComponentInChildren<SpriteRenderer>().material.color = Color.green;
                touched = true;

                Movement player = other.collider.GetComponent(typeof(Movement)) as Movement;
                Score text = other.collider.GetComponent(typeof(Score)) as Score;
                
                player.addTile();
                text.setScore(player.getScore());
        
            }
            
        }
     }
 
    public void OnCollisionExit (Collision other) 
     {
         print("CollisionExit");
     }


}
