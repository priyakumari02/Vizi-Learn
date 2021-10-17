using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public CinemachineFreeLook freeLook;

    private void Awake()
    {
        GameObject g = PhotonNetwork.Instantiate("Player", new Vector3(0f, 0.5f, 0f), Quaternion.identity);
        freeLook.Follow = g.transform;
        freeLook.LookAt = g.transform.GetChild(1);
    }
}
