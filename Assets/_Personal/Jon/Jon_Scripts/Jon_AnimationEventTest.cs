using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jon_AnimationEventTest : MonoBehaviour {

    public AudioSource Movement;
    public AudioClip[] Footsteps;

	// Use this for initialization
	void Start () {
		
	}

    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
    public void PlayFoot()
    {
        Movement.PlayOneShot(Footsteps[1]);
        //AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
