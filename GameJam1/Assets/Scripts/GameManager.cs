using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text winText;
    public TMP_Text keyText;   
    public Button restartButton;    
    private PlayerController player;
    private GameObject exitDoor;
    public GameObject[] lifesCount;
    public GameObject panelVictoria;
    public GameObject panelGameOver;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        exitDoor = GameObject.Find("exitDoor");
    }

    // Update is called once per frame
    void Update()
    {
        verificadorDeLlaves();
        verificadorDeVidas();
        verificadorDeGameOver();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("win"))
        {
            victoria();
        }
    }
    void verificadorDeVidas()
    {
        switch (player.vidas)
        {
            //Ejemplo: aquí cuando nuestro int lifes = 2, desactiva el corazoncito en la posición 0 (osease el primero) en nuestro arreglo y deja los otros 2 encendidos.
            case 2:
                lifesCount[0].SetActive(false);
                lifesCount[1].SetActive(true);
                lifesCount[2].SetActive(true);
                break;
            case 1:
                lifesCount[0].SetActive(false);
                lifesCount[1].SetActive(false);
                lifesCount[2].SetActive(true);
                break;
            case 0:
                lifesCount[0].SetActive(false);
                lifesCount[1].SetActive(false);
                lifesCount[2].SetActive(false);
                break;
            //Nuestro estado "default" es donde definimos cómo deben estar nuestros corazoncitos al inicio (es decir cuando lifes = 3), por ende, todos estan encendidos (en "true")
            default:
                lifesCount[0].SetActive(true);
                lifesCount[1].SetActive(true);
                lifesCount[2].SetActive(true);
                break;
        }
    }


    void verificadorDeLlaves()
    {
        if (player.llaves == 3)
        {
            exitDoor.SetActive(false);
        }

        //keyText.text = player.llaves + "/3"; 
    }
     void verificadorDeGameOver()
    {
        if (player.muerto)
        {
            panelGameOver.SetActive(true);           
        }
    }

    public void restarGame()
    {
        SceneManager.LoadScene("Laberinto0.1");
    }


    public void victoria()
    {
        panelVictoria.SetActive(true);
    }


}
