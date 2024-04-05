using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---- Audio Source ----")]
    [SerializeField]
    private AudioSource _musicsource;
    [SerializeField]
    private AudioSource _sfxsource;

    [Header("---- Audio Clip ----")]
    public AudioClip Background;
    public AudioClip JumpSound;
    public AudioClip ExlposionAudio;
    public AudioClip ExplosionAudioEnemy;

    private void Start()
    {
        _musicsource.clip = Background;
        _musicsource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxsource.PlayOneShot(clip);
    }
}
