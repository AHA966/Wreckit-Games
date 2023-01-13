using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerCountDisplay : MonoBehaviour
{
    public Text PlayerCount;
    // Update is called once per frame
    void Update()
    {
        PlayerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }
}
