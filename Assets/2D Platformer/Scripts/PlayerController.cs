using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        public float moveInput;

        
        [HideInInspector]
        public bool deathState = false;
        public Transform firemark;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;
        public bool check;
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

            check = Tags.facingRight;
            moveInput = Input.GetAxis("Horizontal");
            if (Input.GetButton("Horizontal") ) 
            {
                
                rigidbody.velocity= new Vector2(moveInput*movingSpeed,rigidbody.velocity.y);
                animator.SetInteger("Trigger", 1);
            }
            else
            {
                if (isGrounded)
                {
                    animator.SetInteger("Trigger", 0);
                    float x = 0.5f;
                    x = Mathf.MoveTowards(x, 0, 0.5f);
                    rigidbody.velocity = new Vector2(0,rigidbody.velocity.y);
                }
            }
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            if (!isGrounded) { animator.SetInteger("Trigger", 2);
               
            } // Turn on jump animation

            if(Tags.facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(Tags.facingRight == true && moveInput < 0)
            {
                Flip();
            }

            if(transform.position.y<-4f)
                Invoke("ReloadLevel", 3);

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
                deathState = true;
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);// Say to GameManager that player is dead
              
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

        private void ReloadLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
