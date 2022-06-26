
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;
    void Start()
    {
        
    }

    void Awake()
    {
        CurrentSpeed = MinSpeed;
        generateObstacle();
    }

    public void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(obstacle, transform.position, transform.rotation);

        ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
