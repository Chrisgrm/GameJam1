using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //llamamos la libreria de IA

public class enemy : MonoBehaviour
{
    [SerializeField]Transform transformPlayer; //Position Player
    NavMeshAgent enemyAi; //Invocamos Navmesh 
    private Animator enemyAnim; //Llamamoss animacion 

    void Start()
    {
        enemyAi = GetComponent<NavMeshAgent>(); //Capturamos el componente de Nav
        enemyAnim = GetComponent<Animator>(); //Capturamos el animator
    }

    
    void Update()
    {
        enemyAi.SetDestination(transformPlayer.position); //Definimos el destino
        if(enemyAi.speed > 0) //Condicionamos el arranque
        {
            enemyAnim.SetFloat("Speed", 0.15f);
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