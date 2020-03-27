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

        if(character.GetComponent<CharacterData>().isDead && !levelOver) {
            character.GetComponent<CharacterMovement>().enabled = false;
            foreach(CharacterAbility ability in character.GetComponents<
                    CharacterAbility>()) {
                if(ability.activated) { ability.Deactivate(); }
                ability.enabled = false;
            }
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            levelOver = true;
        }
    }
}
