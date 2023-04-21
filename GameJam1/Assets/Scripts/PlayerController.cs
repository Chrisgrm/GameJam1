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
    private Vector3 posicionInicial;
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

    void Start()
    {
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
        transform.Translate(Vector3.forward * inputVertical * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) {
            ataque();
            //playerAudio.PlayOneShot(shotSound,1.0f);
            
        }
        if (vidas <= 0) {
            muerte();
        }
        contador += Time.deltaTime;
    }

    void ataque()
    {


        if (contador > enfriamientoAtaque)
        {
            Instantiate(prefabAtaque, transform.position + offSet, Quaternion.identity);
            contador = 0;
        }
        
    }


    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("enemy")){

            vidas -= 1;
            print(vidas);
            print("auch");
            playerAudio.PlayOneShot(zombieAttackSound,1.0F);
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
