using UnityEngine;

public class CameraLook : MonoBehaviour {
    [Range(1, 10)] public float turnSpeed;

    private float targetRotation = 0;

    void Update() {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.Euler(0, targetRotation, 0),
            Time.deltaTime * turnSpeed
        );
    }

    public void LookLeft() {
        targetRotation = -90;
    }

    public void LookToCentre() {
        targetRotation = 0;
    }

    public void LookRight() {
        targetRotation = 90;
    }
}
