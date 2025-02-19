using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start() 
    {
        base.Start();
        camera = Camera.main;
    }
    private void Update()
    {
        HandleAction();
    }

    protected override void HandleAction() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        //movementDirection �� �ϳ��� ������ ����� �� �ִ� ���·� �����
        float moveX = movementDirection.x;
        float moveY = movementDirection.y;

        //�ٶ󺸴� ����(a&<, d&>)�� ���� direction �ٲ��
        if(moveX == 0) //��, �Ʒ��� �����̰ų� �������� ���� �� 
        {
            Debug.Log("�ִϸ��̼� ����");
        }
        else if(moveX != 0) 
        {
            Rotate(movementDirection);
            Debug.Log(movementDirection);
        }
    }
}
