using UnityEngine;

public class SEManagerHome :MonoBehaviour
{
        

    public AudioClip Button2;
  
    public GameObject SEXmarkButton;

    static public int SEXmark;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        if (SEXmark == 1 || SEManagerGame.SEXmark == 1)
        {
            this.gameObject.SetActive(false);
            this.SEXmarkButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SEButtonPush()
    {
        this.gameObject.SetActive(false);
        this.SEXmarkButton.SetActive(true);
        SEXmark = 1;
    }

    public void SEXmarkButtonPush()
    {
        this.gameObject.SetActive(true);
        this.SEXmarkButton.SetActive(false);
        SEXmark = 0;
        SEManagerGame.SEXmark = 0;
    }

    public void StartButtonPush()
    {
        audioSource.PlayOneShot(Button2);
        this.gameObject.SetActive(true);
    }
}
