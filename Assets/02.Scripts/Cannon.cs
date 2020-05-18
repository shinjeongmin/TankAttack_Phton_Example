﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    //포탄의 속도
    public float speed = 6000.0f;
    //폭발 효과 프리팹 연결 변수
    public GameObject expEffect;
    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();

        GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        //3초가 지난 후 자동 폭발하는 코루틴 실행
        StartCoroutine(this.ExplosionCannon(3.0f));
    }

    private void OnTriggerEnter()
    {
        //지면 또는 적 탱크에 충돌한 경우 즉시 폭발하도록 코루틴 실행
        StartCoroutine(this.ExplosionCannon(0.0f));
    }

    IEnumerator ExplosionCannon(float tm)
    {
        yield return new WaitForSeconds(tm);
        //충돌 콜백 함수가 발생하지 않도록 Collider를 비활성화
        _collider.enabled = false;
        //물리엔진의 영향을 받을 필요없음
        _rigidbody.isKinematic = true;

        //폭발 프리팹 동적 생성
        GameObject obj = (GameObject)Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);

        //Trail Renderer가 소멸되기까지 잠시 대기 후 삭제 처리
        Destroy(this.gameObject, 1.0f);
    }
}
