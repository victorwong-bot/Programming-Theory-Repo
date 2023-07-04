using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPlayer : Player
{
    private float speedModiflier = 3.0f;
    
    public override void Move(float aniSpeed, float aniRotateSpeed)
    {
        aniSpeed = base.m_speed * speedModiflier;
        aniRotateSpeed = base.m_rotateSpeed * speedModiflier;
        base.Move(aniSpeed, aniRotateSpeed);
    }


}
