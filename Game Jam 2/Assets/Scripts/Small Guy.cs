using UnityEngine;

public class SmallGuy : MonoBehaviour
{
    [SerializeField] Camera cam;
    void LateUpdate()
    {
        Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition));
        gameObject.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);

    }
}
