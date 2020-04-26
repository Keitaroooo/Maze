using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeDirector : MonoBehaviour
{ 

    static public int TotalStampNumber = 10;
    static public int width = 10, height = 10;
    public Slider SizeSlider;
    public Slider BallNumberSlider;
    public GameObject SizeText;
    public GameObject BallNumberText;
    public GameObject SEXmarkButton;
    public GameObject BGMXmarkButton;

    static public int BGMXmark;

    GameObject SEManagerGame;

    public GameObject TitleText;
    public GameObject StartText;
    public GameObject GoalText;
    public GameObject StartButtonText;

    // Start is called before the first frame update
    void Start()
    {
        SEManagerGame = GameObject.Find("SEManagerGame");
        TextManager.Init(Application.systemLanguage);
        TitleText.GetComponent<Text>().text = TextManager.Get(TextManager.KEY.MAZE);
        StartText.GetComponent<Text>().text = ": " + TextManager.Get(TextManager.KEY.START);
        GoalText.GetComponent<Text>().text = ": " + TextManager.Get(TextManager.KEY.GOAL);
        StartButtonText.GetComponent<Text>().text =TextManager.Get(TextManager.KEY.START);
    }

    // Update is called once per frame
    void Update()
    {
        TotalStampNumber = (int)BallNumberSlider.value;
        width = (int)SizeSlider.value * 2 ;
        height = (int)SizeSlider.value * 2;
        SizeText.GetComponent<Text>().text = TextManager.Get(TextManager.KEY.SIZE)+" : " + width.ToString();
        BallNumberText.GetComponent<Text>().text = " : " + TotalStampNumber.ToString();

    }

    public void StartButton()
    {
        Destroy(SEManagerGame);
        SceneManager.LoadScene("GameScene");

    }

    public void BGMButtonPush()
    {
        BGMXmarkButton.SetActive(true);
        BGMXmark = 1;

    }

    public void BGMXmarkButtonPush()
    {
        BGMXmarkButton.SetActive(false);
        BGMXmark = 0;
    }
}
