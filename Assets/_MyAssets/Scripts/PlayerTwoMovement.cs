using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public KeyCode moveKey = KeyCode.D;
    public KeyCode moveKey2 = KeyCode.RightArrow;
    public KeyCode moveKey3 = KeyCode.Mouse1;

    MenuController controller;
    Transform lane3;
    Transform lane4;
    float lerpTime = 0.0f;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<MenuController>();
        lane3 = GameObject.Find("Lane3Pos").GetComponent<Transform>();
        lane4 = GameObject.Find("Lane4Pos").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(moveKey) || Input.GetKey(moveKey2) || Input.GetKey(moveKey3))
        {
            lerpTime += 0.5f * Time.deltaTime * speed;
            float midPoint = Mathf.Lerp(lane3.position.x, lane4.position.x, lerpTime);
            transform.position = new Vector3(midPoint, transform.position.y, transform.position.z);
        }
        else
        {
            lerpTime -= 0.5f * Time.deltaTime * speed;
            float midPoint = Mathf.Lerp(lane3.position.x, lane4.position.x, lerpTime);
            transform.position = new Vector3(midPoint, transform.position.y, transform.position.z);
        }

        lerpTime = Mathf.Clamp01(lerpTime);

        // destroy player if game ended
        if(!controller.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            controller.LostGame();
            Destroy(gameObject);
        }
    }
}
