using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Login : MonoBehaviour
{
    public TMP_InputField pac;
    public GameObject charan;
    public GameObject aksa;

    public void ChangePage()
    {
        if (pac.text == "123456")
        {
            charan.SetActive(true);
            PhotonNetwork.NickName = "Charan";
        }
        else
        {
            aksa.SetActive(true);
            PhotonNetwork.NickName = "Aksa";
        }
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("Auditorium");
    }
}
