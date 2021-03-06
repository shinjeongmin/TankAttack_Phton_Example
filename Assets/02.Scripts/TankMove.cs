﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankMove : MonoBehaviourPunCallbacks
{
    //탱크의 이동 및 회전 속도를 나타내는 변수
    public float moveSpeed = 20.0f;
    public float rotSpeed = 50.0f;

    //참조할 컴포넌트를 할당할 변수
    private Rigidbody rbody;
    private Transform tr;
    //키보드 입력값 변수
    private float h, v;

    public TextMeshPro nickName;

    private void Start()
    {
        //컴포넌트 할당
        rbody = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        //Rigidbody의 무게중심을 낮게 설정
        rbody.centerOfMass = new Vector3(0.0f, -0.5f, 0.0f);

        if (photonView.IsMine)
        {
            Camera.main.GetComponent<FollowCam>().targetTr =
                tr.Find("CamPivot").transform;
        }

        // 닉네님 텍스트 메쉬프로에 photonView컴포넌트가 들어있는 오브젝트의 닉네임을 넣음.
        nickName.text = photonView.Owner.NickName;
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            //회전과 이동 처리
            tr.Rotate(Vector3.up * rotSpeed * h * Time.deltaTime);
            tr.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
        }
    }
}