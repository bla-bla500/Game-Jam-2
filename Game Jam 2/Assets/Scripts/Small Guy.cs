using System.Collections;
using UnityEngine;

public class SmallGuy : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Shoot");
        }   
    }
    void LateUpdate()
    {
        gameObject.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
    }
    
    public IEnumerator Shoot()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("here");
            Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
