using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Scene currentScene;

	// Use this for initialization
	void Start () {

        Debug.Log("hello");

        currentScene = SceneManager.GetActiveScene();
        cam1 = GameObject.Find("ExteriorCamera").GetComponent<Camera>();
        cam2 = GameObject.Find("ExteriorPirateCamera").GetComponent<Camera>();
        cam3 = GameObject.Find("ExteriorNavyCamera").GetComponent<Camera>();

        Debug.Log(cam1);
        Debug.Log(cam2);
        Debug.Log(cam3);

        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentScene.name == "multiplayer" && PhotonNetwork.isMasterClient){
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentScene.name == "multiplayer" && PhotonNetwork.isMasterClient){
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentScene.name == "multiplayer" && PhotonNetwork.isMasterClient){
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
        }
    }
}
