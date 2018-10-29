using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioOutput : MonoBehaviour {

    public bool isWalking   = false;
    public bool isGrounded  = false;
    public bool isJumping   = false;
    public bool isDoubleJump = false;
    public bool ability01 = false;
    public bool ability02 = false;
    public bool ability03 = false;
    public int currentSoul;

    public AudioSource PlayerFootsteps;
    public AudioSource PlayerJump;
    public AudioSource PlayerAbility;
    public AudioClip[] Footsteps;
    public AudioClip Brumund_Jump;
    public AudioClip Anya_Jump01;
    public AudioClip Anya_Jump02;
    public AudioClip Viraya_Jump01;
    public AudioClip Brumund_Ability01;
    public AudioClip Viraya_Ability01;

    // Use this for initialization
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {
        if (isWalking == true && isGrounded == true)
        {
            int index = Random.Range(0, Footsteps.Length);
            var tempClip = Footsteps[index];
            PlayerFootsteps.clip = tempClip;
            PlayerFootsteps.Play();
        }
        if(isJumping == true && currentSoul == 0)
        {
            PlayerJump.clip = Brumund_Jump;
            PlayerJump.Play();
        }
        if (isJumping == true && currentSoul == 1)
        {
            PlayerJump.clip = Anya_Jump01;
            PlayerJump.Play();
        }
        if (isDoubleJump == true)
        {
            PlayerJump.clip = Anya_Jump02;
        }
        if (isJumping == true && currentSoul == 2)
        {
            PlayerJump.clip = Viraya_Jump01;
            PlayerJump.Play();
        }
        if (ability01 == true && currentSoul == 0)
        {
            PlayerAbility.clip = Brumund_Ability01;
            PlayerAbility.Play();
        }
        if (ability01 == true && currentSoul == 2)
        {
            PlayerAbility.clip = Viraya_Ability01;
            PlayerAbility.Play();
        }
    }
}
