using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShardControll : MonoBehaviour {

    public int SoulShards;
    public Text TextOfUI;

    public bool RemovePP = false;

    private void Start()
    {
        if (RemovePP)
        {
            PlayerPrefs.DeleteAll();
        }

        UpdateNumbers();


    }

    public void UpdateNumbers () {
        SoulShards = PlayerPrefs.GetInt("SoulShards", 0);
        TextOfUI.text = SoulShards.ToString();
	}

}
