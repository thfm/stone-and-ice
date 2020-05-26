using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public RawImage blackFade;

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAfterFade(name));
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoadSceneAfterFade(string name)
    {
        blackFade.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitUntil(() => blackFade.color.a == 1);
        SceneManager.LoadScene(name);
    }
}
