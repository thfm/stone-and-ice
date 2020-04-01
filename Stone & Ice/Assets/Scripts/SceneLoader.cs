using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
    public RawImage blackFade;

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void ReloadCurrentScene() {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator FadeToScene(string name) {
        blackFade.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitUntil(() => blackFade.color.a == 1);
        LoadScene(name);
    }

    public void ButtonFadeWrapper(string name) {
        StartCoroutine(FadeToScene(name));
    }
}
