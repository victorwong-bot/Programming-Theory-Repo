using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    private float speedModiflier = 1.0f;
    
    public override void Move(float humanSpeed, float humanRotateSpeed)
    {
        humanSpeed = base.m_speed * speedModiflier;
        humanRotateSpeed = base.m_rotateSpeed * speedModiflier;
        base.Move(humanSpeed, humanRotateSpeed);
    }

    public override string GetName()
    {
        return "Human Team";
    }

    public override Color GetColor()
    {
        return new Color (255, 0, 0);
    }
}
