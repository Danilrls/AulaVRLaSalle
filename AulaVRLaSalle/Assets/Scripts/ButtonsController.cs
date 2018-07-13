using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;

public class ButtonsController : MonoBehaviour {

	// Use this for initialization
	private bool clicked;
	private bool canClick;
	private float rotation;
	void Start () {
		clicked = false;
		canClick = true;
		rotation = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//canClick = true;
		if(PhotonNetwork.isMasterClient){
			
			clicked = OVRInput.Get(OVRInput.Button.One);
			if(clicked &&  canClick){
				GameObject.Find("FjalarPreview").transform.Rotate(rotation,0,0);
				GameObject.Find("CauacPreview").transform.Rotate(rotation,0,0);
				//canClick = false;
				this.rotation = rotation + 0.1f;
				// 
			}

		}
		
	}
}
