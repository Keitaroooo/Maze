using UnityEngine;
using UnityEngine.SceneManagement;

public class SEManagerClear : MonoBehaviour
{

    public AudioClip Goal1;
    public AudioClip Home1;

    GameObject SEManagerHomePrefab;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if (SEManagerGame.SEXmark != 1 && SEManagerHome.SEXmark != 1)
        {
            audioSource.PlayOneShot(Goal1);
        }
        
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HomePush1()
    {
        if (SEManagerGame.SEXmark != 1 && SEManagerHome.SEXmark != 1)
        {
            audioSource.PlayOneShot(Home1);
        }
    }

}