using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : MonoBehaviourPunCallbacks
{
    private Transform tr;
    public float rotSpeed = 100.0f;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        float angle = -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * rotSpeed;
        tr.Rotate(angle, 0, 0);
    }
}
