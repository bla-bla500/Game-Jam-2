using UnityEngine;

public class BigGuy : MonoBehaviour
{
    public float moveSpeed;

    public float xLimit;
    public float yLimit;


    void Update()
    {
        MovePlayer();
        KeepPlayerInBounds();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void KeepPlayerInBounds()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, -xLimit, xLimit);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -yLimit, yLimit);

        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ran1");
        if (collision.gameObject.tag == "Boss Projectile")
        {
            Debug.Log("Ran2");
            GameObject.Find("Canvas").GetComponent<UIManager>().Lose();
        }
    }
}
