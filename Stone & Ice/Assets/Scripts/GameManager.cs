using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject character;

    public SceneLoader sceneLoader;
    public float restartDelay;

    private bool levelOver = false;

    void Update() {
        if(character.transform.position.y < -1) {
            character.GetComponent<CharacterData>().isDead = true;
        }

        if(character.GetComponent<CharacterData>().isDead) {
            character.GetComponent<CharacterMovement>().enabled = false;
            RestartLevel();
        }
    }

    private void RestartLevel() {
        if(!levelOver) {
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            levelOver = true;
        }
    }
}
