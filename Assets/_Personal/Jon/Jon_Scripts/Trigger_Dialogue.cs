using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_Dialogue : MonoBehaviour {

    private GameObject player;
    public string[] texts;
    public Text floatingText;

	// Use this for initialization
	void Start () {
        //Getting references
        player = GameObject.FindGameObjectWithTag("Player");
        floatingText = player.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Starting coroutine on trigger enter.
        if(collision.tag == "Player")
        {
            StartCoroutine("DisplayTexts");
        }
    }
    
    //Coroutine for displaying messages in the trigger's public strings one at a time with a delay.
    IEnumerator DisplayTexts()
    {
        foreach(string message in texts)
        {
            floatingText.text = message;
            yield return new WaitForSeconds(5);
        }
        
        yield return null;
        //Reset floating text over player and destroy trigger.
        floatingText.text = "";
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
