﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger_PuzzleRoomFinish : MonoBehaviour {

    public bool PlayerInRange;
    public bool InteractionButtonPressed;

    public string SceneToLoad;

    public GameObject ScorePresenter;
    public Sprite SoulShard;
    private Image Score1;
    private Image Score2;
    private Image Score3;
    private Color tmp;
    public Text scoreToDisplay;

    [Header("Charges for Score")]
    [TextArea]
    public string myTextArea = "Number of charges left to determine score for this challenge";
    public int ChargesForScore1;
    public int ChargesForScore2;
    public int ChargesForScore3;

	// Use this for initialization
	void Start () {
        //Finding references
        ScorePresenter = GameObject.FindGameObjectWithTag("Canvas_PuzzleRoom").transform.GetChild(2).gameObject;
        SoulShard = Resources.Load<Sprite>("Placeholders/ShardPNG");
        scoreToDisplay = ScorePresenter.transform.GetChild(5).gameObject.GetComponent<Text>();
        Score1 = ScorePresenter.transform.GetChild(1).GetComponent<Image>();
        Score2 = ScorePresenter.transform.GetChild(2).GetComponent<Image>();
        Score3 = ScorePresenter.transform.GetChild(3).GetComponent<Image>();
        PlayerInRange = false;
        InteractionButtonPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInRange = true;           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInRange = false;
        }
    }

    //Coroutine for summarazing player performance in puzzle-room
    IEnumerator ShowScore()
    {
        //Getting color values
        tmp.a = 255f;
        tmp.r = 255f;
        tmp.g = 255f;
        tmp.b = 255f;
        //Disable trigger collider, so it only happens once
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //These if statements look at Carl's script to find the current number of soul charges left and gives scores accordingly.
        if(GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= ChargesForScore1)
        {
            Score1.sprite = SoulShard;       
            Score1.color = tmp;
            Debug.Log("Soul sprite attached to score 1!");
            scoreToDisplay.text = "1";
        }
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= ChargesForScore2)
        {
            Score2.sprite = SoulShard;
            Score2.color = tmp;
            scoreToDisplay.text = "2";
        }
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= ChargesForScore3)
        {
            Score3.sprite = SoulShard;
            Score3.color = tmp;
            scoreToDisplay.text = "3";
        }

        yield return null;
    }

    public void OKButton()
    {
        ScorePresenter.SetActive(false);
        SceneManager.LoadScene(SceneToLoad);
    }

    // Update is called once per frame
    void Update () {
		if(PlayerInRange == true && InteractionButtonPressed == false)
        {
            if (Input.GetButtonDown("Interact"))
            {
                InteractionButtonPressed = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<GeneralPlayerMovement>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<DaughterMovement>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpiritMovement>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<FatherMovement>().enabled = false;
                ScorePresenter.SetActive(true);
                ScorePresenter.transform.GetChild(6).gameObject.GetComponent<Button>().onClick.AddListener(OKButton);
                StartCoroutine("ShowScore");
                
            }
        }
	}
}
