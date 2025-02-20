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
        GameLoadingText.SetActive(false);
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

        //movementDirection 값 하나씩 추출해 사용할 수 있는 형태로 만들기
        float moveX = movementDirection.x;
        float moveY = movementDirection.y;

        //바라보는 뱡향(a&<, d&>)에 따라 direction 바뀌도록
        if(moveX == 0) //위, 아래로 움직이거나 움직이지 않을 때 
        { }
        else if(moveX != 0)//좌,우,대각선으로 움직일 때
        {
            Rotate(movementDirection);
        }
    }
}
