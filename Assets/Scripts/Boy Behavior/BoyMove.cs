using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.SceneManagement;

public class BoyMove : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;
    private Rigidbody2D rb;
   public UnityArmatureComponent armComp;
    private bool isFacingRight = true;
    public bool is_game_over = false;
   PlayerInteract PlInt;
    void Start()
    {
        PlInt = gameObject.GetComponent<PlayerInteract>();
        rb = GetComponent<Rigidbody2D>();
        // UnityFactory.factory.LoadDragonBonesData("Animation/Boy_ske");
        // UnityFactory.factory.LoadDragonBonesData("Animation/Boy_tex");
        //  armComp = GetComponent<UnityArmatureComponent>();
        //this.GetComponent<UnityArmatureComponent>().animation.Play("stop");
        armComp.animation.Play("stop",0);
    }

     void Update()
    {
        if (!is_game_over)
        {
             if (!PlInt.stop_boy) { 
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {
                armComp.animation.Play("walk", 0);
            }
            if ((Input.GetButtonUp("Horizontal") && (!Input.GetButtonDown("Vertical") && !Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))) || (Input.GetButtonUp("Vertical") && (!Input.GetButton("Horizontal") && !Input.GetButtonDown("Horizontal") && !Input.GetButton("Vertical"))))
            {
                armComp.animation.Play("stop", 0);
            }
            movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);
            if (inputX > 0 && !isFacingRight)
                //отражаем персонажа вправо
                Flip();
            //обратная ситуация. отражаем персонажа влево
            else if (inputX < 0 && isFacingRight)
                Flip();
            //  float inputY = Input.GetAxis("Vertical"); speed.y * inputY
            movement = new Vector2(speed.x * inputX, speed.y * inputY);
        }
            else
            {
                movement = new Vector2(0, 0);
            }
        }
        else
        {
            movement = new Vector2(0, 0);
            rb.velocity = movement;
            armComp.animation.Stop("stop");
            armComp.animation.Stop("walk");
            if (!armComp.animation.isPlaying)
            {
               
                armComp.animation.Play("cry");
            }
           
            Invoke("Lose", 2f);
        }
    }
    void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
   public void FlipDoor(bool range)
    {
        if (range)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }
    void FixedUpdate()
    {
            rb.velocity = movement;
        
    }
}
