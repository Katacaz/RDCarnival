using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    public GameObject activePlayer;
    public GameObject respawnCannon;

    public PlayerController playerControllerScript;
    public RespawnCannon respawnCannonScript;
    public Cannon playerCannonScript;

    public bool isRespawning;
    public bool isRespawnBall;
    public GameObject respawnBallCam;
    public CinemachineVirtualCamera respawnBallCamController;
    public GameObject playerReference;

    private PlayerInput input;

    public CharacterInfo playerInfo;

    [Header("Player UI")]
    public GameObject playerUI;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI elimsText;

    private PauseMenu pauseMenu;

    public PlayerCursor cursor;
    public bool usingCursor;

    public bool playerReady;
    public int playerNumber;
    private PlayerReadyMenu readyMenu;
    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        readyMenu = FindObjectOfType<PlayerReadyMenu>();
    }
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeartUI();
        UpdateElimsUI();
        if (isRespawning)
        {
            respawnCannon.SetActive(true);
            activePlayer.SetActive(false);
        } else if (!isRespawning && !isRespawnBall)
        {
            respawnCannon.SetActive(false);
            activePlayer.SetActive(true);
        }
        if (isRespawnBall)
        {
            respawnCannon.SetActive(false);
            respawnBallCam.SetActive(true);
        } else
        {
            respawnBallCam.SetActive(false);
        }
    }
    public void SetController(PlayerInput input)
    {
        this.input.SwitchCurrentControlScheme(input.devices[0]);
    }
    public void UpdateHeartUI()
    {
        healthText.text = playerInfo.info.health.ToString();
    }
    public void UpdateElimsUI()
    {
        elimsText.text = playerInfo.info.eliminations.ToString();
    }
    //PlayerMovement Input Related Functions
    public void OnMovement(InputValue value)
    {
        if (!pauseMenu.isPaused)
        {
            if (playerControllerScript.isActiveAndEnabled)
                playerControllerScript.OnMovement(value);
        }

    }
    public void OnLook(InputValue value)
    {
        if (!pauseMenu.isPaused)
        {
            if (playerControllerScript.isActiveAndEnabled)
                playerControllerScript.OnLook(value);
        }
    }
    public void OnBoost()
    {
        if (!pauseMenu.isPaused)
        {
            if (playerControllerScript.isActiveAndEnabled)
                playerControllerScript.OnBoost();
        }
    }
    public void OnJump()
    {
        if (!pauseMenu.isPaused)
        {
            if (playerControllerScript.isActiveAndEnabled)
                playerControllerScript.OnJump();
        }
    }
    public void OnScoreboard()
    {
        if (!pauseMenu.isPaused)
        {
            if (playerControllerScript.isActiveAndEnabled)
                playerControllerScript.OnScoreboard();
        }
    }
    //Player Cannon Input Related Functions
    public void OnFire()
    {
        if (!pauseMenu.isPaused)
        {
            if (playerCannonScript.isActiveAndEnabled)
                playerCannonScript.OnFire();
        }
    }
    public void OnStopFire()
    {
        if (playerCannonScript.isActiveAndEnabled)
            playerCannonScript.OnStopFire();
    }
    public void OnAim()
    {
        if (!pauseMenu.isPaused)
        {
            if (playerCannonScript.isActiveAndEnabled)
                playerCannonScript.OnAim();
        }
    }
    public void OnStopAim()
    {
        if (playerCannonScript.isActiveAndEnabled)
            playerCannonScript.OnStopAim();
    }
    public void OnQuack()
    {
        if (playerCannonScript.isActiveAndEnabled)
            playerCannonScript.OnQuack();
    }
    public void OnSqueak()
    {
        if (playerCannonScript.isActiveAndEnabled)
            playerCannonScript.OnSqueak();
    }
    //RespawnCannon Input Related Functions
    public void OnRotate(InputValue value)
    {
        if (!pauseMenu.isPaused)
        {
            if (respawnCannonScript.isActiveAndEnabled)
                respawnCannonScript.OnRotate(value);
        }
    }
    public void OnShoot()
    {
        if (!pauseMenu.isPaused)
        {
            if (respawnCannonScript.isActiveAndEnabled)
                respawnCannonScript.OnShoot();
        }
    }

    public void RespawnPlayer()
    {
        isRespawning = true;
        respawnCannonScript.newShot = true;
        respawnCannonScript.StartForceTimer();
    }
    public void PlayerSpectate()
    {
        respawnCannonScript.playerAlive = false;
        isRespawning = true;

    }
    public void OnPauseGame()
    {
        if (readyMenu.gameReady)
        {
            pauseMenu.TogglePauseGame();
        } else
        {
            readyMenu.ReadyPlayer(playerNumber);
        }
    }

    public void OnDeviceLost()
    {
        playerReady = false;
        readyMenu.UnReadyPlayer(playerNumber);
    }
}
