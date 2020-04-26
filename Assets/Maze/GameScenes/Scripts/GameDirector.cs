using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Advertisements;

public class GameDirector : MonoBehaviour
{

    public GameObject StartTime;
    public GameObject TimeObject;
    public GameObject StampNumberObject;

    public Button ForwardButton;
    public Button StopButton;

    public GameObject PauseScreen;
    public GameObject HomeButton;
    public GameObject ContinueButton;
    public GameObject PauseText;
    public GameObject SEButton;
    public GameObject BGMButton;
    public GameObject SEXmarkButton;
    public GameObject BGMXmarkButton;

    Vector3 StartPosition;

    static public float starttime = 3.5f;
    public float starttime1 = 3.5f;
    float time = 0.0f;
    static public int minute;
    static public float second;

    public int GetStampNumber = 0;

    GameObject SEManagerHomePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        starttime = 3.5f;
        SEManagerHomePrefab = GameObject.Find("SEManagerHome");
        TextManager.Init(Application.systemLanguage);
        PauseText.GetComponent<Text>().text = TextManager.Get(TextManager.KEY.PAUSE);
    }

    // Update is called once per frame
    void Update()
    {
        if (starttime >= 0.2f)
        {
            starttime -= Time.deltaTime;
            starttime1 -= Time.deltaTime;


            if (starttime >= 0.5f)
            {
                StartTime.GetComponent<Text>().text = starttime.ToString("f0");
            }

            else
            {
                ForwardButton.interactable = true;
                StopButton.interactable = true;
            }
        }

        else
        {
            StartTime.GetComponent<Text>().text = null;
            Text TimeText = TimeObject.GetComponent<Text>();
            time += Time.deltaTime;
            minute = ((int)time) / 60;
            second = time % 60;
            TimeText.text = minute.ToString("00") + ":" + second.ToString("00.0");
        }

        Text GetStampText = StampNumberObject.GetComponent<Text>();
        GetStampText.text = GetStampNumber.ToString() +"/" + HomeDirector.TotalStampNumber.ToString();
    }


    public void PauseButtonPush()
    {
        Time.timeScale = 0f;

        PauseScreen.SetActive(true);
        HomeButton.SetActive(true);
        ContinueButton.SetActive(true);
        PauseText.SetActive(true);
        SEButton.SetActive(true);
        BGMButton.SetActive(true);

        if(SEManagerGame.SEXmark == 1 || SEManagerHome.SEXmark == 1)
        {
            SEXmarkButton.SetActive(true);
        }

        if(BGMManagerGame.BGMXmark ==1 || BGMManagerHome.BGMXmark == 1)
        {
            BGMXmarkButton.SetActive(true);
        }
        
    }

    public void HomeButtonPush()
    {
        Destroy(SEManagerHomePrefab);
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        SceneManager.LoadScene("HomeScene");
    }

    public void ContinueButtonPush()
    {
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
        HomeButton.SetActive(false);
        ContinueButton.SetActive(false);
        PauseText.SetActive(false);
        SEButton.SetActive(false);
        BGMButton.SetActive(false);
        SEXmarkButton.SetActive(false);
        BGMXmarkButton.SetActive(false);
        CameraController.speed = 0;
    }
}



