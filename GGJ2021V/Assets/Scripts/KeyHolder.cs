using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHolder : MonoBehaviour
{
    public GameObject remover;
    public GameObject pointer;
    public GameObject magnet;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("q"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(remover);
            Destroy(pointer);
            Destroy(magnet);
            winText.transform.position = new Vector3(-9.03f, 63.7f, -35.63f);
        }
    }
}
