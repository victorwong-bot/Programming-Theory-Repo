using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE (child)
public class HumanPlayer : Player
{
    private float speedModiflier = 1.0f;
    
    // POLYMORPHISM
    public override void Move(float humanSpeed, float humanRotateSpeed)
    {
        humanSpeed = base.m_speed * speedModiflier;
        humanRotateSpeed = base.m_rotateSpeed * speedModiflier;
        base.Move(humanSpeed, humanRotateSpeed);
    }
    
    // POLYMORPHISM
    public override string GetName()
    {
        return "Human Team";
    }

    // POLYMORPHISM
    public override Color GetColor()
    {
        return new Color (255, 0, 0);
    }
}
