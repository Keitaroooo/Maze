using UnityEngine;

public class SEManagerGame :MonoBehaviour
{
      
        
    public AudioClip HomeButton1;
    public AudioClip Button1;
    public AudioClip CountDown;
    public AudioClip Go;
    public GameObject SEXmarkButton;

    static public int SEXmark ;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SEManagerHome.SEXmark == 1 || SEXmark ==1)
        {
            this.gameObject.SetActive(false);
        }

        if ((3.3f < GameDirector.starttime && GameDirector.starttime < 3.4f) || (2.3f < GameDirector.starttime && GameDirector.starttime < 2.4f) || (1.3f < GameDirector.starttime && GameDirector.starttime < 1.4f))
            {
                audioSource.PlayOneShot(CountDown);
            }

            else if (0.2f < GameDirector.starttime && GameDirector.starttime < 0.4f)
            {
                audioSource.PlayOneShot(Go);
            }

    }

    public void HomeButtonPush1()
    {
        audioSource.PlayOneShot(HomeButton1);
        this.gameObject.SetActive(true);
    }

    public void ButtonPush1()
    {
        audioSource.PlayOneShot(Button1);
    }

    public void SEButtonPush()
    {
        this.gameObject.SetActive(false);
        SEXmarkButton.SetActive(true);
        SEXmark = 1;

    }

    public void SEXmarkButtonPush()
    {
        this.gameObject.SetActive(true);
        SEXmarkButton.SetActive(false);
        SEXmark = 0;
        SEManagerHome.SEXmark = 0;
    }


}
