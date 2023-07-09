using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Pillow.Audio;

[HelpURL("https://answers.unity.com/questions/975754/how-to-route-sound-from-playclipatpoint-to-a-speci.html")]
public class PlayClipAtPoint : MonoBehaviour
{
    public AudioClip SampleClip;
    public float Volume = 1f;
    public KeyCode TriggerButton;
    public AudioMixerGroup audioMixerGroup;
    public AudioChannel audioChannel;

    void Start()
    {
        Volume = audioMixerGroup.audioMixer.GetFloat(audioChannel.ToString(), out float value) ? value : 0f;
        AudioSource.PlayClipAtPoint(SampleClip, transform.position, Volume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(TriggerButton))
        {
            PlayClip();
        }
    }

    public void PlayClip()
    {
        Volume = audioMixerGroup.audioMixer.GetFloat(audioChannel.ToString(), out float value) ? value : 0f;
        // Debug.Log("Volume: " + Volume);
        GameObject audioOuput = AudioManager.PlayClipAtPoint(SampleClip, transform.position, Volume, audioMixerGroup);
    }
}
