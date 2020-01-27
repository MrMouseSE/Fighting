using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionContainer: MonoBehaviour
{
    public enum CharacterActionType
    {
        Idle = 0,
        Hit = 1,
        Block = 3
    }

    public CharacterActionType ActionIndex;
    public float PrepareTime;
    public float Damage;
}