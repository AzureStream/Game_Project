using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        Destroy(door);
        Destroy(gameObject);
    }
}
