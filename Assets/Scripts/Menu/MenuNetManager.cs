using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

/**
 * <summary> Script to handle the creation / joining of rooms. </summary>
 * <remarks> Inherits from MonoBehaviourPunCallbacks to override callback functions related
 *           to network operations. </remarks>
 */
public class MenuNetManager : MonoBehaviourPunCallbacks
{
    /**
     * <summary> Length of generated room code </summary>
     */
    public const int ROOM_CODE_LENGTH = 6;

    public InputField JoinRoomNameField, JoinRoomPasswordField, CreateRoomPasswordField;
    public Slider NumPlayersSlider;

    private string m_generatedRoomCode = "";
    public static string m_Room = "MainScene";

    /**
     * <summary> Helper function to generate a room code </summary>
     */
    private string GenerateRoomName()
    {
        string roomCode = "";
        for(int i = 0; i < ROOM_CODE_LENGTH; i++)
        {
            roomCode += (char)Random.Range('A', 'Z' + 1);
        }

        return roomCode;
    }

    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    /**
     * <summary> Called when the script is started, attempts to connent the client to the master server. </summary>
     */
    public void Start()
    {
        // Try to connect to the Photon master server
        Debug.Log("Trying to connect to the master server...");
        PhotonNetwork.ConnectUsingSettings();
    }

    /**
     * <summary> Called when the client successfully connects to the master server, moves the user to the MainMenu </summary>
     */
    public override void OnConnectedToMaster()
    {
        // Called when connected to the Photon master server
        Debug.Log("Successfully connected to the master server!");
        // This called back is also called when returning from a room.

        // Only go to the main menu if we are waiting on the master server connect
        //if(MenuManager.GetInstance().CurrentMenu.GetName() == "MasterServerWait")
        //    MenuManager.GetInstance().PushMenu("MainMenu");
    }

    /**
     * <summary> Called when the create room button is pressed, attempts to create a room with the users specified settings </summary>
     */

     public void setm_Room(string Name)
     {
       m_Room = Name;
     }

    public void OnClickCreateRoom()
    {
        // Called when the create room button is pressed
        Debug.Log("Trying to create a room...");

        // Set player name
        PhotonNetwork.NickName = PlayerPrefs.GetString(UserNameInput.PLAYERNAME_KEY);

        // Generate room code
        m_generatedRoomCode = GenerateRoomName();

        // Set room options
        RoomOptions options = new RoomOptions();
        options.IsOpen = true;
        options.IsVisible = true;
        options.MaxPlayers = (byte)NumPlayersSlider.value;
        options.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();

        // Add entry for room password and the room name
        //options.CustomRoomProperties.Add("Password", CreateRoomPasswordField.text);
        options.CustomRoomProperties.Add("RoomSceneName", m_Room);

        // Create room
        PhotonNetwork.CreateRoom(m_generatedRoomCode, options);

        //MenuManager.GetInstance().PushMenu("CreateRoomWait");
    }

    /**
     * <summary> Called when the join button is pressed, attempts to join a room </summary>
     */
    public void OnClickJoinRoom()
    {
        // Called when the join room button is pressed
        string roomName = JoinRoomNameField.text;

        if(roomName == "")
        {
            MenuManager.GetInstance().PushModalOk(
                    "Invalid room code",
                    "Please enter a room code!",
                    null
                );
            return;
        }

        // Set player name
        PhotonNetwork.NickName = PlayerPrefs.GetString(UserNameInput.PLAYERNAME_KEY);

        // Join room
        if (PhotonNetwork.JoinRoom(roomName))
        {
            Debug.Log("Trying to join a room...");
            //MenuManager.GetInstance().PushMenu("JoinRoomWait");
        }
    }

    /**
     * <summary> Called when the room is created successfully </summary>
     */
    public override void OnCreatedRoom()
    {
        Debug.Log("Created room with code \"" + m_generatedRoomCode + "\"");
    }

    /**
     * <summary> Called when the client joins to a room successfully, loads the room scene if the password matches </summary>
     */
    public override void OnJoinedRoom()
    {
        // Called when the client joins a room
        // Load the room scene

        Debug.Log("Sucessfully joined the room!");
        
        // Get destination room scene name
        string roomSceneName = (string)PhotonNetwork.CurrentRoom.CustomProperties["RoomSceneName"];

        // If password matches, load the lobby menu
        if (PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.LoadLevel(roomSceneName);
            MenuManager.GetInstance().PushMenu("PlayMenu");
        }
        else
        {
            MenuManager.GetInstance().PushMenu("LobbyMenu");
        }
    }

    /**
     * <summary> Called when Play Button is Pressed </summary>
     */
    public void Play()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        string roomSceneName = (string)PhotonNetwork.CurrentRoom.CustomProperties["RoomSceneName"];
        PhotonNetwork.LoadLevel(roomSceneName);
    }


    /**
     * <summary> Called when the room cannot be created, shows an error message </summary>
     */
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Could not create room!");

        MenuManager.GetInstance().PushModalOk(
            "Error",
            "Could not create room!",
            () => { MenuManager.GetInstance().PopMenu(); } // Pop the wait menu that is behind the modal
        );
    }

    /**
     * <summary> Called when a room cannot be joined, shows an error message </summary>
     */
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Could not join room!");

        MenuManager.GetInstance().PushModalOk(
            "Error",
            "Could not join room!",
            () => { MenuManager.GetInstance().PopMenu(); } // Pop the wait menu that is behind the modal
        );
    }
}
