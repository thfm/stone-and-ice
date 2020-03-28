using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour {
    public CharacterAbility ability;

    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        switch(ability.state) {
            case CharacterAbility.State.Ready:
                slider.value = 1;
                break;
            case CharacterAbility.State.Using:
                slider.value = 1 - (ability.timer / ability.effectDuration);
                break;
            case CharacterAbility.State.Cooling:
                slider.value = ability.timer / ability.cooldownDuration;
                break;
        }
    }
}
