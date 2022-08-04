using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] InputActionReference triggerInputAction;
    [SerializeField] InputActionReference gripInputAction;

    Animator handAnimator;

    private void Awake() 
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        triggerInputAction.action.performed += TriggerPressed;
        gripInputAction.action.performed += GripPressed;
    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void OnDisable() 
    {
        triggerInputAction.action.performed -= TriggerPressed;
        gripInputAction.action.performed -= GripPressed;
    }
}
