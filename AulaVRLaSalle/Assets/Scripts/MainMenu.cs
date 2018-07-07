using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    static public int nPlayers;
    static public bool isPaused = false;

    private void Start()
    {
        nPlayers = 4;
        Debug.Log(nPlayers);
    }

    //start whenever the program gets executed
    public void playGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Exit platform service
    public void exitPlatform () {
        Debug.Log("QUIT2");
        Application.Quit();
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

    [PunRPC]
    private void playPause(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused)
            {
                Time.timeScale = 1.0f;
                isPaused = false;
            }
            else{
                Time.timeScale = 0.0f;
                isPaused = true;
            }
        }
    }
}
