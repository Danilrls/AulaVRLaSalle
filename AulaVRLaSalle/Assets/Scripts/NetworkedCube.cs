using UnityEngine;
using System.Collections;

public class NetworkedCube : Photon.MonoBehaviour
{

    public Transform cubeTransform;
    public GameObject cube;

    

    void Start ()
    {
        
        this.transform.position = new Vector3(2,1,1);
        Debug.Log("i'm A CUBE instantiated");
        
        if (photonView.isMine)
        {
            cubeTransform = GameObject.Find("NetworkedCube(Clone)").transform;
            cube = GameObject.Find("NetworkedCube(Clone)");
            
           // this.transform.localPosition = Vector3.zero;
            // avatar.SetActive(false);
        }
    }
    void update(){
        
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // if (stream.isWriting)
        // {
        //     stream.SendNext(cubeTransform.position);
        //     stream.SendNext(cubeTransform.rotation);
        // }
        // else
        // {
        //     cube.transform.localPosition = (Vector3)stream.ReceiveNext();
        //     cube.transform.localRotation = (Quaternion)stream.ReceiveNext();
        // }
    }
}