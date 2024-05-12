using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton
{
    public enum SFX
    {
        A,
        BeFine,
        Challenge,
        ChallengeFail,
        ChallengeSuccess,
        DiceRoll,
        GodDamn,
        GoodBye,
        Hello,
        Hmm,
        HolyMoly,
        Huk,
        JustLucky,
        JustPractice,
        Laugh,
        MosiMosi,
        NotBad,
        Oi,
        OMG,
        OMG1,
        Scream,
        Scream1,
        TikTik,
        WazzUp,
        WazzUp1,
        WitnessMe
    }

    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip bgmClip;
    public AudioClip[] sfxClip;

    SFX[] baelzGreetingSFX = new SFX[] { SFX.WazzUp, SFX.WazzUp1, SFX.WitnessMe, SFX.Hello, SFX.MosiMosi };
    SFX[] baelzLoseSFX = new SFX[] { SFX.GodDamn, SFX.Oi, SFX.OMG, SFX.OMG1, SFX.Scream, SFX.Scream1 };
    SFX[] meLoseSFX = new SFX[] { SFX.A, SFX.Huk, SFX.HolyMoly, SFX.Laugh, SFX.TikTik };
    SFX[] gameOverSFX = new SFX[] { SFX.GoodBye, SFX.Huk, SFX.Laugh, SFX.NotBad, SFX.TikTik };
    SFX[] gameEndSFX = new SFX[] { SFX.BeFine, SFX.JustLucky, SFX.JustPractice };

    private void Awake()
    {
        if (audioManager == null)
            audioManager = this;
        else
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (audioManager == this)
            audioManager = null;
    }

    public void PlaySFX(SFX sfx)
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)sfx];
        sfxAudioSource.Play();
    }

    public void PlayGreeting()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int) baelzGreetingSFX[Random.Range(0, baelzGreetingSFX.Length)]];
        sfxAudioSource.Play();
    }

    public void PlayBaelzLose()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)baelzLoseSFX[Random.Range(0, baelzLoseSFX.Length)]];
        sfxAudioSource.Play();
    }

    public void PlayMeLose()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)meLoseSFX[Random.Range(0, meLoseSFX.Length)]];
        sfxAudioSource.Play();
    }

    public void PlayGameOver()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)gameOverSFX[Random.Range(0, gameOverSFX.Length)]];
        sfxAudioSource.Play();
    }
    
    public void PlayGameEnd(int num)
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)gameEndSFX[num]];
        sfxAudioSource.Play();
    }

    public void PlayChallengeSuccess()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)SFX.ChallengeSuccess];
        sfxAudioSource.Play();
    }

    public void PlayChallengeFailed()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)SFX.ChallengeFail];
        sfxAudioSource.Play();
    }
}
