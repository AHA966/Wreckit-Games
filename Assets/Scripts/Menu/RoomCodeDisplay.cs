using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomCodeDisplay : MonoBehaviour
{
    public Text RoomCode;
    // Update is called once per frame
    
    void Update()
    {
        if(PhotonNetwork.InRoom)
        {
            RoomCode.text = PhotonNetwork.CurrentRoom.Name;
        }
        
    }
}
