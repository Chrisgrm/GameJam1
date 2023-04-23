using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button instructionsButton;
    public Button nextButton;
    public GameObject panelInstructions;
    public GameObject panelPrincial;

    private void Start()
    {
        instructionsButton.onClick.AddListener(activateInstructions);
        nextButton.onClick.AddListener(activateNextButton);

    }
    void activateInstructions()
    {
        panelInstructions.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }

    void activateNextButton()
    {
        panelInstructions.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }
    public void StarGame()
    {
        SceneManager.LoadScene("Laberinto0.1");
    }


}
