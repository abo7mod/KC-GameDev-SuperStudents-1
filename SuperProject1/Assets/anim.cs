using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    SpriteRenderer Sprite;
    bool FaceRight = true;


    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlip();
    }
    void PlayerFlip()
    {
        if (Input.GetKeyDown(KeyCode.D) && FaceRight == false)
        {
            Sprite.flipX = false;
            FaceRight = true;



        }
        else if (Input.GetKeyDown(KeyCode.A) && FaceRight == true)
        {
            Sprite.flipX = true;
            FaceRight = false;



        }


    }
}
