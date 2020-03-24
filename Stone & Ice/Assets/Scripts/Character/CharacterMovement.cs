using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    [Range(5, 50)] public float forwardsSpeed;
    [Range(0.1f, 1)] public float sidewaysForce;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.AddForce(Input.GetAxis("Horizontal") * sidewaysForce, 0, 0,
            ForceMode.VelocityChange);

        Vector3 velocity = rb.velocity;
        velocity.z = forwardsSpeed;
        rb.velocity = velocity;
    }
}
