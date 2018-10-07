using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShardControll : MonoBehaviour {

    public int SoulShards;

    public bool RemovePP = false;

    [Header("should be assigned in the prefab")]
    public Text TextOfUI;
    public Canvas Canvas;


    private void Start()
    {
        Canvas.worldCamera = Camera.main; // set the camera

        if (RemovePP) // for play testing you can remove the soulshard count with this bool activ
        {
            PlayerPrefs.DeleteKey("SoulShards");
        }

        UpdateNumbers();


    }

    public void UpdateNumbers () {
        SoulShards = PlayerPrefs.GetInt("SoulShards", 0); 
        TextOfUI.text = SoulShards.ToString(); // send the text to the UI
	}

}
