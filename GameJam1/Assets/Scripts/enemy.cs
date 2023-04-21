using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //llamamos la libreria de IA

public class enemy : MonoBehaviour
{
    [SerializeField]Transform transformPlayer; //Position Player
    NavMeshAgent enemyAi; //Invocamos Navmesh 
    private Animator enemyAnim; //Llamamoss animacion 
    [SerializeField]float distanceToPlayer;

    void Start()
    {
        enemyAi = GetComponent<NavMeshAgent>(); //Capturamos el componente de Nav
        enemyAnim = GetComponent<Animator>(); //Capturamos el animator
    }

    
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, transformPlayer.position);
        
        if(distanceToPlayer < 5) //Condicionamos el arranque
        {
            enemyAi.speed = 3;
            enemyAi.SetDestination(transformPlayer.position); //Definimos el destino
            enemyAnim.SetFloat("Speed", 0.15f);
        }
        else
        {
            enemyAi.speed = 0; //Definimos que no ande
            enemyAnim.SetFloat("Speed", 0f); //Volvemos speed 0 para que no quede animado corriendo
        }
        
    }

    private void OnCollisionEnter (Collision other){ 
    if(other.gameObject.CompareTag("Player") ){
        Destroy(other.gameObject);
        }
    else if (other.gameObject.CompareTag("Disparo")){
            Destroy(this.gameObject);
        }
    }
}