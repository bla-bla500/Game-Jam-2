using System.Collections;
using UnityEngine;

public class Bossscript : MonoBehaviour
{
    public static int bossHealth;
    void Start()
    {
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
            yield return new WaitForSeconds(5);
        }
    }

    private void DoAttack(int whichAttack)
    {
        switch (whichAttack)
        {
            case 1:
                //attack one here
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
            Debug.Log("hit");
        }
    }
}
