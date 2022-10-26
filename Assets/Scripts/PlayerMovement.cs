using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variables
    [SerializeField] Vector3 velocity;
    [SerializeField] float speedCoefficient;
    [SerializeField] float jumpCoefficient;
    private int jumpAmount;
    //end of variables

    //components
    Rigidbody2D rbPlayer;
    //end off componens

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        //transform.position += velocity * speedCoefficient * Time.deltaTime;

        //if (Mathf.Approximately(rbPlayer.velocity.y, 0))
        //{
        //    jumpAmount = 2;
        //}

        //if (Input.GetButtonDown("Jump") && jumpAmount > 0)
        //{
        //    rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 0f);
        //    rbPlayer.AddForce(Vector2.up * jumpCoefficient, ForceMode2D.Impulse);
        //    jumpAmount--;
        //}

        //if (Input.GetAxisRaw("Horizontal") == -1)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //}
        //else if (Input.GetAxisRaw("Horizontal") == 1)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //}
    }

    private void FixedUpdate()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal") * speedCoefficient * Time.fixedDeltaTime, rbPlayer.velocity.y);
        rbPlayer.velocity = velocity;

        if (Mathf.Approximately(rbPlayer.velocity.y, 0))
        {
            jumpAmount = 2;
        }

        if (Input.GetButtonDown("Jump") && jumpAmount > 0)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 0f);
            rbPlayer.AddForce(Vector2.up * jumpCoefficient, ForceMode2D.Impulse);
            jumpAmount--;
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
