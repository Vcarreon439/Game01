using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler compartido;

    public float jumpForce  = 6.0f;
    public float runningSpeed  = 3.0f;
    private Rigidbody2D rigidbody;
    public LayerMask groundLayerMask;
    public Animator animador;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        compartido = this;
    }

    void FixedUpdate()
    {
        if (GameManager.sharedInstance.current == GameState.inGame)
        {
            if (rigidbody.velocity.x < runningSpeed)
            {
                rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animador.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.current == GameState.inGame)
            if (Input.GetMouseButtonDown(0))
                Saltar();

        animador.SetBool("isGrounded", IsOnTheFloor());
    }

    void Saltar()
    {
        if (IsOnTheFloor())
            rigidbody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }

    bool IsOnTheFloor()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value))
            return true;
        else
            return false;
    }

    public void KillPlayer() 
    {
        GameManager.sharedInstance.GameOver();
        animador.SetBool("isAlive", false);
    }
}
