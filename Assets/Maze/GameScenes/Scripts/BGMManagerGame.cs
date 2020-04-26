using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManagerGame : MonoBehaviour
{


    public GameObject BGMXmarkButton;

    static public int BGMXmark;


    // Start is called before the first frame update
    void Start()
    {

        if (BGMManagerHome.BGMXmark == 1 || BGMXmark == 1)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BGMButtonPush()
    {
        this.gameObject.SetActive(false);
        BGMXmarkButton.SetActive(true);
        BGMXmark = 1;
    }

    public void BGMXmarkButtonPush()
    {
        this.gameObject.SetActive(true);
        BGMXmarkButton.SetActive(false);
        BGMXmark = 0;
        BGMManagerHome.BGMXmark = 0;
    }

}
