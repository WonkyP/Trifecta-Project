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

    public GameObject SpiritLife;
    public GameObject DaughterLife;
    public GameObject FatherLife;

    public GameObject youDie;

    public bool testingLifeResotore = false;
    public int testInitialLifes = 6;
    public bool testRecoveLive = false;


    public List<Image> wizzardList;
    private Stack<Image> lifesWizzardStack;
    private Stack<Image> lifesWizzardStackLost;
    //private Stack<Image> lifesStackLost;

    public List<Image> daughterdList;
    private Stack<Image> lifesDaughterStack;
    private Stack<Image> lifesDaughterStackLost;

    public List<Image> spiritList;
    private Stack<Image> lifesSpiritStack;
    private Stack<Image> lifesSpriritStackLost;

    // This manages the current character the player is using
    //int currentCharacter = 0;



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lifesWizzardStack = new Stack<Image>();
        lifesWizzardStackLost = new Stack<Image>();

        lifesSpiritStack = new Stack<Image>();
        lifesSpriritStackLost = new Stack<Image>();

        lifesDaughterStack = new Stack<Image>();
        lifesDaughterStackLost = new Stack<Image>();

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

        youDie.SetActive(false);
        testingRestoreLifes();
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
            youDie.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void fatherDamage()
    {
        //damaged();
        fatherLife--;
        updateFatherLife();
        checkLifes();
        PlayerPrefs.SetInt("fatherLife", fatherLife);
    }

    public void daughterDamage()
    {
        
        daughterlife--;
        updateDaughterLife();
        checkLifes();
        PlayerPrefs.SetInt("daughterLife", daughterlife);
    }

    public void spiritDamage()
    {
        spiritLife--;
        updateSpiritLife();
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

        int size = wizzardList.Count;
        for (int i = 0; i < size; i++)
        {
            lifesWizzardStack.Push(wizzardList[i]);
        }

        wizzardList.Clear();


        size = daughterdList.Count;
        for (int i = 0; i < size; i++)
        {
            lifesDaughterStack.Push(daughterdList[i]);
        }

        daughterdList.Clear();



        size = spiritList.Count;
        for (int i = 0; i < size; i++)
        {
            lifesSpiritStack.Push(spiritList[i]);
        }

        spiritList.Clear();
    }

    void updateFatherLife()
    {
        Image heart;
        heart = lifesWizzardStack.Peek();
        heart.enabled = false;
        lifesWizzardStack.Pop();
        lifesWizzardStackLost.Push(heart);
    }

    void updateDaughterLife()
    {
        Image heart;
        heart = lifesDaughterStack.Peek();
        heart.enabled = false;
        lifesDaughterStack.Pop();
        lifesDaughterStackLost.Push(heart);
    }


    void updateSpiritLife()
    {
        Image heart;
        heart = lifesSpiritStack.Peek();
        heart.enabled = false;
        lifesSpiritStack.Pop();
        lifesSpriritStackLost.Push(heart);
    }

    void recoverFatherLifes() {
        Image heart;
        heart = lifesWizzardStackLost.Peek();
        heart.enabled = true;
        lifesWizzardStackLost.Pop();
        lifesWizzardStack.Push(heart);
    }

    public void EnableDaughterLife()
    {
        SpiritLife.SetActive(false);
        DaughterLife.SetActive(true);
        FatherLife.SetActive(false);
    }

    public void EnableFatherLife()
    {
        SpiritLife.SetActive(false);
        DaughterLife.SetActive(false);
        FatherLife.SetActive(true);
    }

    public void EnableSpiritLife()
    {
        SpiritLife.SetActive(true);
        DaughterLife.SetActive(false);
        FatherLife.SetActive(false);
    }

    public void resetScene2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level02");
    }
}
