using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_X = -2.6f,max_X = 2.6f,min_Y = -5.6f;

    private bool Out_of_Bounds;
    void Update()
    {
        CheckBounds();
    }

    
    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if(temp.x > max_X)
        temp.x = max_X;

        if(temp.x < min_X)
        temp.x = min_X;

        transform.position = temp;

        if(temp.y <= min_Y)
        {
        if(!Out_of_Bounds)
        {
            Out_of_Bounds = true;

            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
        }

    }

    void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f,1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
