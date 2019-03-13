using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public static float speed = 5.0f;

    MenuController controller;


    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<MenuController>();
    }

    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
        //speed += Time.deltaTime / 5;

        // destroy if game ends
        if(!controller.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
