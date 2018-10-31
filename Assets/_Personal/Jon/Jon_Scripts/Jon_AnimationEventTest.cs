using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jon_AnimationEventTest : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
