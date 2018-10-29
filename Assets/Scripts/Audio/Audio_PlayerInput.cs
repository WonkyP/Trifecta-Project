using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Audio_PlayerInput : MonoBehaviour {

    public AudioSource PlayerFootsteps;
    public AudioSource PlayerJump;
    public AudioClip[] Footsteps;
    public AudioClip Brumund_Jump;
    public AudioClip Anya_Jump01;
    public AudioClip Anya_Jump02;
    public AudioClip Viraya_Jump01;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
         if (Input.GetKeyDown(KeyCode.Space))
     {
         int index = Random.Range(0, Footsteps.Length);
         var tempClip = Footsteps[index];
         PlayerFootsteps.clip = tempClip;
         PlayerFootsteps.Play();
     }

	}
}
