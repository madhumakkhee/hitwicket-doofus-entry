using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public int score = 0;
    public TMP_Text scoreText; // Assign this in the inspector


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get the camera's forward direction
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // ignore vertical component
        cameraForward = cameraForward.normalized;

        // Calculate movement direction based on camera direction and input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = cameraForward * movement.z + Camera.main.transform.right * movement.x;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        scoreText.text = "Score: " + score.ToString();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}