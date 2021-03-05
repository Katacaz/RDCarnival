using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{

    public int soloGameScene;
    public int duoGameScene;
    public int squadGameScene;

    public GameObject mainMenu;
    public GameObject gameModeMenu;
    public GameObject controls;
    public bool showControls;
    public TextMeshProUGUI controlsButtonText;

    public GameObject creditsScreen;
    public bool isCredits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showControls)
        {
            controls.SetActive(true);
            controlsButtonText.text = "Hide Controls";
        } else
        {
            controls.SetActive(false);
            controlsButtonText.text = "Show Controls";
        }

        if (isCredits)
        {
            creditsScreen.SetActive(true);
        } else
        {
            creditsScreen.SetActive(false);
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void PlaySolo()
    {
        SceneManager.LoadScene(soloGameScene);
    }
    public void PlayDuo()
    {
        SceneManager.LoadScene(duoGameScene);
    }
    public void PlaySquad()
    {
        SceneManager.LoadScene(squadGameScene);
    }
    public void ToggleControls()
    {
        showControls = !showControls;
    }
    public void ShowCredits(bool value)
    {
        isCredits = value;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
