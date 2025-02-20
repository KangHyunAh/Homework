using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;//유니티 내부에서 타겟 끌어오는 칸 만들기
    float offsetX;
    float offsetY;
    void Start() //초기 설정
    {
        if (target == null)
            return;

        //offset = 메인 카메라 위치와 타겟 위치 거리
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    void Update() //꾸준히 반복되는 코드
    {
        {
            //타겟 없을 경우 실행하지 않고 종료
            if (target == null)
                return;

            //위치 벡터에 카메라 위치 가져오기
            Vector3 pos = transform.position;

            //메인 카메라 위치 = 메인 카메라 위치 + 메인 카메라 위치와 타겟 위치 거리
            //위치 벡터가 타겟 위치와 같아지도록
            pos.x = target.position.x + offsetX;
            pos.y = target.position.y + offsetY;

            //타겟 위치와 같아진 위치 벡터 메인 카메라에 적용하기
            transform.position = pos;
        }
    }
}

