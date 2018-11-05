using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jon_AnimationEventTest : MonoBehaviour {

    public AudioSource Movement;
    public AudioClip[] Footsteps;
    public AudioClip BrumundJump;
    public AudioClip AnyaJump;
    public AudioClip AnyaJump2;
    public AudioClip VirayaJump;

	// Use this for initialization
	void Start () {
		
	}

    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
    public void PlayFoot()
    {
        int index = Random.Range(0, Footsteps.Length);
        var tempClip = Footsteps[index];
        Movement.clip = tempClip;
        Movement.PlayOneShot(tempClip);
        //AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }
    public void PlayJump(AudioClip clip)
    {
        Movement.clip = clip;
        Movement.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
