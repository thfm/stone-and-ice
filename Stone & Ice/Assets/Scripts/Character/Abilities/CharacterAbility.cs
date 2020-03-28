using UnityEngine;

public abstract class CharacterAbility : MonoBehaviour {
    public KeyCode activateKey;

    [Range(0.5f, 10)] public float effectDuration;
    [Range(0, 10)] public float cooldownDuration;

    public enum State {
        Ready,
        Using,
        Cooling
    }

    public State state;

    [HideInInspector] public float timer = 0;

    void Start() {
        state = State.Ready;
    }

    void Update() {
        switch(state) {
            case State.Ready:
                if(Input.GetKeyDown(activateKey)) {
                    Activate();
                    timer = 0;
                    state = State.Using;
                }
                break;
            case State.Using:
                timer += Time.deltaTime;
                if(timer >= effectDuration) {
                    Deactivate();
                    timer = 0;
                    state = State.Cooling;
                }
                break;
            case State.Cooling:
                timer += Time.deltaTime;
                if(timer >= cooldownDuration) {
                    state = State.Ready;
                }
                break;
        }
    }

    public abstract void Activate();
    public abstract void Deactivate();
}
