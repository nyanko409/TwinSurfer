using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public KeyCode moveKey = KeyCode.A;
    public KeyCode moveKey2 = KeyCode.LeftArrow;
    public KeyCode moveKey3 = KeyCode.Mouse0;

    MenuController controller;
    Transform lane1;
    Transform lane2;
    float lerpTime = 0.0f;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<MenuController>();
        lane1 = GameObject.Find("Lane1Pos").GetComponent<Transform>();
        lane2 = GameObject.Find("Lane2Pos").GetComponent<Transform>();
    }   

    void Update()
    {  
        if(Input.GetKey(moveKey) || Input.GetKey(moveKey2) || Input.GetKey(moveKey3))
        {
            lerpTime += 0.5f * Time.deltaTime * speed;
            float midPoint = Mathf.Lerp(lane2.position.x, lane1.position.x, lerpTime);
            transform.position = new Vector3(midPoint, transform.position.y, transform.position.z);
        }
        else
        {
            lerpTime -= 0.5f * Time.deltaTime * speed;
            float midPoint = Mathf.Lerp(lane2.position.x, lane1.position.x, lerpTime);
            transform.position = new Vector3(midPoint, transform.position.y, transform.position.z);
        }

        lerpTime = Mathf.Clamp01(lerpTime);

        // destroy player if game ended
        if (!controller.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            controller.LostGame();
            Destroy(gameObject);
        }
    }
}
