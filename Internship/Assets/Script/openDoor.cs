using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Players>().key)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Players>().key = false;
            }
        }
    }
}
