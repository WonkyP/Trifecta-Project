using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardControll : MonoBehaviour {

    public int SoulShards;

    private void Start()
    {
        UpdateNumbers();
    }

    public void UpdateNumbers () {
        SoulShards = PlayerPrefs.GetInt("SoulShards", 0);
	}

}
