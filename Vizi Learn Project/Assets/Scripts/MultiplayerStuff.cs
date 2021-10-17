using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class MultiplayerStuff : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        Room();
    }

    private void Room()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = (byte)5,
            IsOpen = true,
            IsVisible = true,
            PlayerTtl = 10000,
            EmptyRoomTtl = 10000
        };
        PhotonNetwork.CreateRoom("Room1", roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("In room");
    }
}
