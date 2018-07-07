using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;
using System;

public class NetworkController : MonoBehaviour
{
    string _room = "AulaVRLaSalle";
    public int mPlayers;
    

    void Start(){
        mPlayers = MainMenu.nPlayers;
        Debug.Log(mPlayers);
        PhotonNetwork.ConnectUsingSettings("0.1");
        Debug.Log("START");
    }

    void OnJoinedLobby(){
        Debug.Log("joined lobby");

        RoomOptions roomOptions = new RoomOptions() { };
        roomOptions.MaxPlayers = (byte)mPlayers;
        Debug.Log((byte)mPlayers);
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom(){
        //PhotonNetwork.Instantiate("OVRPlayerController", Vector3.zero, Quaternion.identity, 0);
       
        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
        //Debug.Log();
        
        //PhotonNetwork.Instantiate("NetworkedCube", Vector3.zero, Quaternion.identity, 0);
        
    }
}