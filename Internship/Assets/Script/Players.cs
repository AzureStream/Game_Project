using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    public float speed = 10f;
    public bool key;
    private Rigidbody2D rigidbody2;

    public Image[] heart;
    public int maxHealth = 3;
    private int health;


    private bool iniFrame;
    private float timeIni = 1;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        iniFrame = false;
        key = false;
        /*if (PlayerPrefs.HasKey("health"))
            Loaded();
        else*/
            health = maxHealth;
        SetHealth(health);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //float moveHorizontal = Input.acceleration.x;
        //float moveVertical = Input.acceleration.y;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2.velocity = movement * speed;

    }

    private void Update()
    {
        if (iniFrame)
        {
            timeIni -= Time.deltaTime;
            int tmp = Random.Range(0, 100);
            if (tmp > 50) sr.enabled = true; else sr.enabled = false;
            if(timeIni <= 0)
            {
                sr.enabled = true;
                iniFrame = false;
                timeIni = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") && !iniFrame)
            DelHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key") && !key)
        {
            key = true;
            Destroy(collision.gameObject);
        }
    }

    void SetHealth(int max)
    {
        for (int i = 0; i < max; i++)
            heart[i].gameObject.SetActive(true);
    }

    void AddHealth()
    {
        if (health < maxHealth)
            heart[health++].gameObject.SetActive(true);
    }

    void DelHealth()
    {
        if(health > 0)
        {
            heart[--health].gameObject.SetActive(false);
        }
        if(health == 0)
        {
            Destroy(gameObject);
        }
        iniFrame = true;
    }

    public void Save() => PlayerPrefs.SetInt("health", health);

    void Loaded() => health = PlayerPrefs.GetInt("health");
}
