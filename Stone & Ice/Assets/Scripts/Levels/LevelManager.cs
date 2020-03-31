using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Transform character;

    [HideInInspector] public float progress;

    private LevelData levelData;
    private AudioSource music;

    void Start() {
        levelData = GetComponent<LevelData>();
        music = GetComponent<AudioSource>();
        music.Play();
    }

    void Update() {
        progress = Mathf.Clamp01(character.position.z / levelData.endPoint);
        if(progress >= 1) {
            FindObjectOfType<GameManager>().ReturnToMenu();
        }
    }

    public void StopMusic() {
        music.Stop();
    }

    public IEnumerator FadeMusic(float fadeDuration) {
        float initialVolume = music.volume;
        while(music.volume > 0) {
            music.volume -= initialVolume / fadeDuration * Time.deltaTime;
            yield return null;
        }
        music.Stop();
    }
}
