using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidbody2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2.velocity = movement * speed;

    }
}
