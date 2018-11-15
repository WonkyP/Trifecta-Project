using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int daughterlife = 3;
    public int fatherLife = 3;
    public int spiritLife = 3;


    public bool testingLifeResotore = false;
    public int testInitialLifes = 6;
    public bool testRecoveLive = false;

    public int elementosLista = 0;
    public int elementosStack = 0;

    public List<Image> imageList;
    private Stack<Image> lifesStack;
    private Stack<Image> lifesStackLost;
    //private Stack<Image> lifesStackLost;

    // This manages the current character the player is using
    //int currentCharacter = 0;

    void Start()
    {
        instance = this;
        lifesStack = new Stack<Image>();
        lifesStackLost = new Stack<Image>();

        stackFiller();
        //get the current lifes sved between scenes
        daughterlife = PlayerPrefs.GetInt("daughterLife", daughterlife);
        spiritLife = PlayerPrefs.GetInt("spiritLife", spiritLife);
        fatherLife = PlayerPrefs.GetInt("fatherLife", fatherLife);

        //canvasAnimator = canvasCharacterImage.GetComponent<Animator>();
        ////abilitySelected.text = "Choosen Character " + currentCharacter;
        ////abilityExplanation.text = "Daughter can Jump by pressing 'Z'"; Maybe for monday 17/09/18 will be useful to use this
        //abilitySelected.text = "";
        //abilityExplanation.text = "";

        //if (youWin != null)
        //{
        //    youWin.enabled = false;

        //}
        //stackFiller();

        elementosLista = imageList.Count;
        elementosStack = lifesStack.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (testingLifeResotore) {
            testingRestoreLifes();
        }

        if (testRecoveLive)
        {
            recoverFatherLifes();
            testRecoveLive = false;
        }
    }
    public void missionComplete()
    {
        //if (youWin != null)
        //{
        //    youWin.enabled = true;

        //}
    }

    public void updateHUD(int nr) //change the image showed on the HUD
    {

        //switch (nr)
        //{
        //    case 0: // change to the girl
        //        canvasAnimator.Play("HUDGirl");
        //        break;
         
        //    case 1: // change to the warrior 
        //        canvasAnimator.Play("HUDWarrior");
        //        break;
        //    case 2://cahnge to the wizarld
        //        canvasAnimator.Play("HUDwizard");
        //        break;

        //}

    }

    void printCharacterInfo()
    {
        //string name;
        //string explanation;

        //switch (currentCharacter)
        //{
        //    case 0:
        //        name = "Daughter";
        //        explanation = "Daughter can Jump by pressing 'Z'";
        //        break;
        //    case 1:
        //        name = "Spirit of the forest";
        //        explanation = "Spirit of the forest can move heavy blocks by pressing 'Z'";
        //        break;
        //    case 2:
        //        name = "Father";
        //        explanation = "Father can reveal the darkest secrets by pressing 'Z'";
        //        break;
        //    default:
        //        name = "No character selected correctly";
        //        explanation = "Daughter can Jump by pressing 'Z'";
        //        break;
        //}

        //abilitySelected.text = "Choosen Character: " + name;
        //abilityExplanation.text = explanation;
    }
    
    private void checkLifes()
    {
        if (fatherLife <=0 || daughterlife <=0 || spiritLife <=0)
        {
            testingRestoreLifes();
            Debug.Log("You died");
        }
    }

    public void fatherDamage()
    {
        //damaged();
        fatherLife--;
        damaged();
        checkLifes();
        PlayerPrefs.SetInt("fatherLife", fatherLife);
    }

    public void daughterDamage()
    {
        
        daughterlife--;
        
        checkLifes();
        PlayerPrefs.SetInt("daughterLife", daughterlife);
    }

    public void spiritDamage()
    {
        spiritLife--;
     
        checkLifes();
        PlayerPrefs.SetInt("spiritLife", spiritLife);
    }

    void testingRestoreLifes()
    {
        fatherLife = spiritLife = daughterlife = testInitialLifes;
        testingLifeResotore = false;
    }


    private void stackFiller()
    {

        int size = imageList.Count;
        for (int i = 0; i < size; i++)
        {
            lifesStack.Push(imageList[i]);
        }

        imageList.Clear();
    }

    void damaged()
    {
        Image heart;
        heart = lifesStack.Peek();
        heart.enabled = false;
        lifesStack.Pop();
        lifesStackLost.Push(heart);
    }

    void recoverFatherLifes() {
        Image heart;
        heart = lifesStackLost.Peek();
        heart.enabled = true;
        lifesStackLost.Pop();
        lifesStack.Push(heart);
    }
}
