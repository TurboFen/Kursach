using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrandmaAI : MonoBehaviour
{
    //For Grandma noving
    public UnityEngine.Transform[] patrolPoints;
    UnityEngine.Transform currentPatrolPoint;
    int currentPatrolIndex = 1;
    public float speed;
    private bool isFacingRight = true;
    private float last_time;
    private bool flag_move;
    private bool flag_angry;
    //animation
    public UnityArmatureComponent armComp;
    //audio
    public AudioClip[] voice;
    AudioSource AUdio;
    //Reaction to damaged tools - anger
    public GameObject currentIntObj = null;
    public InteractionObject currentInterObjScript = null;
    private float rage;
    public float maxRage;
    public Slider rage_slider;

    //Reacton to boy - anger
    public BoyMove boy ;
    public GameObject for_boy;
    private bool trys = false;
    //HER MOOD IMAGE
    public Image mood;
    public Sprite[] grandmaMood;
    private int count_of_mood = 1;

    //Time
    private int minutes;
    private int seconds;
    public float Time_Game;
    private string Timer_sec;
    private string Timer_min;
    public Text Last_time;
    public bool Game_over=false;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InteractableObj")
        {
            print("I am near of it");
            currentIntObj = other.gameObject;
            currentInterObjScript = currentIntObj.GetComponent<InteractionObject>();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "InteractableObj")
        {
            if (collision.gameObject == currentIntObj)
            {
                currentIntObj = null;
            }

        }
    }
    void Time_Update(float time)
    {
        minutes = (int)time / 60;
        seconds = (int)time % 60;
        if (seconds < 10) { Timer_sec = "0"+seconds.ToString(); }
        else
        {
            Timer_sec = seconds.ToString();
        }
        Timer_min = minutes.ToString();
        
       
        Last_time.text = Timer_min + ":" + Timer_sec;
        if (minutes == 0 && seconds == 0)
        {
            Game_over = true;
        }
    }
   private void Win()
    {
        SceneManager.LoadScene("Win");
    }
    private void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }
    void Start()
    {
        
            Time_Update(Time_Game);
            mood.sprite = grandmaMood[0];
            rage = 0;
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
            AUdio = GetComponent<AudioSource>();

            if (currentPatrolPoint.position.x < transform.position.x)
            {
                Flip();
            }
            else
            {
                speed = speed;
            }
            armComp.animation.Play("WalkGrandma");
            flag_move = false;
            flag_angry = false;
        
       
    }
    void Update()
    {
       
            if (!Game_over)
            {
                Time_Game -= Time.deltaTime;
                Time_Update(Time_Game);

                if (trys)
                {
                    if (armComp.animation.isPlaying)
                    {
                        armComp.animation.Stop("MakeSmtGrandma");
                        armComp.animation.Stop("WalkGrandma");
                    }
                    boy = for_boy.GetComponent<BoyMove>();
                    if (!armComp.animation.isPlaying)
                    {
                        //КОНЕЦ ИГРЫ - ВЫ ПРОИГРАЛИ

                        armComp.animation.Play("AngryGrandma");
                        AUdio.PlayOneShot(voice[0]);
                    }
                    boy.is_game_over = true;

                }
                else
                {
                    if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .35f)
                    {
                        if (currentInterObjScript.isAlreadyUsed && !currentInterObjScript.isAlreadyCheck && currentIntObj != null)
                        {
                            if (!flag_angry)
                            {
                              //Здесь она увидит испорченную вещь
                                rage++;
                                rage_slider.value = rage / maxRage;
                                if (count_of_mood == 4) { count_of_mood = 3; }
                                mood.sprite = grandmaMood[count_of_mood];
                                count_of_mood++;
                                last_time = Time.time + 4;
                                if (rage == maxRage)
                                { //КОНЕЦ ИГРЫ - ВЫ ВЫИГРАЛИ}

                                    gamewin.instance.isEndGame();
                                    Invoke("Win", 2f);
                                }

                            }
                            if (Time.time <= last_time)
                            {
                                if (armComp.animation.isPlaying)
                                {
                                    armComp.animation.Stop("MakeSmtGrandma");
                                    armComp.animation.Stop("WalkGrandma");
                                }
                                if (!armComp.animation.isPlaying)
                                {

                                    armComp.animation.Play("AngryGrandma");
                                    AUdio.PlayOneShot(voice[0]);
                                }
                                flag_angry = true;
                            }
                            else
                            {
                                AUdio.PlayOneShot(voice[1]);
                                currentInterObjScript.isAlreadyCheck = true;
                                currentInterObjScript.changed();
                                flag_angry = false;
                            }
                        }
                        else
                        {
                            if (flag_move == false)
                            {
                                last_time = Time.time + 4;
                            }
                            if (Time.time <= last_time)
                            {
                                if (armComp.animation.isPlaying)
                                {
                                    armComp.animation.Stop("AngryGrandma");
                                    armComp.animation.Stop("WalkGrandma");
                                }
                                if (!armComp.animation.isPlaying)
                                {
                                    armComp.animation.Play("MakeSmtGrandma");
                                }
                                flag_move = true;

                            }
                            else
                            {
                                flag_move = false;
                                armComp.animation.Play("WalkGrandma");
                                GoToAnotherPatrol();
                                Flip();
                            }
                        }
                    }
                    else
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * speed);
                    }
                }

            }
            else
            { //Здесь будет игра окончена
            if (armComp.animation.isPlaying)
            {
                armComp.animation.Stop("MakeSmtGrandma");
                armComp.animation.Stop("WalkGrandma");
            }
            if (!armComp.animation.isPlaying)
            {

                armComp.animation.Play("AngryGrandma");
            }
                Invoke("Lose", 2f);
                Debug.Log("GameOver is true");
            }
        
    }
    void GoToAnotherPatrol()
    {
        if (currentPatrolIndex + 1 < patrolPoints.Length)
        {
            currentPatrolIndex++;
        }
        else
        {
            currentPatrolIndex = 0;
        }
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        Debug.Log(currentPatrolIndex.ToString());
    }
    void Flip()
    {
        Debug.Log("count2");

        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        
        if (currentPatrolPoint.position.x < transform.position.x)
        {
            Debug.Log("count");
            speed = -speed;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else
        {
            if (currentPatrolIndex==1)
            {
                speed = -speed;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        }
  public  void changePos(UnityEngine.Transform a, bool range)
    {
        transform.position = a.position;
        if (range == true)
        {
            Vector3 theScale = transform.localScale;
            speed = -speed;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    public void they_are_here()
    {
        trys = true;
    }   
  }
