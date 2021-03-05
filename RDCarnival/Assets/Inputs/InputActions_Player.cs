// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/InputActions_Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions_Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions_Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions_Player"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""dee4537e-4743-4e7b-814e-eed558d26e66"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0d8023b2-6f47-4f9f-b0cf-37724178226c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d1201fbd-8a14-4e7b-9f8d-379d8fcad404"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopFire"",
                    ""type"": ""Button"",
                    ""id"": ""40e8a5de-a706-4819-b37f-6786376c62b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""0c45decb-f0ba-488d-afe5-1a9b3c0f5d4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6acacfdf-2bc2-4e1e-8959-670d24e253ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""17ae699c-1f42-41c0-94a5-e8744d1b18b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""a731c2c2-d1d1-4d5c-8ef0-928a417c1b2f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""e1bf3a70-dbf8-4324-b163-7372d05db134"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""444ba5e6-e93f-4aa3-b817-dcec02fb86c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopAim"",
                    ""type"": ""Button"",
                    ""id"": ""abb6d7fe-6ec1-41e2-b995-a44b1a97629e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quack"",
                    ""type"": ""Button"",
                    ""id"": ""dceac90b-e819-4821-9510-f4242c081028"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Squeak"",
                    ""type"": ""Button"",
                    ""id"": ""07ae9aa5-fc02-4981-8928-812b96ee3c51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scoreboard"",
                    ""type"": ""Button"",
                    ""id"": ""1347431d-f1a1-4ef2-9afe-dcccf63c5cae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""ae3c405c-1d86-4f77-9ee0-92444f626750"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""9b1d73dd-3e45-412f-acab-461223b768ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c4693f4c-9a2e-4c62-9bd5-7894c95b5052"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ead6de01-2844-472d-8ed2-c8f2e631471c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0905627b-ae11-4e5b-9679-a06ef1f2a66f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ff145124-b86a-4326-9db1-e51486c25679"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fdb5608f-d778-437f-8735-852ef4a0f614"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43cbea23-81c1-4270-b5b0-ecf477cbd999"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24d85933-3493-4f14-b546-8635cc8ee7e9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85f9f9df-1f4f-411b-b869-8b99c967c951"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1db0aa84-0dcf-4ccb-a8c9-1f5affe76d67"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e5013cc-47c5-4a7e-8ec4-519056cd9632"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d654c3b7-4e81-4632-8883-298060d1e720"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""809197b9-bf51-4e9e-b5b6-a1c80ff5f030"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5840a518-fee8-4ba8-871f-67cb9ab767f1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9c627c98-4d41-4923-9f3f-ca01ae2c53bc"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a3c86989-616f-472c-af79-410325a4b040"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""286e274d-97f9-4cc8-b117-aad936ec219b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1fd86bce-3093-47a1-ae73-b1deda21223f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00de4b16-3048-4b23-bc77-cc024334fad1"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb8404bc-df78-47a5-b8a9-5c36d56df6e2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03927df5-0b04-40d7-bc4c-a8379bc12bb2"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Quack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b471c130-d64a-4af7-8a43-9b3b9d7f133d"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Squeak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d95e9a-aa1d-4f7b-b89f-df6a9b91933d"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scoreboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11571e84-5693-4bbc-b37f-331d2bc108ef"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Scoreboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""a927cde6-7cd5-4834-bcdf-4fd6c4f167ce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b6cc252d-e5f3-462b-97f5-d018bc8c9c7d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bccc32e3-ddbd-43a8-96d7-e2b50cbb7b22"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""21d17697-6b81-42b1-8748-8c2c54f4762e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f0a4e35c-8bf0-4ecf-b259-17b8afc09a22"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ef74e84-cf98-45f0-962b-5d3ac4d2f7b0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8d4885f-4b35-4c39-b8c2-490e2979c7e6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;Gamepads"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f48d07b3-4ac2-4126-bfcd-b2a29ba93f59"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aac6ed8-ab86-4454-87af-d18498450b36"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ff56954-50f5-4287-a32c-6468d34dcb04"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard;Gamepads"",
                    ""action"": ""StopFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a9f3a81-4a75-4eb6-828c-e28c2a78d09d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StopFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc65f926-6801-4162-8fad-6cde654f345c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""StopFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79556f79-af90-47a6-8c9f-b692d6cd0026"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""StopAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fdd5a79-92c2-4c96-8d49-e3a974eca9ae"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2557ad17-aaaa-4448-ac82-a6d9b2de6f6c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu Controls"",
            ""id"": ""d7b4f420-559d-40ba-abbd-a3eb90c8d511"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b00b6fed-ffa7-4c66-9acb-de9bff8b1a16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""b349a1bf-e084-410e-bcce-f94c4a2d2f6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0cbd654-d026-43b5-8c9d-920b631fee6c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc5ed0a5-4276-44e6-aabc-7a51adc00ba9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepads"",
            ""bindingGroup"": ""Gamepads"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Fire = m_PlayerControls.FindAction("Fire", throwIfNotFound: true);
        m_PlayerControls_StopFire = m_PlayerControls.FindAction("StopFire", throwIfNotFound: true);
        m_PlayerControls_Shoot = m_PlayerControls.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_Boost = m_PlayerControls.FindAction("Boost", throwIfNotFound: true);
        m_PlayerControls_Look = m_PlayerControls.FindAction("Look", throwIfNotFound: true);
        m_PlayerControls_Rotate = m_PlayerControls.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerControls_Aim = m_PlayerControls.FindAction("Aim", throwIfNotFound: true);
        m_PlayerControls_StopAim = m_PlayerControls.FindAction("StopAim", throwIfNotFound: true);
        m_PlayerControls_Quack = m_PlayerControls.FindAction("Quack", throwIfNotFound: true);
        m_PlayerControls_Squeak = m_PlayerControls.FindAction("Squeak", throwIfNotFound: true);
        m_PlayerControls_Scoreboard = m_PlayerControls.FindAction("Scoreboard", throwIfNotFound: true);
        m_PlayerControls_PauseGame = m_PlayerControls.FindAction("PauseGame", throwIfNotFound: true);
        // Menu Controls
        m_MenuControls = asset.FindActionMap("Menu Controls", throwIfNotFound: true);
        m_MenuControls_Interact = m_MenuControls.FindAction("Interact", throwIfNotFound: true);
        m_MenuControls_Back = m_MenuControls.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Fire;
    private readonly InputAction m_PlayerControls_StopFire;
    private readonly InputAction m_PlayerControls_Shoot;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_Boost;
    private readonly InputAction m_PlayerControls_Look;
    private readonly InputAction m_PlayerControls_Rotate;
    private readonly InputAction m_PlayerControls_Aim;
    private readonly InputAction m_PlayerControls_StopAim;
    private readonly InputAction m_PlayerControls_Quack;
    private readonly InputAction m_PlayerControls_Squeak;
    private readonly InputAction m_PlayerControls_Scoreboard;
    private readonly InputAction m_PlayerControls_PauseGame;
    public struct PlayerControlsActions
    {
        private @InputActions_Player m_Wrapper;
        public PlayerControlsActions(@InputActions_Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Fire => m_Wrapper.m_PlayerControls_Fire;
        public InputAction @StopFire => m_Wrapper.m_PlayerControls_StopFire;
        public InputAction @Shoot => m_Wrapper.m_PlayerControls_Shoot;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @Boost => m_Wrapper.m_PlayerControls_Boost;
        public InputAction @Look => m_Wrapper.m_PlayerControls_Look;
        public InputAction @Rotate => m_Wrapper.m_PlayerControls_Rotate;
        public InputAction @Aim => m_Wrapper.m_PlayerControls_Aim;
        public InputAction @StopAim => m_Wrapper.m_PlayerControls_StopAim;
        public InputAction @Quack => m_Wrapper.m_PlayerControls_Quack;
        public InputAction @Squeak => m_Wrapper.m_PlayerControls_Squeak;
        public InputAction @Scoreboard => m_Wrapper.m_PlayerControls_Scoreboard;
        public InputAction @PauseGame => m_Wrapper.m_PlayerControls_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Fire.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFire;
                @StopFire.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStopFire;
                @StopFire.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStopFire;
                @StopFire.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStopFire;
                @Shoot.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Boost.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBoost;
                @Look.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLook;
                @Rotate.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRotate;
                @Aim.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @StopAim.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStopAim;
                @StopAim.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStopAim;
                @StopAim.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStopAim;
                @Quack.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnQuack;
                @Quack.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnQuack;
                @Quack.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnQuack;
                @Squeak.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSqueak;
                @Squeak.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSqueak;
                @Squeak.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSqueak;
                @Scoreboard.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnScoreboard;
                @Scoreboard.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnScoreboard;
                @Scoreboard.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnScoreboard;
                @PauseGame.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @StopFire.started += instance.OnStopFire;
                @StopFire.performed += instance.OnStopFire;
                @StopFire.canceled += instance.OnStopFire;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @StopAim.started += instance.OnStopAim;
                @StopAim.performed += instance.OnStopAim;
                @StopAim.canceled += instance.OnStopAim;
                @Quack.started += instance.OnQuack;
                @Quack.performed += instance.OnQuack;
                @Quack.canceled += instance.OnQuack;
                @Squeak.started += instance.OnSqueak;
                @Squeak.performed += instance.OnSqueak;
                @Squeak.canceled += instance.OnSqueak;
                @Scoreboard.started += instance.OnScoreboard;
                @Scoreboard.performed += instance.OnScoreboard;
                @Scoreboard.canceled += instance.OnScoreboard;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // Menu Controls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_Interact;
    private readonly InputAction m_MenuControls_Back;
    public struct MenuControlsActions
    {
        private @InputActions_Player m_Wrapper;
        public MenuControlsActions(@InputActions_Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_MenuControls_Interact;
        public InputAction @Back => m_Wrapper.m_MenuControls_Back;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnInteract;
                @Back.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    private int m_GamepadsSchemeIndex = -1;
    public InputControlScheme GamepadsScheme
    {
        get
        {
            if (m_GamepadsSchemeIndex == -1) m_GamepadsSchemeIndex = asset.FindControlSchemeIndex("Gamepads");
            return asset.controlSchemes[m_GamepadsSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnStopFire(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnStopAim(InputAction.CallbackContext context);
        void OnQuack(InputAction.CallbackContext context);
        void OnSqueak(InputAction.CallbackContext context);
        void OnScoreboard(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IMenuControlsActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
