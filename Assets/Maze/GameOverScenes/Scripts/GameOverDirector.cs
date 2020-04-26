using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDirector : MonoBehaviour
{
    GameObject SEManagerHome;

    public GameObject GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        SEManagerHome = GameObject.Find("SEManagerHome");
        TextManager.Init(Application.systemLanguage);
        GameOverText.GetComponent<Text>().text = TextManager.Get(TextManager.KEY.GAMEOVER);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToHome()
    {
        Destroy(SEManagerHome);
        SceneManager.LoadScene("HomeScene");
    }

}
