using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Advertisements;

public class ClearDirector : MonoBehaviour
{
    GameObject SEManagerHome;

    public GameObject GameClearText;
    public GameObject SizeText;
    public GameObject GetStampText;
    public GameObject TimeText;

    // Start is called before the first frame update
    void Start()
    {
        SEManagerHome = GameObject.Find("SEManagerHome");
        TextManager.Init(Application.systemLanguage);
        GameClearText.GetComponent<Text>().text = TextManager.Get(TextManager.KEY.GAMECLEAR);
        SizeText.GetComponent<Text>().text = TextManager.Get(TextManager.KEY.SIZE) + " :  " + HomeDirector.width.ToString();
        GetStampText.GetComponent<Text>().text = " :  " + HomeDirector.TotalStampNumber.ToString() + "/" + HomeDirector.TotalStampNumber.ToString();
        TimeText.GetComponent<Text>().text = " :  " + GameDirector.minute.ToString("00") + ":" + GameDirector.second.ToString("00.0");

    }
        // Update is called once per frame
        void Update()
    {
        
    }

    public void BackToHome()
    {
        Destroy(SEManagerHome);
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        SceneManager.LoadScene("HomeScene");
    }


}
