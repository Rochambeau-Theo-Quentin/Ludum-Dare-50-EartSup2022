using System.Collections.Generic;
using UnityEngine;

namespace NazioToolKit
{
    [System.Serializable]
    public class NMusic
    {
        public string name;

        public AudioClip clip;
        [HideInInspector] public float lenght;

        public List<MusicPlaylist> autorizedPlaylist;

        public void InitClip()
        {
            if (clip == null)//pas de clip
            {
                return;
            }

            lenght = clip.length;
        }
    }
}