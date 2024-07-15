using System;
using Unity.Netcode;
using UnityEngine;
public class PlayerController : NetworkBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerMode;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerAnimationController playerAnimationController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float revolveSpeed = 40f;
    
    private GameKeySettings gameKeySettings;
    private Camera mainCam;
    private Vector2 lastPlayerMove = Vector2.zero;
    private PlayerState playerState;
    private Vector3 lastFramePosition;
    void Awake()
    {
        this.gameObject.AddComponent<GameKeySettings>();
        gameKeySettings = this.gameObject.GetComponent<GameKeySettings>();
    }
    void Start()
    {
        playerState = GetComponentInChildren<PlayerState>();
        mainCam = Camera.main;
    }

    private void PerformMovement()
    {
        if (playerInput.playerMove != Vector2.zero)
        {
            playerAnimationController.ChangeAnimationSymbol((int)PlayerAnimationSymbol.run);
        }
        else
        {
            if (lastPlayerMove != Vector2.zero)
            {
                switch (playerState.playerFoot)
                {
                    case "leftFoot":
                        playerAnimationController.ChangeAnimationSymbol((int)PlayerAnimationSymbol.runEndRight);
                        break;
                    case "rightFoot":
                        playerAnimationController.ChangeAnimationSymbol((int)PlayerAnimationSymbol.runEndLeft);
                        break;
                }
            }
        }
        lastPlayerMove = playerInput.playerMove;
    }
    private void PerformRotation() 
    {
        if (playerInput.playerMove != Vector2.zero)
        {
            Vector3 rotate = new Vector3(playerInput.playerMove.x, 0f, playerInput.playerMove.y);
            float camAxisY = mainCam.transform.rotation.eulerAngles.y;
            if (Input.GetKey(gameKeySettings.switchPerspective))
            {
                camAxisY = playerMode.transform.rotation.eulerAngles.y;
            }
            Vector3 targetDirection = Quaternion.Euler(0, camAxisY, 0) * rotate;
            Quaternion targetQuaternion = Quaternion.LookRotation(targetDirection);
            
            float angle = Mathf.Abs(targetQuaternion.eulerAngles.y - playerMode.transform.rotation.eulerAngles.y);
            //print(angle);
            if (angle > 175f && angle < 185f)
            {
                playerAnimationController.ChangeAnimationSymbol((int)PlayerAnimationSymbol.turnBack);
                print("back");
            }
            else
            {
                playerMode.transform.rotation = Quaternion.Slerp(playerMode.transform.rotation, targetQuaternion,
                    Time.deltaTime * revolveSpeed);
            }
        }
    }
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void OnEnable()
    {
        if (gameKeySettings != null)
        {
            gameKeySettings.enabled = true;
        }
    }

    void OnDisable()
    {
        if (gameKeySettings != null)
        {
            gameKeySettings.enabled = false;
        }
    }
}
