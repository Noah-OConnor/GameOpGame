using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private float movementSpeed;
    private Vector2 movementVector;
    private bool contact = false;

    private void Start()
    {
        movementVector = Vector2.zero;
    }
    private void Update()
    {
        movementVector.y = -movementSpeed * Time.deltaTime;
        transform.Translate(movementVector);

        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }

        if (contact && !GameManager.instance.GetInvincible())
        {
            GameManager.instance.DamagePlayer();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!GameManager.instance.GetInvincible())
            {
                GameManager.instance.DamagePlayer();
                Destroy(gameObject);
            }
            else
            {
                contact = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contact = false;
        }
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
}