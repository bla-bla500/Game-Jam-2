using System.Collections;
using UnityEngine;

public class Bossscript : MonoBehaviour
{
    public static int bossHealth;
    private Animator animator;
    [SerializeField] private GameObject meatBall;
    void Start()
    {
        animator = GetComponent<Animator>();
        bossHealth = 100;
        StartCoroutine("AttackTimer");
    }

    private void FixedUpdate()
    {
        if (bossHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator AttackTimer()
    {
        while (true)
        {
            int whichAttack = Random.Range(1, 4);
            DoAttack(whichAttack);
            Debug.Log(whichAttack);
            yield return new WaitForSeconds(5);
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
                //attack two here
                break;
            case 3:
                //attack three here
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Projectile")
        {
            bossHealth -= 1;
            Destroy(collision.gameObject);
        }
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

}
