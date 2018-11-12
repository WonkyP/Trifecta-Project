using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine_PuzzleRoom : MonoBehaviour
{

    public bool PlayerInRange;
    public bool InteractionButtonPressed;

    public GameObject PuzzleExit;

    // Use this for initialization
    void Start()
    {
        PuzzleExit = GameObject.Find("PuzzleRoom_Exit");
        PuzzleExit.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player in Range");
            PlayerInRange = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInRange = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerInRange == true && InteractionButtonPressed == false)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("Interation pressed");
                InteractionButtonPressed = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                PuzzleExit.SetActive(true);

            }
        }

    }
}
