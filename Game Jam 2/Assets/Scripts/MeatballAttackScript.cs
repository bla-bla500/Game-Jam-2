using UnityEngine;

public class MeatballAttackScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = -velocity;
    }

    private void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

}
