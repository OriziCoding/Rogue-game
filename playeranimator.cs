using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimator : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool isMoving = pm.IsMoving();
        am.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            if (pm.GetMovementDirection().x > 0)
                sr.flipX = false;
            else if (pm.GetMovementDirection().x < 0)
                sr.flipX = true;
        }
    }
}
