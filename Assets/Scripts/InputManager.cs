using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    GameGrid gameGrid;
    [SerializeField] private LayerMask WhatIsAGridLayer; 

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseOver = IsMouseOverGridSpace();
        if(cellMouseOver != null){
            if(Input.GetMouseButtonDown(0)){

                Debug.Log(cellMouseOver.isOccupied);
                //cellMouseOver.GetComponent<MeshRenderer>().material.color = Color.red;
                cellMouseOver.GetComponentInChildren<SpriteRenderer>().material.color = Color.green;
            }
        }
    }

    //return the grid cell if mouse is over the grid cell

    private GridCell IsMouseOverGridSpace()
     {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f, WhatIsAGridLayer))
        {
            return hitInfo.transform.GetComponent<GridCell>();
        }
        else
        {
            return null;
        }
    }
}
 