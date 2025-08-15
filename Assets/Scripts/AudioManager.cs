using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip startTune;
    public AudioClip pointSound;
    public AudioClip gameOverSound;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayStartTune()
    {
        if (audioSource != null && startTune != null)
        {
            audioSource.clip = startTune;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopStartTune()
    {
        if (audioSource != null && audioSource.clip == startTune && audioSource.isPlaying)
            audioSource.Stop();
    }

    public void PlayPointSound()
    {
        if (audioSource != null && pointSound != null)
            audioSource.PlayOneShot(pointSound);
    }

    public void PlayGameOverSound()
    {
        StopStartTune();
        if (audioSource != null && gameOverSound != null)
            audioSource.PlayOneShot(gameOverSound);
    }
}
