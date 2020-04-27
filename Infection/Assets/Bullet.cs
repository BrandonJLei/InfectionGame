using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Person person = collision.gameObject.GetComponent<Person>();
        if (person != null && person.sprite.color == Color.red)
        {
            person.changeColor();
        }
        Destroy(gameObject);
    }
}
