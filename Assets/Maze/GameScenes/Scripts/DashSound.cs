using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SEManagerHome.SEXmark == 1 || SEManagerGame.SEXmark == 1)
        {
            this.gameObject.SetActive(false);
        }

        if (0 == CameraController.speed)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void ForwardButton()
    {
        if (CameraController.speed > 0.02)
        {
            if (SEManagerGame.SEXmark != 1 && SEManagerHome.SEXmark != 1)
            {
                this.gameObject.SetActive(true);
            }

        }

        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void PauseButton()
    {
        this.gameObject.SetActive(false);
    }
}
