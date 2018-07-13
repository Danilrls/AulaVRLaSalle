using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    static public int nPlayers;
    static public bool isPaused = false;
    static public bool start = false;

    //start whenever the program gets executed
    private void Start(){
        nPlayers = 4;
        Debug.Log(nPlayers);
    }

    //sets users to game scene
    public void playGame (GameObject button) {
        switch (button.name){
            case "StudentButton":
                SceneManager.LoadScene("loading");
                break;
            case "Start":
                SceneManager.LoadScene("multiplayer");
                start = true;
                break;
            default:
                break;
       }
    }

    //check if a student tries to access the platform as a professor
    public bool isProfessor() {
        if (PhotonNetwork.isMasterClient){
            return true;
        }else{
            return false;
        }
    }

    //get amount of players registered for game
    public void numPlayers(GameObject button){

        switch (button.name){
            case "2Button":
                nPlayers = 2;
                Debug.Log(nPlayers);
                break;
            case "3Button":
                nPlayers = 3;
                Debug.Log(nPlayers);
                break;
            case "4Button":
                nPlayers = 4;
                Debug.Log(nPlayers);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    //pauses games for students
    [PunRPC]
    public void playPause(){
        if (isPaused){
            Debug.Log("paused");
            Time.timeScale = 1.0f;
            isPaused = false;
        }else{
            Debug.Log("play");
            Time.timeScale = 0.0f;
            isPaused = true;
        }
    }

    //Exit platform service
    public void exitPlatform () {
        Debug.Log("QUIT2");
        Application.Quit();
    } 
}
