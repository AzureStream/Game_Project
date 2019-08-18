using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKey : MonoBehaviour
{
    public GameObject door;
    public float time;
    float lokalTime;
    bool isOpen = false;
    private void Start()
    {
        lokalTime = time;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            door.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (isOpen)
        {
            lokalTime -= Time.deltaTime;
            if(lokalTime <= 0)
            {
                door.gameObject.SetActive(true);
                lokalTime = time;
                isOpen = false;
            }
        }
    }
}
