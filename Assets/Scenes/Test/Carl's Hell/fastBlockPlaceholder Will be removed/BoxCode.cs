using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCode : MonoBehaviour {

    // Just a smart block from room design
    public Transform box;
    Color col;

    // Use this for initialization
    void Start () {
        Text uiText = GetComponent<Text>(); // get uiText component
        uiText.text = box.localScale.x + " x " + box.localScale.y; // set the text to show the size
        col = new Color(box.localScale.x * 0.1f, 0, box.localScale.y * 0.1f); // set color based on the size of the game
        uiText.color = col; // set the color
	}

}
