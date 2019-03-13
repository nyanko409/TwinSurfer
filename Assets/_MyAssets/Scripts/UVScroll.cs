using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll : MonoBehaviour
{
    public float speed = 5f;

    Material _material;
    float currentscroll;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentscroll += speed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(0, currentscroll);
    }
}
