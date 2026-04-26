using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the mouse inputs.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation around the x axis (look up and down)
        xRotation -= mouseY;

        // Clamp the rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rotation around the Y axis (look up and down)
        yRotation += mouseX;

        // Apply the rotation to our transform.
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
