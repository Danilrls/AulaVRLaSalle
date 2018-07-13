using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	[PunRPC]
	private void onPickup(Vector3 position){
		GameObject.Find("Sphere").transform.position = position;
	}

	void Update () {
		//this.GetComponent<PhotonView>().RPC("onPickup",PhotonTargets.MasterClient, new object[]{this.transform.position});
	}
	void onTriggerEnter(Collider collider){
		//PhotonView pv = collider.gameObject.GetComponent<PhotonView>();
		//this.GetComponent<PhotonView>().RPC("onPickup",PhotonTargets.MasterClient, new object[]{this.transform.position});
	}
	//Esta funcion se llamara desde la pelota y se ejecutara en los otros clientes
	

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(this.transform.position);
            stream.SendNext(this.transform.rotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
