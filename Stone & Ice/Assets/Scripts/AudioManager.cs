using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource music;

    void Start() {
        music = GetComponent<AudioSource>();
    }

    public IEnumerator FadeOutMusic(float duration) {
        float initialVolume = music.volume;
        while(music.volume > 0) {
            music.volume -= initialVolume / duration * Time.deltaTime;
            yield return null;
        }
        music.Stop();
    }
}
