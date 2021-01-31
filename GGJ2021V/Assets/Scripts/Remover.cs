using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{

    public GameObject opsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tax" || collision.gameObject.tag == "Destroyable" || collision.gameObject.tag == "Key" || collision.gameObject.tag == "Table")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Key")
        {
            opsText.transform.position = new Vector3(-25.03f, 63.7f, -35.63f);
        }
    }
}
