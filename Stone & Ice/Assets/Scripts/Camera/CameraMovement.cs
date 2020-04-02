using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [Range(1, 10)] public float speed;
    public Vector3 focusOffset;

    public Transform mainMenu;

    private Vector3 targetPosition;

    void Start() {
        FocusOn(mainMenu);
    }

    void Update() {
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * speed
        );
    }

    public void FocusOn(Transform objectTransform) {
        targetPosition = objectTransform.position + focusOffset;
    }
}
