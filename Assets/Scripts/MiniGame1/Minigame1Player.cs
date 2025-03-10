using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Player : MonoBehaviour
{
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;
    
    Game1GameManager game1GameManager = null;
    
    void Start()
    {
        game1GameManager = Game1GameManager.Instance;

        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if( _rigidbody == null ) 
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) 
        { 
            if(deathCooldown <= 0) 
            {
                //�ȳ� UI ����
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    game1GameManager.RestartGame();
                }
                else if(Input.GetKeyDown(KeyCode.E)) 
                { 
                    game1GameManager.EndGame();
                }
            }
            else 
            { 
                deathCooldown -= Time.deltaTime;
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            { 
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if(isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap) 
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        //float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 0.05f);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        isDead = true;

        deathCooldown = 1f;
        game1GameManager.GameOver();
    }
}
