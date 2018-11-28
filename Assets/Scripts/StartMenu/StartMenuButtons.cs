using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour {

    public void GoToOpenWorld()
    {
        
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("LastLoadedScene", "Tutorial");
        //SceneManager.LoadScene(1);
        GetComponent<LoadScene>().LoadLevel(PlayerPrefs.GetString("LastLoadedScene"));
    }

    public void ContinueGame()
    {
        GameObject.FindGameObjectWithTag("DoorNr").GetComponent<DoNotDestroy>().NameOfTheObject = PlayerPrefs.GetString("EntryPoint", "Tutorial"); // set the exit object
        GetComponent<LoadScene>().LoadLevel(PlayerPrefs.GetString("LastLoadedScene"));


    }
}
