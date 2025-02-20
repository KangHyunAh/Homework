using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class WidthFollowCamera : MonoBehaviour
{
    public Transform target;//����Ƽ ���ο��� Ÿ�� ������� ĭ �����
    float offsetX;
    void Start() //�ʱ� ����
    {
        if (target == null)
            return;

        //offset = ���� ī�޶� ��ġ�� Ÿ�� ��ġ �Ÿ�
        offsetX = transform.position.x - target.position.x;
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

            //Ÿ�� ��ġ�� ������ ��ġ ���� ���� ī�޶� �����ϱ�
            transform.position = pos;
        }
    }
}

