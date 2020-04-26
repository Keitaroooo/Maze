using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class OutAreaController : MonoBehaviour
{

    GameObject SEManagerGame;
    GameObject SEManagerGameOver;

    // Start is called before the first frame update
    void Start()
    {
        SEManagerGame = GameObject.Find("SEManagerGame");
        SEManagerGameOver = GameObject.Find("SEManagerGameOver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(SEManagerGame);
        Destroy(SEManagerGameOver);
        SceneManager.LoadScene("GameOverScene");
    }
}
