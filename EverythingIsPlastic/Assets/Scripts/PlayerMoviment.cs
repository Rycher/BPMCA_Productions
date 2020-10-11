using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public Transform PlayerTransform;
    public float speed = 10;
    public float jump = 15;
    public Rigidbody PlayerRB;
    public Animator PlayerAnim;
    public SpriteRenderer PlayerSpriteRender;
    // Update is called once per frame
    void Update()
    {
        Moviment();
    }

    private void FlipSprite()
    {
        if (Input.GetKeyDown("a"))
        {
            PlayerSpriteRender.flipX = true;
        }
        else if (Input.GetKeyDown("d"))
        {
            PlayerSpriteRender.flipX = false;
        }
    }


    private void Moviment()
    {
        float PlayerMovH = Input.GetAxis("Horizontal");
        float PlayerMovV = Input.GetAxis("Vertical");

        FlipSprite();

        if (PlayerMovH != 0f || PlayerMovV != 0f)
        {            
            PlayerAnim.SetBool("Walk", true);            
        }
        else if (PlayerMovH == 0f && PlayerMovH == 0f)
        {            
            PlayerAnim.SetBool("Walk", false);
        }
       
        PlayerTransform.position += new Vector3(PlayerMovH, 0, PlayerMovV) * Time.deltaTime * speed;
        if (Input.GetButtonDown("Jump") && Mathf.Abs(PlayerRB.velocity.y) < 0.001f)
        {
            PlayerRB.AddForce(new Vector2(0, jump), ForceMode.Impulse);
        }
    }
}
