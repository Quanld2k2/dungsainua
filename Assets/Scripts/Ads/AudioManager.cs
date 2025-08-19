using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;

    [Header("------------- Audio Source------------")]
    public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;
    [SerializeField] public AudioSource Click;
    [SerializeField] public AudioSource playMusic1;
    [SerializeField] public AudioSource playMusic2;
    [SerializeField] public AudioSource playMusic3;
    [SerializeField] public AudioSource playMusicGame;
    [Header("------------- Audio Clip------------")]
    public AudioClip click;
    //public AudioClip collect_item;
    public AudioClip lvcomplete;
    public AudioClip background;
    public AudioClip lose;
    public AudioClip chuyencanh, muisgame, dao_dat,chuong, boom;

    //public AudioClip tach;

    [Header("-------------Level 1------------")]
    public AudioClip[] level1;
    [Header("-------------Level 2------------")]
    public AudioClip[] level2;
    [Header("-------------Level 3------------")]
    public AudioClip[] level3;
    [Header("-------------Level 4------------")]
    public AudioClip[] level4;
    [Header("-------------Level 5------------")]
    public AudioClip[] level5;

    [Header("-------------Level 6------------")]
    public AudioClip[] level6;
    [Header("-------------Level 7------------")]
    public AudioClip[] level7;
    [Header("-------------Level 8------------")]
    public AudioClip[] level8;
    [Header("-------------Level 9------------")]
    public AudioClip[] level9;
    [Header("-------------Level 10------------")]
    public AudioClip[] level10;

    [Header("-------------Level 11------------")]
    public AudioClip[] level11;
    [Header("-------------Level 12------------")]
    public AudioClip[] level12;
    [Header("-------------Level 13------------")]
    public AudioClip[] level13;
    [Header("-------------Level 14------------")]
    public AudioClip[] level14;
    [Header("-------------Level 15------------")]
    public AudioClip[] level15;

    [Header("-------------Level 16------------")]
    public AudioClip[] level16;
    [Header("-------------Level 17------------")]
    public AudioClip[] level17;
    [Header("-------------Level 18------------")]
    public AudioClip[] level18;
    [Header("-------------Level 19------------")]
    public AudioClip[] level19;
    [Header("-------------Level 20------------")]
    public AudioClip[] level20;

    [Header("-------------Level 21------------")]
    public AudioClip[] level21;
    [Header("-------------Level 22------------")]
    public AudioClip[] level22;
    [Header("-------------Level 23------------")]
    public AudioClip[] level23;
    [Header("-------------Level 24------------")]
    public AudioClip[] level24;
    [Header("-------------Level 25------------")]
    public AudioClip[] level25;

    [Header("-------------Level 26------------")]
    public AudioClip[] level26;
    [Header("-------------Level 27------------")]
    public AudioClip[] level27;
    [Header("-------------Level 28------------")]
    public AudioClip[] level28;
    [Header("-------------Level 29------------")]
    public AudioClip[] level29;
    [Header("-------------Level 30------------")]
    public AudioClip[] level30;

    private void Awake()
    {
        AudioManager.ins = this;

      //  float aa = PlayerPrefs.GetFloat("musicVolume");
       // if (!PlayerPrefs.HasKey("musicVolume"))
       // {

      //  }
       // else
       // {
       //     AudioListener.volume = aa;
       /// }

    }
    private void Start()
    {
       // AudioManager.ins.play2(AudioManager.ins.level15[0]);
      // plMusic();
    }
    public static void Vibrate(long milliseconds = 250)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        
        if (vibrator != null)
        {
            vibrator.Call("vibrate", milliseconds);
        }
#endif
    }

    public static void Cancel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        
        if (vibrator != null)
        {
            vibrator.Call("cancel");
        }
#endif
    }
    public void plMusic()
    {
        Debug.Log("vplMusic");

        musicSource.clip = background;
        musicSource.Play();
    }
    public void stMusic()
    {
        Debug.Log("stMusic");

        //musicSource.clip = background;
        musicSource.Stop();
    }
    public void playClickshot()
    {
     //   if (clip != null)
     //   {
            Click.PlayOneShot(click);
     //   }
    }
    public void stopClickshot()
    {
      //  if (Click != null && Click.isPlaying)
      //  {
            Click.Stop();
        //  }
    }
    public void playClickshot2()
    {
        //   if (clip != null)
        //   {
        play1shot(chuyencanh);
        //   }
    }
    public void stopClickshot2()
    {
        //  if (Click != null && Click.isPlaying)
        //  {
        //Stop();
        //  }
    }

    //--------------------------------------sfx------------------------------
    private Coroutine currentSFXCoroutine;
    public void PlaySFX(AudioClip clip, Action callback = null)
    {
        Debug.Log("PlaySFXPlaySFXPlaySFX");
        if (SFXSource.isPlaying)
        {
            SFXSource.Stop();
            if (currentSFXCoroutine != null)
            {
                StopCoroutine(currentSFXCoroutine);
            }
        }
        SFXSource.PlayOneShot(clip);
        StartCoroutine(WaitForSoundToEnd(SFXSource, clip, callback));
    }
    public void StopSFX()
    {
        if (SFXSource.isPlaying)
        {
            SFXSource.Stop();
            if (currentSFXCoroutine != null)
            {
                StopCoroutine(currentSFXCoroutine);
            }
        }
    }
    private IEnumerator WaitForSoundToEnd(AudioSource source, AudioClip clip, Action callback)
    {
        yield return new WaitForSeconds(clip.length);
        Debug.Log("Sound finished playing: " + clip.name);
        callback?.Invoke(); // Thực thi hàm callback nếu không null

        // Thực hiện các hành động khác ở đây sau khi âm thanh phát xong
    }
    //----------------------------------------click-----------------------------
    public void play1shot(AudioClip clip)
    {
        if (clip != null)
        {
            playMusic1.PlayOneShot(clip);
        }
    }
    public void stop1shot()
    {
        if (playMusic1 != null && playMusic1.isPlaying)
        {
            playMusic1.Stop();
        }
    }
    public void play2shot(AudioClip clip)
    {
        if (clip != null)
        {
            playMusic2.PlayOneShot(clip);
        }
    }
    public void stop2shot()
    {
        if (playMusic2 != null && playMusic2.isPlaying)
        {
            playMusic2.Stop();
        }
    }
    public void play3shot(AudioClip clip)
    {
        if (clip != null)
        {
            playMusic3.PlayOneShot(clip);
        }
    }
    public void stop3shot()
    {
        if (playMusic3 != null && playMusic3.isPlaying)
        {
            playMusic3.Stop();
        }
    }
    public void playmusicgame(AudioClip clip)
    {
        if (clip != null)
        {
            playMusicGame.clip = clip;
            playMusicGame.volume = 0.6f;
            playMusicGame.loop = true;
            playMusicGame.Play();
        }
    }
    public void stopmusicgame()
    {
        if (playMusicGame != null && playMusicGame.isPlaying)
        {
            playMusicGame.Stop();
        }
    }
}
