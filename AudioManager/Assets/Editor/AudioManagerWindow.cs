using UnityEditor;
using UnityEngine;
public class AudioManagerWindow : EditorWindow {

    [MenuItem ("Window/AudioManager")]
    public static void ShowWindow () {
        GetWindow<AudioManagerWindow> ();
    }

    void OnGUI () {
        GUILayout.Label ("Drag And Drop AudioClips Here", EditorStyles.boldLabel);
    }
}