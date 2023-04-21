using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]string nameScene;
    PlayerController playerCs;
    TextMeshProUGUI keyNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Nivel1")
        {
            UpdateKey();

        }
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nameScene);
    }

    void UpdateKey()
    {
        keyNumber.text = " " + playerCs.llaves;
    }

    void ContadorVidas()
    {

    }
}
