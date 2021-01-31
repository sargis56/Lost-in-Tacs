using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : MonoBehaviour
{

    public GameObject winText;

    public GameObject remover;
    public GameObject magnet;

    public Transform key;
    public bool getKey = false;

     bool usingMag = false;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (key != null)
        {
            if (getKey == true)
            {
                key.position = transform.position + new Vector3(0, -2, 0);
            }
        }

        if (Input.GetKeyDown("1"))
        {
            if (usingMag == true)
            {
                usingMag = false;
            }
            else
            {
                usingMag = true;
            }

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Key")
        {
            if (usingMag == false)
            {
                getKey = true;
            }
            
        }

        if ((collision.gameObject.tag == "KeyHolder") && (getKey == true))
        {
            Destroy(remover);
            Destroy(this.gameObject);
            Destroy(magnet);

            winText.transform.position = new Vector3(-9.03f, 63.7f, -35.63f);
        }
    }
}
