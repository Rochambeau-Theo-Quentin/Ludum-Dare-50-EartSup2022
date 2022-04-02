using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NazioToolKit
{
    public enum MusicPlaylist//Create your Playlists
    {
        All,
        Menu,
    }

    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        private static MusicManager instance;

        private int musicID = 0;
        [HideInInspector] public int selectedMusicID = 0;
        [SerializeField] private NMusic[] musics;
        private List<NMusic> playlistMusics = new List<NMusic>();

        [SerializeField, InspectorName("Current Playlist")] private MusicPlaylist curPlayList = new MusicPlaylist();

        //Refs
        private AudioSource source;

        #region UnityMethods

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                Debug.LogError("Another Music Manager has been founded and deleted");
                return;
            }
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            source = GetComponent<AudioSource>();

            UpdatePlaylist();
        }

        private void OnValidate()
        {
            if(musics == null) return;
            
            foreach (var clip in musics)
            {
                clip.InitClip();
            }

            UpdatePlaylist();

#if UNITY_EDITOR
            EditorApplication.update();
#endif
        }

        private void Start()
        {
            EditorRandomMusic();
        }

        #endregion

        #region GetMethods

        public List<NMusic> GetMusicsInCurrentPlaylist()
        {
            return playlistMusics;
        }

        #endregion

        public void ChangePlaylist(MusicPlaylist _list)//Change la playlist
        {
            curPlayList = _list;
            UpdatePlaylist();
        }

        public void EditorRandomMusic()//Change avec le bouton editor
        {
            RandomizeMusicID();
            UpdatePlaylist();
            StopMusic();
            LaunchMusic();
        }

        public void NewRandomMusic()
        {
            RandomizeMusicID();
            StopMusic();
            LaunchMusic();
        }

        public void PlaySelectedMusic()
        {
            musicID = selectedMusicID;
            StopMusic();
            LaunchMusic();
        }

        public void StopMusic()
        {
            StopAllCoroutines();
            source.clip = null;
            source.Stop();
        }

        private void UpdatePlaylist()
        {
            playlistMusics = new List<NMusic>();

            foreach (var _music in musics)
            {
                bool _isIn = false;
                foreach (var _playList in _music.autorizedPlaylist)
                {
                    if (_playList == curPlayList) _isIn = true;
                }

                if (_isIn) playlistMusics.Add(_music);
            }
        }

        private void RandomizeMusicID()
        {
            print(playlistMusics.Count);

            int newID = musicID;
            while (newID == musicID)
            {
                if (playlistMusics.Count == 0)//pas de musique
                {
                    Debug.LogError("No music in this playlist");
                    return;
                }

                if (playlistMusics.Count == 1)//eviter boucle infinie
                {
                    newID = 0;
                    break;
                }

                //peut switch
                newID = (int)Random.Range(0, playlistMusics.Count);
            }

            musicID = newID;
        }

        private void LaunchMusic()
        {
            StopAllCoroutines();
            StartCoroutine(PlayNewMusic(musicID));
        }

        private IEnumerator PlayNewMusic(int _musicId)
        {
            Debug.Log("Play music : " + playlistMusics[_musicId].name);
            source.PlayOneShot(playlistMusics[_musicId].clip);
            yield return new WaitForSeconds((int)playlistMusics[_musicId].lenght);
            NewRandomMusic();
        }
    }
}