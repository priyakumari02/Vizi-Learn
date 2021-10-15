using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookCamera : MonoBehaviour
{
    private CinemachineFreeLook freeLookCam;
    private Player playerInput;

    public float lookSpeed = 1f;

    private void Awake()
    {
        playerInput = new Player();
        playerInput.Enable();

        freeLookCam = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        Vector2 delta = playerInput.PlayerControl.Look.ReadValue<Vector2>();

        freeLookCam.m_XAxis.Value += delta.x * 150 * lookSpeed * Time.deltaTime;
        freeLookCam.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }
}
