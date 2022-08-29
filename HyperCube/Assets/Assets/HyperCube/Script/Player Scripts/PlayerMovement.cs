using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D myBody;
   [SerializeField]
   private AudioSource soundFX;

   public float movespeed = 2f;

   public Joystick joystick;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();        
    }
    void Move()
    {
    
        if(joystick.Horizontal > 0f)
        {
             myBody.velocity = new Vector2(movespeed, myBody.velocity.y);
        }

        if(joystick.Horizontal < 0f)
        {
            myBody.velocity = new Vector2(-movespeed, myBody.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x ,myBody.velocity.y);
    }


    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("TopSpike"))
        {
            Destroy(gameObject);
            soundFX.Play();
            SceneManager.LoadScene("GameOver");
        }
    }
}
