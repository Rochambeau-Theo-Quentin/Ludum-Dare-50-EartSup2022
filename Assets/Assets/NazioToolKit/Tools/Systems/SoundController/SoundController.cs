using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NazioToolKit
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundController : MonoBehaviour
    {
        [System.Serializable]
        public class NSound
        {
            public string code;
            public AudioClip clip;
        }

        [SerializeField] private NSound[] sounds;

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        public void PlaySound(string _soundCode)
        {
            foreach (var item in sounds)
            {
                if (item.code == _soundCode) source.PlayOneShot(item.clip);
            }
        }

        public void StopSound()
        {
            source.Stop();
        }
    }

}