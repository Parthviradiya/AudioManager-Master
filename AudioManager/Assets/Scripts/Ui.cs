using UnityEngine;
using UnityEngine.UI;
public class Ui : MonoBehaviour {
    public void OnSfxButton () {
        AudioManager.Instance.PlayAudio (SourceType.Sfx, AudioType.happy);
    }
    public void OnBackgroundButton () {
        AudioManager.Instance.PlayAudio (SourceType.Background, AudioType.Background);
    }
    public void OnLoopButton () {
        AudioManager.Instance.PlayAudio (SourceType.Loop, AudioType.eat);
    }
    public void OnMute () {
        AudioManager.Instance.Mute ();
    }
    public void OnUnMute () {
        AudioManager.Instance.UnMute ();
    }
}