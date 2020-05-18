﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;  // 추적할 타깃 게임오브젝트의 Transform 변수
    public float dist = 10.0f;  // 카메라와의 일정 거리
    public float height = 3.0f; // 카메라의 높이 설정
    public float dampTrace = 20.0f; // 부드러운 추적을 위한 변수

    // 카메라 자신의 Transform 변수
    private Transform tr;

    void Start()
    {
        // 카메라 자신의 Transform 컴포넌트를 tr에 할당
        tr = GetComponent<Transform>();
    }

    // Update 함수 호출 이후 한 번씩 호출되는 함수인 LateUpdate사용
    // 추적할 타깃의 이동이 조율된 이후에 카메라가 추적하기 위해 LateUpdate 사용
    private void LateUpdate()
    {
        // 카메라의 위치를 추적대상의 dist 변수만큼 뒤쪽으로 배치하고
        // height 변수만큼 위로 올림
        tr.position = Vector3.Lerp(tr.position,  // 시작 위치
            targetTr.position - (targetTr.forward * dist) + (Vector3.up * height),  // 종료 위치
            Time.deltaTime * dampTrace); // 보간 시간
        // 카메라가 타깃 게임 오브젝트를 바라보게 설정
        tr.LookAt(targetTr.position);
    }
    void Update()
    {
        
    }
}
