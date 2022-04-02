#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NazioToolKit
{
    [CustomEditor(typeof(MusicManager))]
    public class MusicManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();

            MusicManager _script = (MusicManager)target;

            //Selected music
            GUIContent _musicLabel = new GUIContent("Choose Music to play");

            List<string> _musicNameList = new List<string>();
            foreach (var item in _script.GetMusicsInCurrentPlaylist())
            {
                _musicNameList.Add(item.name);
            }

            _script.selectedMusicID = EditorGUILayout.Popup(_musicLabel, _script.selectedMusicID, _musicNameList.ToArray());

            //Boutons
            if (GUILayout.Button("Play Selected Music"))
            {
                if (!Application.isPlaying) return;
                _script.PlaySelectedMusic();
            }

            if (GUILayout.Button("Random Music"))
            {
                if (!Application.isPlaying) return;
                _script.EditorRandomMusic();
            }

            if (GUILayout.Button("Stop Music"))
            {
                if (!Application.isPlaying) return;
                _script.StopMusic();
            }
        }

    }
}
#endif