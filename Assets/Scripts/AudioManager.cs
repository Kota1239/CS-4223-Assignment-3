using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip cardFlip;
    public AudioClip UIClick;
    public AudioClip confetti;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayUIClickSound()
    {
        audioSource.PlayOneShot(UIClick, 1);
    }

    public void PlayCardFlipSound()
    {
        float randomNumber = Random.Range(0.80f, 1.20f);
        UnityEngine.Debug.Log(randomNumber);
        audioSource.pitch = randomNumber;
        audioSource.PlayOneShot(cardFlip, 1);
    }

    public void PlayConfettiSound()
    {
        audioSource.PlayOneShot(confetti, 1);
    }
}
