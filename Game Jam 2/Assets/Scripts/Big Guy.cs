using UnityEngine;

public class BigGuy : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float xLimit = 10f;
    public float yLimit = 5f;

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
}
