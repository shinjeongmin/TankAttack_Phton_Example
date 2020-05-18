using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public enum ActivePanel 
    {
        LOGIN, 
        ROOMS
    }

    //App의 버전 정보
    public string gameversion = "1.0";
    public string userId = "JeongMin";
    public byte maxPlayer = 20;

    private void Awake()
    {
        // photon1과 photon2로 바뀌면서 달라진점 (같은방 동기화)
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
        // photonNetwork의 데이터 통신을 잠깐 정지 시켜준다.
        // gamemanager에서 createTank하고 나면 다시 연결시킨다.
        SceneManager.LoadScene("scBattleField");

        PhotonNetwork.IsMessageQueueRunning = false;
    }

    public void OnCreateRoomClick()
    {
        PhotonNetwork.CreateRoom(null
            , new RoomOptions { MaxPlayers = this.maxPlayer });
    }

    public void OnJoinRandomRoomClick()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
