using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text abilitySelected;
    public Text abilityExplanation;

    // This manages the current character the player is using
    int currentCharacter = 0;

    void Start()
    {
        instance = this;
        abilitySelected.text = "Choosen Character " + currentCharacter;
        abilityExplanation.text = "Daughter can Jump by pressing 'Z'";
    }

    // Update is called once per frame
    void Update()
    {
        printCharacterInfo();
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
