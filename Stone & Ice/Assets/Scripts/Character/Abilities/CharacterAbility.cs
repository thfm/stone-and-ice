using UnityEngine;

public abstract class CharacterAbility : MonoBehaviour {
    public KeyCode activateKey;

    [Range(0.5f, 10)] public float effectTime;
    [Range(0, 10)] public float cooldownTime;

    [HideInInspector] public bool activated;
    [HideInInspector] public bool cooledDown;

    private float timeSinceActivation = 0;

    void Start() {
        if(activated) {
            Deactivate();
            activated = false;
        }
        cooledDown = true;
    }

    void Update() {
        if(Input.GetKeyDown(activateKey) && !activated && cooledDown) {
            Activate();
            activated = true;
            cooledDown = false;
            timeSinceActivation = 0;
        }

        timeSinceActivation += Time.deltaTime;
        if(timeSinceActivation >= effectTime && activated) {
            Deactivate();
            activated = false;
        }

        if(timeSinceActivation >= effectTime + cooldownTime) {
            cooledDown = true;
        }
    }

    public abstract void Activate();
    public abstract void Deactivate();
}
