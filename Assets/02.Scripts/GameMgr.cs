using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        PhotonNetwork.Instantiate("Tank"
            , new Vector3(0, 3.0f, 0)
            , Quaternion.identity);
    }

}
