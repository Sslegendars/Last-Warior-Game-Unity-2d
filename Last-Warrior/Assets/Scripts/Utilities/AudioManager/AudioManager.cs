using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public const string themeSoundName = "Theme";
    public const string graveSoundName = "Grave";
    // PlayerSoundName
    public const string playerJumpSoundName = "Jump";
    public const string playerAttackSoundName = "PlayerAttack";
    public const string playerHurtSoundName = "PlayerHurt";
    public const string playerDashSoundName = "Dash";
    public const string playerHealSoundName = "PlayerHeal";
    public const string playerFireParticleSoundName = "FireParticle";
    // Item sound name
    public const string coinCollectSoundName = "CoinCollect";
    public const string bombCountDownSoundName = "BombCountDown";
    public const string bombExplosionSoundName = "BombExplosion";
    public const string spentCoinSoundName = "SpentMoney";
    public const string notEnoughCoinSoundName = "NotEnoughMoney";
    // Game Manager Sound
    public const string gameOverSoundName = "GameOver";
    public const string winSoundName = "YouWin";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.Play();
        }
    }

    private void Start()
    {
        StopAllSounds();
        Play(themeSoundName);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

}
