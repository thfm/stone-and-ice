using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Range(5, 50)] public float forwardsSpeed;
    [Range(0.1f, 1)] public float sidewaysForce;

    [Range(5f, 50f)] public float rotationSpeed;
    [Range(0.5f, 10f)] public float rotationResetSpeed;

    [HideInInspector] public bool sliding = false;

    private Rigidbody rb;
    private float alignedRotation = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalibrateAlignedRotation();
        if (sliding)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(0, alignedRotation, 0),
                rotationResetSpeed * Time.deltaTime
            );
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * sidewaysForce, 0, 0,
            ForceMode.VelocityChange);

        Vector3 velocity = rb.velocity;
        velocity.z = forwardsSpeed;
        rb.velocity = velocity;
    }

    private void CalibrateAlignedRotation()
    {
        alignedRotation = Mathf.Round(transform.eulerAngles.y / 90) * 90;
    }
}
