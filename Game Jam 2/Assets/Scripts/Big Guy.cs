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

    public void StopTime()
    {
        //Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss Projectile")
        {
            gameObject.GetComponent<Animator>().SetBool("Dead",true);
            GameObject.Find("Canvas").GetComponent<UIManager>().Lose();
        }
    }
}
