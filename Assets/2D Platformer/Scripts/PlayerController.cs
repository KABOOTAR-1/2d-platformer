using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

        
        [HideInInspector]
        public bool deathState = false;
        public Transform firemark;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;
        //private GameManager gameManager;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
           // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            if (Input.GetButton("Horizontal") ) 
            {
                moveInput = Input.GetAxis("Horizontal");
                rigidbody.velocity= new Vector2(moveInput*movingSpeed,rigidbody.velocity.y);
            }
            else
            {
                if (isGrounded)
                {
                    animator.SetInteger("Trigger", 0);
                    float x = 0.5f;
                    x = Mathf.MoveTowards(x, 0, 0.5f);
                    rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                }
            }
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            if (!isGrounded) { animator.SetInteger("Trigger", 2);
                rigidbody.AddForce(-transform.up * jumpForce/2000, ForceMode2D.Impulse);
            } // Turn on jump animation

            if(Tags.facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(Tags.facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            Tags.facingRight = !Tags.facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else
            {
                deathState = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
              //  gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
            }
        }
    }
}
