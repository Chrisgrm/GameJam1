using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private float rotationSpeed = 200;
    private float speed = 10;
    private int vidas = 3;
    private Vector3 updatePosition;
    public GameObject prefabAtaque;
    private float enfriamientoAtaque = 1f;
    float contador = 0;
    Vector3 offSet = new Vector3(0, 2, 2);
    Animator animatorPlayer;
    public int llaves;
    bool muerto = false;
    private AudioSource playerAudio;
    public AudioClip shotSound;
    public AudioClip keySound;
    public AudioClip muerteSound;
    public AudioClip zombieAttackSound;
    public ParticleSystem keyParticle;
    private Rigidbody rb;
    private Transform atackPosition;

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
        updatePosition = new Vector3(0, 0, inputVertical);
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
        transform.Translate(Vector3.forward * inputVertical * speed * Time.deltaTime);
        //rb.AddForce(updatePosition * speed, ForceMode.Impulse);
    }

    void ataque()
    {


        if (contador > enfriamientoAtaque)
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
            print(vidas);
            print("auch");
            //playerAudio.PlayOneShot(zombieAttackSound,1.0F);
        }
        if (other.gameObject.CompareTag("muros"))
        {
            print("toca muro");
        }
    }
   

    private void muerte()
    {
        muerto = true;
        playerAudio.PlayOneShot(muerteSound,1.0F);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llave")) {
            print("holaaaa");
            Destroy(other.gameObject);
            llaves += 1;
            playerAudio.PlayOneShot(keySound,1.0F);
            keyParticle.Play();

        }
    }


}
