using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ataque : MonoBehaviour
{   
    public ParticleSystem blood;
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
        if (collision.gameObject.CompareTag("enemy")) {
            blood.Play();
            Destroy(collision.gameObject);
            StartCoroutine(DestroyThis());

        }
        if(collision.gameObject) 
        {
            Destroy(gameObject);        
        }


    }
    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
}
