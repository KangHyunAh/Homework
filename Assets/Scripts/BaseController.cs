using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private SpriteRenderer weaponPivot;
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    public GameObject GameLoadingText;

    protected virtual void Awake() 
    { 
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        
    }


    protected virtual void Update()
    {
        Movement(movementDirection);
        if (knockbackDuration > 0.0f) 
        { 
            knockbackDuration -= Time.deltaTime;
        }
    }

    protected virtual void FixedUpdate() 
    {
        Movement(movementDirection);
        if (knockbackDuration > 0.0f) 
        { 
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction) 
    {
        direction = direction * 5;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }

    public void ApplyKnockback(Transform other,float power, float duration) 
    { 
        knockbackDuration = duration;
        knockback =- (other.position - transform.position).normalized * power;
    }
}
