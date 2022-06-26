
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator; 

    void update()
    {
        transform.Translate(Vector2.left * obstacleGenerator.CurrentSpeed * Time.deltaTime); 
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextline"))
        {
            obstacleGenerator.generateObstacle();
        }
    }
}
