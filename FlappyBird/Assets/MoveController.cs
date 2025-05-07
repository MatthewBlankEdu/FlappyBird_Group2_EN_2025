using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;
    public float spawnPointX;
    public float despawnPointX;

    public bool shouldRandomizeY;
    public float minY;
    public float maxY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (shouldRandomizeY)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.hasStarted == false || BirdController.gameOver == true)
        {
            return;
        }
        
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, 
            transform.position.y, transform.position.z);

        if (transform.position.x <= despawnPointX)
        {
            transform.position = new Vector3(spawnPointX, transform.position.y, transform.position.z);

            if (shouldRandomizeY)
            {
                transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
            }
        }
    }
}