using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviourPunCallbacks
{
    //cannon 프리팹을 연결할 변수
    public GameObject cannon = null;
    //포탄 발사 사운드 파일
    private AudioClip fireSfx = null;
    //AudioSource 컴포넌트를 할당할 변수
    private AudioSource sfx = null;
    //cannon 발사 지점
    public Transform firePos;

    private void Awake()
    {
        //cannon 프리팹을 Resources 폴더에서 불러와 변수에 할당
        cannon = (GameObject)Resources.Load("Cannon");
        //포탄 발사 사운드 파일을 Resources 폴더에서 불러와 변수에 할당
        fireSfx = Resources.Load<AudioClip>("CannonFire");
        //AudioSource 컴포넌트를 할당
        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            //마우스 왼쪽버튼 클릭 시 발사 로직 수행
            if (Input.GetMouseButtonDown(0))
            {
                photonView.RPC("Fire", RpcTarget.AllViaServer, null);
            }
        }
    }

    [PunRPC]
    void Fire()
    {
        //발사 사운드 발생
        sfx.PlayOneShot(fireSfx, 1.0f);
        Instantiate(cannon, firePos.position, firePos.rotation);
        //PhotonNetwork.Instantiate("Cannon"
        //    , firePos.position
        //    , firePos.rotation);
    }
}
