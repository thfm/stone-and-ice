using UnityEngine;

public class SlowMotionAbility : CharacterAbility {
    [Range(0.01f, 1)] public float slowMotionFactor;

    public override void Activate() {
        Time.timeScale = slowMotionFactor;
        RecalibrateFixedDeltaTime();
    }

    public override void Deactivate() {
        Time.timeScale = 1;
        RecalibrateFixedDeltaTime();
    }

    private void RecalibrateFixedDeltaTime() {
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
