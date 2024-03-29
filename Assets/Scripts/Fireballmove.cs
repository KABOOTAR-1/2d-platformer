using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballmove : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float Fireforce;
    bool face;
    Vector3 Scaler;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        face = Tags.facingRight;
        Scaler = transform.localScale;
        Invoke("delete", 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (face)
        {
            rigidbody.velocity = new Vector2(Fireforce, rigidbody.velocity.y);
            Vector3 Sc = transform.localScale;
            Sc.x = Scaler.x;
            transform.localScale = Sc;
        }
        else
        {
            rigidbody.velocity = new Vector2(Fireforce * -1, rigidbody.velocity.y);
            Vector3 Sc = transform.localScale;
            Sc.x = -Scaler.x;
            transform.localScale = Sc;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag!="Fireball")
            Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Tags.score++;
        }

    }

    private void delete()
    {
        Destroy(gameObject);
    }
}


