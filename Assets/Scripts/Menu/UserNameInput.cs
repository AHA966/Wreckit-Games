using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UserNameInput : MonoBehaviour
{
    public const string PLAYERNAME_KEY = "username";
    public InputField TextInput;
    
    private string m_lastName = "";

    /**
     * <summary> Load an existing username if it exists </summary>
     */
    void Start()
    {
         if(PlayerPrefs.HasKey(PLAYERNAME_KEY))
        {
            TextInput.text = PlayerPrefs.GetString(PLAYERNAME_KEY);
            m_lastName = TextInput.text;
            //PhotonNetwork.NickName = m_lastName;
        }
        
    }

    /**
     * <summary> Called on every frame. If the text changes, update the persistent playerPref with the next text. </summary>
     */
    void Update()
    {
        string text = TextInput.text;

        if (text != m_lastName)
        {
                Debug.Log("valid username: " + text);
                PlayerPrefs.SetString(PLAYERNAME_KEY, text);
                //PhotonNetwork.NickName = text;
                m_lastName = text;
        }
    }
}
