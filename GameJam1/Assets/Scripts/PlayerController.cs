using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private float rotationSpeed = 100;
    private float speed = 200;
    public int vidas = 3;
    
    public GameObject prefabAtaque;
    private float enfriamientoAtaque = 0.3f;
    float contador = 0;
    Vector3 offSet = new Vector3(0, 2, 2);
    Animator animatorPlayer;
    public int llaves;
    public bool muerto = false;
    private AudioSource playerAudio;
    public AudioClip shotSound;
    public AudioClip keySound;
    public AudioClip muerteSound;
    public AudioClip zombieAttackSound;
    public ParticleSystem keyParticle;
    private Rigidbody rb;
    private Transform atackPosition;
    bool muertoSound = false;

    void Start()
    {
        atackPosition = GameObject.Find("AtackPosition").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        
        animatorPlayer.SetFloat("speedWalk", inputVertical);        
        transform.Rotate(Vector3.up * inputHorizontal * rotationSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            ataque();
            
            
        }
        if (vidas <= 0) {
            muerte();
        }
        contador += Time.deltaTime;
    }

    private void FixedUpdate()
    {

        rb.AddRelativeForce(Vector3.forward * inputVertical * speed);
        transform.Rotate(Vector3.up * inputHorizontal * 5);

        if (inputVertical == 0)
        {
            rb.velocity = Vector3.zero;
        }
     
    }

    void ataque()
    {


        if (contador > enfriamientoAtaque && !muerto)
        {
            Instantiate(prefabAtaque, atackPosition.position , Quaternion.identity);
            contador = 0;
            playerAudio.PlayOneShot(shotSound,1.0f);
        }
        
    }


    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("enemy")){

            vidas -= 1;
            if (!muerto)
            {
                playerAudio.PlayOneShot(zombieAttackSound, 1.0F);
            }
           
        }
 
    }
   

    private void muerte()
    {
        muerto = true;
        if (!muertoSound) { 
            playerAudio.PlayOneShot(muerteSound, 1.0F);
            muertoSound = true;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llave")) {
           
            Destroy(other.gameObject);
            llaves += 1;
            playerAudio.PlayOneShot(keySound,1.0F);
            keyParticle.Play();

        }
    }


}
