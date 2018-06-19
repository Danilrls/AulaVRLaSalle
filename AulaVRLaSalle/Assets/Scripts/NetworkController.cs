using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;

public class NetworkController : MonoBehaviour
{
    string _room = "Tutorial_Convrge";
    private bool spawnLimited;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        spawnLimited = false;
        Debug.Log("START");
    }

    void OnJoinedLobby()
    {
        Debug.Log("joined lobby");

        RoomOptions roomOptions = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        //PhotonNetwork.Instantiate("OVRPlayerController", Vector3.zero, Quaternion.identity, 0);
       
        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
        Debug.Log(spawnLimited);
        
        //PhotonNetwork.Instantiate("NetworkedCube", Vector3.zero, Quaternion.identity, 0);
       
        
    }
}