using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    void Start()
    {

    }

    public void PlaySfx(AudioClip clip, float volume = 1.0f)
    {
        sfxSource.clip = clip;
        sfxSource.volume = volume;
        sfxSource.Play();
    }

    public void PlayBgm(AudioClip clip, float volume = 1.0f)
    {
        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.Play();
    }
}
