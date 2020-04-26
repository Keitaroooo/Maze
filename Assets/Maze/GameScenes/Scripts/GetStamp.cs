using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GetStamp : MonoBehaviour
{
    public GameObject Sphere;

    float distance;
    public float TargetDistance;

    GameObject GameDirector;
    GameDirector GameDirectorscript;
    public AudioClip GetBallSound;
    GameObject CameraController;
    CameraController CameraControllerscript;

    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.GameDirectorscript = this.GameDirector.GetComponent<GameDirector>();
        this.CameraController= GameObject.Find("MainCamera");
        this.CameraControllerscript = this.CameraController.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f) || GameDirectorscript.starttime1 >= 0.5f)
        {
            return;
        }
    }

    public void Destroy()
    {
        if (Mathf.Approximately(Time.timeScale, 0f) || GameDirectorscript.starttime1 >= 0.5f)
        {
            return;
        }

        distance = (transform.position - CameraControllerscript.mainCamera.transform.position).sqrMagnitude;


        if (distance < TargetDistance)
        {
            Destroy(this.Sphere);
            GameDirectorscript.GetStampNumber++;

            if (SEManagerGame.SEXmark == 0 && SEManagerHome.SEXmark == 0)
            {
                AudioSource.PlayClipAtPoint(GetBallSound, this.Sphere.transform.position);
            }

        }
    }


    
}
