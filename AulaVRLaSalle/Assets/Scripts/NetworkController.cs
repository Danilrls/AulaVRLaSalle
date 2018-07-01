using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ExitGames.Client.Photon;

public class NetworkController : MonoBehaviour
{
    string _room = "Tutorial_Convrge";
    public int mPlayers;

    void Start()
    {
        mPlayers = gameObject.GetComponent<MainMenu>().nPlayers;
        Debug.Log(mPlayers);
        PhotonNetwork.ConnectUsingSettings("0.1");
        Debug.Log("START");
    }

    void OnJoinedLobby()
    {
        Debug.Log("joined lobby");

        MainMenu maxPlayers = gameObject.GetComponent<MainMenu>();

        RoomOptions roomOptions = new RoomOptions() { };
        //roomOptions.MaxPlayers = mPlayers;
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        //PhotonNetwork.Instantiate("OVRPlayerController", Vector3.zero, Quaternion.identity, 0);
       
        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
        //Debug.Log();
        
        //PhotonNetwork.Instantiate("NetworkedCube", Vector3.zero, Quaternion.identity, 0);
       
        
    }
}