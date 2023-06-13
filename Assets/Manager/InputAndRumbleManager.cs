using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAndRumbleManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerController _playerController;

    private Gamepad pad;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        var PlayerControllers = FindObjectsOfType<PlayerController>();
        _playerController = PlayerControllers.FirstOrDefault(m => m.GetPlayerIndex() == _playerInput.playerIndex);
    }

    // Update is called once per frame
    public void Move(InputAction.CallbackContext context)
    {
        if (_playerController!=null)
        {
            Debug.Log(context.ReadValue<Vector2>());
            _playerController.SetPlayerDirection(context.ReadValue<Vector2>());
        }
    }

    public void RumblePluse(float lowFrequency, float highFrequency, float duration)
    {
        pad = _playerInput.devices[0] as Gamepad;
        if (pad!=null)
        {
            pad.SetMotorSpeeds(lowFrequency,highFrequency);
            StartCoroutine(stopRumble(duration, pad));
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (_playerController!=null)
        {
            _playerController.Dash();
        }
    }

    public int GetInputPlayerIndex()
    {
        return _playerInput.playerIndex;
    }

    IEnumerator stopRumble(float duration, Gamepad pad)
    {
        yield return new WaitForSeconds(duration);
        pad.SetMotorSpeeds(0f,0f);
    }
}
