 using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody2D body;
    public float runSpeed = 500.0f;
    public Animator animator;

    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis ("Horizontal") * runSpeed * Time.deltaTime;
        float vertical = Input.GetAxis ("Vertical") * runSpeed * Time.deltaTime;
        move(horizontal, vertical);
        animator.SetFloat("Speed", body.velocity.x);
        animator.SetFloat("SpeedUp", body.velocity.y);
    }

    void move(float _hori, float _vert)
    {
        Vector3 dest = new Vector2(_hori, _vert);
        body.velocity = Vector3.SmoothDamp(body.velocity, dest, ref velocity, 0.05f);
    }
}