using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
   private Rigidbody2D rb;
   private Vector2 direction;
   public float speed = 10f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("SpeedX", direction.x);

    }
        //Fixedupdate is called 50 times per second togther with the physics system
    void FixedUpdate()
    {
        rb.linearVelocity = direction/*.normalized*/ * speed;
    }
}