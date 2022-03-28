using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AudioBehaviour : MonoBehaviour
{

    [Header("Audio Things")]
    public AudioSource audio_src1;
    public List<AudioClip> audioClip = new List<AudioClip>();
    public List<string> soundPath = new List<string>();
    public string correctKey;

    private void Awake()
    {
        audio_src1 = gameObject.AddComponent<AudioSource>();
        audio_src1.playOnAwake = false;
        string temp;
        for (int i = 0; i < 3; i++)
        {
            temp = Random.Range(0, 10).ToString();
            soundPath.Add("Sounds/morse-code-" + temp);
            correctKey += temp;
        }
        StartCoroutine(LoadMusic());
    }

    private IEnumerator LoadMusic()
    {
        for (int i = 0; i < 3; i++)
        {
            audioClip.Add(Resources.Load<AudioClip>(soundPath[i]));
            audioClip[i].name = soundPath[i];
        }
        yield return audioClip;
    }

    public void PlaySoundButton1()
    {
        StartCoroutine(PlayMusic(0));
    }

    private IEnumerator PlayMusic(int index)
    {
        while(index < 3) {
            audio_src1.clip = audioClip[index];
            audio_src1.Play();
            index++;
            yield return new WaitForSeconds(audio_src1.clip.length);
        }
        yield break;
    }
}
