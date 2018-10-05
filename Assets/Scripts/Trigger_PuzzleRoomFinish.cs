using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_PuzzleRoomFinish : MonoBehaviour {

    public GameObject ScorePresenter;
    public Sprite SoulShard;
    private Image Score1;
    private Image Score2;
    private Image Score3;
    private Color tmp;
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
            ScorePresenter.transform.GetChild(6).gameObject.GetComponent<Button>().onClick.AddListener(OKButton);
        }
    }

    IEnumerator ShowScore()
    {
        tmp.a = 255f;
        tmp.r = 255f;
        tmp.g = 255f;
        tmp.b = 255f;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if(GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= 1)
        {
            Score1.sprite = SoulShard;       
            Score1.color = tmp;
            Debug.Log("Soul sprite attached to score 1!");
            scoreToDisplay.text = "1";
        }
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= 3)
        {
            Score2.sprite = SoulShard;
            Score2.color = tmp;
            scoreToDisplay.text = "2";
        }
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Canvas_PuzzleRoom").gameObject.GetComponent<ChardCounter>().curShardCount >= 5)
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
    }

    // Update is called once per frame
    void Update () {
		
	}
}
