using UnityEngine;

public class HomingMeatball : MonoBehaviour
{
    private GameObject bigGuy;
    [SerializeField] private float speed;
    [SerializeField] private float trackingSpeed;
    void Start()
    {
        bigGuy = GameObject.Find("Big guy");
    }

    void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
        float direction = 1;
        if (bigGuy.transform.position.x > transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        transform.position += new Vector3(direction * trackingSpeed, -speed, 0);
    }
}
