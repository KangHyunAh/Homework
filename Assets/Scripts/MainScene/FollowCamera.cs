using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;//����Ƽ ���ο��� Ÿ�� ������� ĭ �����
    float offsetX;
    float offsetY;
    void Start() //�ʱ� ����
    {
        if (target == null)
            return;

        //offset = ���� ī�޶� ��ġ�� Ÿ�� ��ġ �Ÿ�
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    void Update() //������ �ݺ��Ǵ� �ڵ�
    {
        {
            //Ÿ�� ���� ��� �������� �ʰ� ����
            if (target == null)
                return;

            //��ġ ���Ϳ� ī�޶� ��ġ ��������
            Vector3 pos = transform.position;

            //���� ī�޶� ��ġ = ���� ī�޶� ��ġ + ���� ī�޶� ��ġ�� Ÿ�� ��ġ �Ÿ�
            //��ġ ���Ͱ� Ÿ�� ��ġ�� ����������
            pos.x = target.position.x + offsetX;
            pos.y = target.position.y + offsetY;

            //Ÿ�� ��ġ�� ������ ��ġ ���� ���� ī�޶� �����ϱ�
            transform.position = pos;
        }
    }
}

