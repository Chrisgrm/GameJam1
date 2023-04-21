using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    private Transform playerController;
    float ataqueSpeed = 15;
    Vector3 direction;
    



    void Start()
    {
        playerController = GameObject.Find("Player").transform;
        direction=playerController.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * ataqueSpeed * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);
        }
        else {
            GameObject.Destroy(gameObject);        
        }

    }
}
