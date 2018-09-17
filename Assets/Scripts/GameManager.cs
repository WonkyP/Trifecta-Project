using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text abilitySelected;
    public Text abilityExplanation;

    public Image canvasCharacterImage;
    public Image youWin;

    private Animator canvasAnimator;

    // This manages the current character the player is using
    int currentCharacter = 0;

    void Start()
    {
        instance = this;

        canvasAnimator = canvasCharacterImage.GetComponent<Animator>();
        //abilitySelected.text = "Choosen Character " + currentCharacter;
        //abilityExplanation.text = "Daughter can Jump by pressing 'Z'"; Maybe for monday 17/09/18 will be useful to use this
        abilitySelected.text = "";
        abilityExplanation.text = "";

        youWin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void missionComplete()
    {
        youWin.enabled = true;
    }

    public void updateHUD(int nr) //change the image showed on the HUD
    {

        switch (nr)
        {
            case 0: // change to the girl
                canvasAnimator.Play("HUDGirl");
                break;
         
            case 1: // change to the warrior 
                canvasAnimator.Play("HUDWarrior");
                break;
            case 2://cahnge to the wizarld
                canvasAnimator.Play("HUDwizard");
                break;

        }

    }

    void printCharacterInfo()
    {
        string name;
        string explanation;

        switch (currentCharacter)
        {
            case 0:
                name = "Daughter";
                explanation = "Daughter can Jump by pressing 'Z'";
                break;
            case 1:
                name = "Spirit of the forest";
                explanation = "Spirit of the forest can move heavy blocks by pressing 'Z'";
                break;
            case 2:
                name = "Father";
                explanation = "Father can reveal the darkest secrets by pressing 'Z'";
                break;
            default:
                name = "No character selected correctly";
                explanation = "Daughter can Jump by pressing 'Z'";
                break;
        }

        abilitySelected.text = "Choosen Character: " + name;
        abilityExplanation.text = explanation;
    }
}
