using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject opsText;

    public float health = 100;
    public float speed = 25;

    public Transform remover;
    public Transform mag;

    private Rigidbody rb;
    float offset = 2.5f;

    bool useRemover = false;
    bool useMag = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space"))
        {
            rb.AddForce(0, 0.5f, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("r"))
        {
            transform.position = new Vector3(50.14f, 25.78f, 0.06f);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (Input.GetKeyDown("1"))
        {
            if (useMag == true)
            {
                useRemover = false;
                useMag = false;
                mag.position = new Vector3(60.25707f, 26.1f, 4.973085f);
            }
            else
            {
                useRemover = false;
                useMag = true;
            }
        }

        if (Input.GetKeyDown("2"))
        {
            if (useRemover == true)
            {
                useRemover = false;
                useMag = false;
                remover.position = new Vector3(60.14f, 25.32f, -7.6f);
            }
            else
            {
                useRemover = true;
                useMag = false;
            }
        }

        if (useRemover == true)
        {
            remover.position = transform.position + new Vector3(0, offset, 0);
        }
        if (useMag == true)
        {
            mag.position = transform.position + new Vector3(0, 0, 0);
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tax")
        {
            if ((useRemover == false) && (useMag == false))
            {
                transform.position = new Vector3(50.14f, 25.78f, 0.06f);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (useRemover == true)
            {
                Destroy(collision.gameObject);
            }

        }

        if (collision.gameObject.tag == "Key")
        {
            if (useRemover == true)
            {
                Destroy(collision.gameObject);
                opsText.transform.position = new Vector3(-25.03f, 63.7f, -35.63f);
            }
        }

    }
}
