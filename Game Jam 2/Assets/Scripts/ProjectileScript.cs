using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string direction;

    private Vector3 movmentDirection;
    private void Start()
    {
        switch (direction)
        {
            case "up":
                movmentDirection = new Vector3(0, 1, 0);
                break;
            case "down":
                movmentDirection = new Vector3(0, -1, 0);
                break;
        }
    }
    void FixedUpdate()
    {
        gameObject.transform.position += (movmentDirection*speed);
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
