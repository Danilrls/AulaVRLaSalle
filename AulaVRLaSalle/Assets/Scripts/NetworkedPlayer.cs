using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NetworkedPlayer : Photon.MonoBehaviour
{
    public GameObject avatar;

    public Transform playerGlobal;
    public Transform playerLocal;


    
    void Start ()
    {
        if (PhotonNetwork.isMasterClient){
            Debug.Log("I AM MASTER");
        }
        else{
            if (photonView.isMine){
                //playerGlobal es el transform del player
                playerGlobal = GameObject.Find("OVRPlayerController").transform;
                //playerLocal es la cabeza del player
                playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");


                this.transform.SetParent(playerLocal);
                // this.transform.localPosition = Vector3.zero;

                // avatar.SetActive(false);
            }
        }
    }
	
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);

            stream.SendNext(playerLocal.localPosition);
            stream.SendNext(playerLocal.localRotation);
      
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();

            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
            
        }
    }

    public void backToMenu() {

        Debug.Log(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex - 1);
        //kill game
        PhotonNetwork.LeaveLobby();
    }
}