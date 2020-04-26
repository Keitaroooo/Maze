using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GoalStandController : MonoBehaviour
{
    GameObject GameDirector;
    GameDirector GameDirectorscript;
    GameObject SEManagerClear;
    GameObject SEManagerGame;

    // Start is called before the first frame update
    void Start()
    {
        SEManagerGame = GameObject.Find("SEManagerGame");
        this.GameDirector = GameObject.Find("GameDirector");
        GameDirectorscript = GameDirector.GetComponent<GameDirector>();
        SEManagerClear = GameObject.Find("SEManagerClear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider others)
    {
        //ゴール判定（カメラとの衝突判定）
        if (GameDirectorscript.GetStampNumber == HomeDirector.TotalStampNumber)
        {
            Destroy(SEManagerGame);
            Destroy(SEManagerClear);
            SceneManager.LoadScene("ClearScene");
        }
    }

}

