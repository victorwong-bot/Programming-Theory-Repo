using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE (child)
public class AnimalPlayer : Player
{
    private float speedModiflier = 3.0f;
    
    // POLYMORPHISM
    public override void Move(float aniSpeed, float aniRotateSpeed)
    {
        aniSpeed = base.m_speed * speedModiflier;
        aniRotateSpeed = base.m_rotateSpeed * speedModiflier;
        base.Move(aniSpeed, aniRotateSpeed);
    }

    // POLYMORPHISM
    public override string GetName()
    {
        return "Animal Team";
    }

    // POLYMORPHISM
    public override Color GetColor()
    {
        return new Color (0, 0, 255);
    }


}
