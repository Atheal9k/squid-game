using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdowntime : MonoBehaviour {

      [SerializeField] private Text uiText;
      [SerializeField] private float mainTimer;

      private float timer;
      private bool canCount = true;
      private bool doOnce = false;

      void Start()
      {
          timer = mainTimer;
      }

      void Update()
      {
          if (timer >= 00.00f && canCount)
          {
              timer -= Time.deltaTime;
            
            string minutes = Mathf.Floor((timer % 3600) / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            uiText.text = minutes + ":" + seconds;

        }
            
      //    if (timer > 00.50f)
      //  {

      //      uiText.text = timer.ToString("18:00");

            
       //     }
            
        

       

       /*else if (timer = 0.1f && !doOnce)
          {
              canCount = false;
              doOnce = true;

            
              uiText.text = "17:59";

          }   */
      }  


    /* public static float timer;
     public static bool timeStarted = false;

     void Update()
     {
         if (timeStarted == true)
         {
             timer += Time.deltaTime;
         }
     }

     void OnGUI()
     {
         int minutes = Mathf.FloorToInt(timer / 60F);
         int seconds = Mathf.FloorToInt(timer - minutes * 60);
         string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

         GUI.Label(new Rect(10, 10, 250, 100), niceTime);
     }

     */


    /* public Text time;
     float timer = 0f;

     void Update()
     {
         time += Time.deltaTime;

         int seconds = (int)(timer % 60);
         int minutes = (int)(timer / 60) % 60;

         string timeformat = string.Format("{1:00}:{2:00}", minutes, seconds);

         time.text = timeformat;
     }
     */


    /*   public class timer : MonoBehaviour
       {

           Text text;
           float theTime;
           public float speed = 1;
           bool playing;

           // Use this for initialization
           void Start()
           {
               text = GetComponent GetComponent<Text>();
           }

           // Update is called once per frame
           void Update()
           {
               if (playing == true)
               {
                   theTime += Time.deltaTime * speed;

                   string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
                   string seconds = (theTime % 60).ToString("00");
                   text.text = hours + ":" + minutes + ":" + seconds;
               }
           }
       }

       */

     /* public Text TimeText;
      public float TimeStamp;
      public bool UsingTimer = false;

      void Start()
      {
          SetTimer(1);
      }


      void Update()
      {
          if (UsingTimer)
              SetUIText();
      }

      public void SetTimer(float time)
      {
          if (UsingTimer)
              return;

          TimeStamp = Time.time + time;
          UsingTimer = true;
      }

      public void SetUIText()
      {
          float timeLeft = TimeStamp - Time.time;
          if(timeLeft <= 0)
          {

          }
          float hours;
          float minutes;
          float seconds;
          GetTimeValues(timeLeft, out hours, out minutes, out seconds);

          if (hours > 0)
              TimeText.text = string.Format("{0}:{1}", hours, minutes);
          else if (minutes > 0)
              TimeText.text = string.Format("{0}:{1}", minutes, seconds);
      }

      public void GetTimeValues(float time, out float hours, out float minutes, out float seconds)
      {
          hours = (int)(time / 3600f);
          minutes = (int)((time = hours * 3600) / 60f);
          seconds = (int)((time - hours * 3600 - minutes * 60));

      } */

    // For our timer we will use minutes and seconds
   /* public Text time;
    public float Seconds = 59;
       public float Minutes = 0;

       void Update()
       {
           // This is if statement checks how many seconds there are to decide what to do.
           // If there are more than 0 seconds it will continue to countdown.
           // If not then it will reset the amount of seconds to 59 and handle the minutes;
           // Handling the minutes is very similar to handling the seconds.
           if (Seconds <= 0)
           {
               Seconds = 59;
               if (Minutes >= 1)
               {
                   Minutes--;
               }
               else
               {
                   Minutes = 0;
                   Seconds = 0;
                // This makes the guiText show the time as X:XX. ToString.("f0") formats it so there is no decimal place.
                string timeformat = string.Format("{1:00}:{2:00}", Minutes, Seconds);

                time.text = timeformat;
            }
           }
           else
           {
               Seconds -= Time.deltaTime;
           }

          
       }  
       */

   /* public int seconds = 360;
    public int faltaPocoSeconds = 30;
    public int sinTempoSeconds = 5;

    public float accumulatedTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        accumulatedTime += Time.deltaTime;

        if(accumulatedTime >= 1.0f)
        {
            guiText.text = formatTime();
            seconds--;

           

            accumulatedTIme = 0;
        }
        
    }




    string formatTime()
    {
        int min = seconds / 60;
        int secs = seconds & 60;

        return min.ToString("D2") + ":" + secs.ToString("D2");
    } */
}




