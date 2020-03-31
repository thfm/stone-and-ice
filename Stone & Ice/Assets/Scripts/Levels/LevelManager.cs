using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    private AudioSource music;

    void Start() {
        music = GetComponent<AudioSource>();
        music.Play();
    }

    public void StopMusic() {
        music.Pause();
    }

    public IEnumerator FadeMusic(float fadeDuration) {
        float initialVolume = music.volume;
        while(music.volume > 0) {
            music.volume -= initialVolume / fadeDuration * Time.deltaTime;
            yield return null;
        }
        music.Stop();
    }

    public void ResumeMusic() {
        music.UnPause();
    }
}
