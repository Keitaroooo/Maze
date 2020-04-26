using UnityEngine;
using UnityEngine.SceneManagement;

public class SEManagerGameOver : MonoBehaviour
{

    public AudioClip GameOver1;
    public AudioClip Home1;

    GameObject SEManagerHomePrefab;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if (SEManagerGame.SEXmark == 0 && SEManagerHome.SEXmark == 0)
        {
            audioSource.PlayOneShot(GameOver1);
        }
        
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HomePush1()
    {
        if (SEManagerGame.SEXmark == 0 && SEManagerHome.SEXmark == 0)
        {
            audioSource.PlayOneShot(Home1);
        }
    }

}