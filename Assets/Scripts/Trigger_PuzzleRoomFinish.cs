using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_PuzzleRoomFinish : MonoBehaviour {

    public GameObject ScorePresenter;
    public Sprite SoulShard;
    public Image Score1;
    public Image Score2;
    public Image Score3;
    public Text scoreToDisplay;

	// Use this for initialization
	void Start () {

        ScorePresenter = GameObject.FindGameObjectWithTag("Canvas_PuzzleRoom").transform.GetChild(2).gameObject;
        SoulShard = Resources.Load<Sprite>("Placeholders/ShardPNG");
        scoreToDisplay = ScorePresenter.transform.GetChild(5).gameObject.GetComponent<Text>();
        Score1 = ScorePresenter.transform.GetChild(1).GetComponent<Image>();
        Score2 = ScorePresenter.transform.GetChild(2).GetComponent<Image>();
        Score3 = ScorePresenter.transform.GetChild(3).GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ScorePresenter.SetActive(true);
            StartCoroutine("ShowScore");
            
        }
    }

    IEnumerator ShowScore()
    {
        if(GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= 1)
        {
            Score1.sprite = SoulShard;
            Debug.Log("Soul sprite attached to score 1!");
            scoreToDisplay.text = "1";
        }
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= 3)
        {
            Score2.sprite = SoulShard;
            scoreToDisplay.text = "2";
        }
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= 5)
        {
            Score3.sprite = SoulShard;
            scoreToDisplay.text = "3";
        }
        yield return null;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
