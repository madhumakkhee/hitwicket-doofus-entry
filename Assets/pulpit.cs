using UnityEngine;

public class CloneAndDestroy : MonoBehaviour
{
    public GameObject prefabToClone; 
    public float cloneTime = 2.5f; // Time before cloning
    public float minDestroyTime = 4f; // Minimum time to wait
    public float maxDestroyTime = 5f; // Maximum time to wait 
    private BasicMovement basicMovement; 
 
    private float destroyTime;
    private bool isTouched = false; 

    private void Start()
    {
        // Get the BasicMovement script from the Doofus object
        basicMovement = GameObject.Find("Doofus").GetComponent<BasicMovement>();

        destroyTime = Random.Range(minDestroyTime, maxDestroyTime);
        Invoke(nameof(ClonePrefab), cloneTime);
    }

    private void ClonePrefab()
    {
        int randomDirection = Random.Range(0, 4);

        Vector3 direction = Vector3.zero;
        switch (randomDirection)
        {
            case 0: // Up
                direction = Vector3.forward;
                break;
            case 1: // Down
                direction = Vector3.back;
                break;
            case 2: // Left
                direction = Vector3.left;
                break;
            case 3: // Right
                direction = Vector3.right;
                break;
        }

        Instantiate(prefabToClone, transform.position + direction * 9, Quaternion.identity);

        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Doofus") && !isTouched)
        {
            basicMovement.score = basicMovement.score + 1;
            isTouched = true;
        }
    }

}