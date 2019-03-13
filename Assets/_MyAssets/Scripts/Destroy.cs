using UnityEngine;

public class Destroy : MonoBehaviour
{
    public string tag = "";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == tag)
        {
            Destroy(collision.gameObject);
        }
    }
}
