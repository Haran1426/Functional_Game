using UnityEngine;

public class BGM_Manager_NA : MonoBehaviour
{
    public static BGM_Manager_NA Instance;

    public AudioSource sfxSource;   // 효과음용
    public AudioSource bgmSource;

    public AudioClip gameBGM;

    public AudioClip countSFX;      // 3,2,1 동안
    public AudioClip startSFX;      // START 후 게임 중

    public AudioClip correctSFX;    // 정답
    public AudioClip wrongSFX;      // 오답

    void Awake()
    {
        Instance = this;
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgmSource.clip == clip) return; // 같은 곡이면 무시

        bgmSource.Stop();
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
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
