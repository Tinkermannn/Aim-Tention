using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamControl : MonoBehaviour
{
    public Transform currentMount;
    public float speedFactor = 0.1f;
    public float zoomFactor = 1.0f;
    public Vector3 lastPosition;
    public Camera cameraComp;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            currentMount.rotation,
            speedFactor
        );

        float velocity = Vector3.Magnitude(transform.position - lastPosition);
        cameraComp.fieldOfView = 60 + velocity * zoomFactor;

        lastPosition = transform.position;
    }

    public void SetMount(Transform newMount)
    {
        currentMount = newMount;
    }
}
