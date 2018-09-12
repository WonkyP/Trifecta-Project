using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text abilitySelected;
    public Text abilityExplanation;
    public Image canvasCharacterImage;

    private Animator canvasAnimator;

    // This manages the current character the player is using
    int currentCharacter = 0;

    void Start()
    {
        //instance = this;

        canvasAnimator = canvasCharacterImage.GetComponent<Animator>();
        canvasAnimator.Play("HUDWarrior");
        abilitySelected.text = "Choosen Character " + currentCharacter;
        abilityExplanation.text = "Daughter can Jump by pressing 'Z'";
    }

    // Update is called once per frame
    void Update()
    {
        printCharacterInfo();
    }

    public void updateHUD(int nr)
    {
        //change the image showed on the HUD

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
