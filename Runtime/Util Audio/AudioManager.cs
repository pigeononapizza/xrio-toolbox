using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Pillow.Audio
{
    public enum AudioChannel { Master, Environment, Music, Sfx, Narrator };
    public static class AudioManager
    {
        public static GameObject PlayClipAtPoint
        (AudioClip clip, Vector3 position, float volume = 1.0f, AudioMixerGroup group = null, string customGOname = null)
        {
            if (clip == null) return null;
            if (customGOname == null) customGOname = clip.name;


            GameObject gameObject = new GameObject(customGOname);
            gameObject.transform.position = position;
            AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            if (group != null)
                audioSource.outputAudioMixerGroup = group;
            audioSource.clip = clip;
            audioSource.spatialBlend = 1f;
            audioSource.volume = volume;
            audioSource.Play();
            Object.Destroy(gameObject, clip.length *
            (Time.timeScale < 0.009999999776482582 ? 0.01f : Time.timeScale));
            return gameObject;
        }
    }
}
