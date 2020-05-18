using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    //App의 버전 정보
    public string gameversion = "1.0";
    public string userId = "JeongMin";
    public byte maxPlayer = 20;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        PhotonNetwork.GameVersion = this.gameversion;
        PhotonNetwork.NickName = userId;

        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect To Master");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Join room !!!");
        PhotonNetwork.CreateRoom(null
            ,new RoomOptions { MaxPlayers = this.maxPlayer });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room !!!");
        PhotonNetwork.Instantiate("Tank"
            , new Vector3(0, 3.0f, 0)
            , Quaternion.identity);
    }
}
