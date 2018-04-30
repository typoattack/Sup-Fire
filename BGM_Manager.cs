using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour {


    public int sceneCount = 0;
    private int whichIsPlaying = 0;

    public static class AudioFadeOut
    {

        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.mute = true;
        }

    }

    public static class AudioFadeIn
    {

        public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
        {
            audioSource.volume = 0f;

            while (audioSource.volume < 1)
            {
                audioSource.volume += Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.mute = false;
        }

    }
    void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("bgm");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    void Start() {
        gameObject.SetActive(true);
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<AudioSource>().mute = true;
        }
        gameObject.transform.GetChild(sceneCount).GetComponent<AudioSource>().Play();
        gameObject.transform.GetChild(sceneCount).GetComponent<AudioSource>().mute = false;
    }

    void SetLevel(int sceneCount)
    {
        this.sceneCount = sceneCount;

    }

    void FixedUpdate () {
		for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (sceneCount != whichIsPlaying)
            {
                StartCoroutine(AudioFadeOut.FadeOut(gameObject.transform.GetChild(whichIsPlaying).GetComponent<AudioSource>(), 0.8f));
                whichIsPlaying = sceneCount;

                if (!gameObject.transform.GetChild(sceneCount).GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.transform.GetChild(whichIsPlaying).GetComponent<AudioSource>().Play();
                }

                StartCoroutine(AudioFadeIn.FadeIn(gameObject.transform.GetChild(whichIsPlaying).GetComponent<AudioSource>(), 0.5f));
                //gameObject.transform.GetChild(whichIsPlaying).GetComponent<AudioSource>().mute = false;
                //gameObject.transform.GetChild(whichIsPlaying).GetComponent<AudioSource>().volume = 1f;

            }
        }
	}
}
