using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public static int redCount = 10;
    public Transform player;
    public float moveSpeed = 3f;
    public float accelerationTime = 2f;
    public string startColor = "Blue";

    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Vector2 blueMovement;
    private float timeLeft;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if(startColor == "Blue")
            sprite.color = Color.blue;
        else if (startColor == "Red")
            sprite.color = Color.red;


        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (sprite.color == Color.red)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                blueMovement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                timeLeft += accelerationTime;
            }
        }
    }
    void FixedUpdate()
    {
        if(sprite.color == Color.blue)
            wander();
    }
    
    void wander()
    {
        rb.AddForce(blueMovement * moveSpeed);
    }
    public void changeColor()
    {
        if(sprite.color == Color.red)
        {
            sprite.color = Color.blue;
            redCount--;
        }
        else if(sprite.color == Color.blue)
        {
            sprite.color = Color.red;
            redCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Person person = collision.gameObject.GetComponent<Person>();
        PlayerMovement doctor = collision.gameObject.GetComponent<PlayerMovement>();
        if (person != null && sprite.color == Color.red && person.sprite.color == Color.blue)
        {
            person.changeColor();
            redCount ++;
        }
        if(doctor != null && sprite.color == Color.red)
        {
            doctor.takeDamage();
            Destroy(gameObject);
            redCount--;
        }
    }
}
