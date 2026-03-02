using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bossscript : MonoBehaviour
{
    public static int bossHealth;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polyCollider;
    private AudioSource audio1;
    private AudioSource audio2;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject meatBall;
    [SerializeField] private GameObject homingMeatBall;
    void Start()
    {
        animator = GetComponent<Animator>();
        polyCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio1 = GetComponents<AudioSource>()[0];
        audio2 = GetComponents<AudioSource>()[1];
        bossHealth = 1000;
        StartCoroutine("AttackTimer");
    }

    private void FixedUpdate()
    {
        if (bossHealth == 0)
        {
            GameObject.Find("Canvas").GetComponent<UIManager>().Win();
            animator.SetBool("Dead", true);
        }
    }

    private IEnumerator Damage()
    {
        spriteRenderer.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    private IEnumerator AttackTimer()
    {
        while (true)
        {
            int whichAttack = Random.Range(1, 4);
            DoAttack(whichAttack);
            yield return new WaitForSeconds(Random.Range(1,5));
        }
    }

    int i = 0;
    public void UpdateColider()
    {
        polyCollider.CreateFromSprite(sprites[i]);
        i++;
        if (i == 8)
        {
            i = 0;
        }
    }
    private void DoAttack(int whichAttack)
    {
        switch (whichAttack)
        {
            case 1:
                animator.SetInteger("whichAnimation", 1);
                break;
            case 2:
                animator.SetInteger("whichAnimation", 2);
                break;
            case 3:
                animator.SetInteger("whichAnimation", 3);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Projectile")
        {
            bossHealth -= 1;
            Destroy(collision.gameObject);
            StartCoroutine("Damage");
        }
    }

    private void PlayAudio1()
    {
        audio1.Play();
    }

    private void PlayAudio2()
    {
        audio2.Play();
    }

    public void SpawnMeatballs()
    {
        Vector3 basePosition;
        basePosition = transform.position - new Vector3(0,2,0);
        Instantiate(meatBall, basePosition, transform.rotation);
        float modifier = 0;
        for(int i = 0; i < 5; i++)
        {
            modifier += 1.5f;
            Instantiate(meatBall, basePosition - new Vector3(modifier, 0, 0), transform.rotation);
        }
        modifier = 0;
        for (int i = 0; i < 5; i++)
        {
            modifier -= 1.5f;
            Instantiate(meatBall, basePosition - new Vector3(modifier, 0, 0), transform.rotation);
        }
    }

    public void SpawnHomingMeatball()
    {
        Vector3 basePosition;
        basePosition = transform.position - new Vector3(0, 2, 0);
        Instantiate(homingMeatBall, basePosition + new Vector3(Random.Range(-10f,10f),0,0), transform.rotation);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
