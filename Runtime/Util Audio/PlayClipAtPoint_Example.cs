using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace XRIO.Toolbox
{

    public class PlayClipAtPoint_Example : MonoBehaviour
    {
        public AudioClip SampleClip;
        public float Volume = 1f;
        public KeyCode TriggerButton;
        public AudioMixer audioMixer;
        public AudioMixerGroup audioOutput;

        void Start()
        {
            AudioSource.PlayClipAtPoint(SampleClip, transform.position, Volume);
        }

        private void Update()
        {
            if (Input.GetKeyDown(TriggerButton))
            {
                AudioSource.PlayClipAtPoint(SampleClip, transform.position, Volume);
            }
        }

        public void PlayClipAtPoint()
        {

            // GameObject audioPut = .PlayClipAtPoint(SampleClip, transform.position, Volume, audioOutput);

        }

    }
}
