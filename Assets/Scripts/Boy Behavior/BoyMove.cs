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
   private float timeSinceLastTab;
    private Vector2 first_speed;
    public bool is_fast=false;
    private const float DOUBLE_TIME = .2f;
    private float LAstTabTime;
    
    void Start()
    {
            PlInt = gameObject.GetComponent<PlayerInteract>();
            rb = GetComponent<Rigidbody2D>();
            first_speed = speed;
            armComp.animation.Play("stop", 0);
    }

     void Update()
    {
       
            if (!is_game_over)
            {
                if (!PlInt.stop_boy)
                {
                    if (Input.GetButtonDown("Horizontal")) { timeSinceLastTab = Time.time - LAstTabTime; }

                if (Input.GetButtonUp("Horizontal"))
                {
                    speed = first_speed;
                    is_fast = false;
                    timeSinceLastTab = 1;
                }
            
                    if (GetOfGameObj.get() == 3 && (timeSinceLastTab <= DOUBLE_TIME))
                    {
                        Debug.Log("Time Les" + timeSinceLastTab);
                        Debug.Log("Time more" + DOUBLE_TIME);
                        speed = new Vector2(2, 1.5f);
                        is_fast = true;
                    }
                    else
                    {
                        Debug.Log("Sped doesn't change");
                        speed = first_speed;
                        is_fast = false;
                    }

                    float inputX = Input.GetAxis("Horizontal");
                    float inputY = Input.GetAxis("Vertical");

                    if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
                    {
                        armComp.animation.Play("walk", 0);
                        LAstTabTime = Time.time;
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
