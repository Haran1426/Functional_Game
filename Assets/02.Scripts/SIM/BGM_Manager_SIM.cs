using UnityEngine;

public class BGM_Manager_SIM : MonoBehaviour
{
    public static BGM_Manager_SIM Instance;

    public AudioSource sfxSource;   // 효과음용

    public AudioClip countSFX;      // 3,2,1 동안
    public AudioClip startSFX;      // START 후 게임 중

    public AudioClip correctSFX;    // 정답
    public AudioClip wrongSFX;      // 오답

    void Awake()
    {
        Instance = this;
    }

    public void Count321SFX()
    {
        sfxSource.PlayOneShot(countSFX);
    }

    public void PlayStartSFX()
    {
        sfxSource.PlayOneShot(startSFX);
    }

    public void PlayCorrectSFX()
    {
        sfxSource.PlayOneShot(correctSFX);
    }

    public void PlayWrongSFX()
    {
        sfxSource.PlayOneShot(wrongSFX);
    }

}
