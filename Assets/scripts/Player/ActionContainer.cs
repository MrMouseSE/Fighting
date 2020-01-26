using UnityEngine;

namespace Player
{
    public class ActionContainer : MonoBehaviour
    {
        public enum Side
        {
            Left = 0,
            Right = 1
        }
        
        public enum ActionIndex
        {
            Empty = 0,
            UpperRightHit = 1,
            LowerRightHit = 2,
            UpperLeftHit = 3,
            LowerLeftHit = 4,
            RightBlock = 5,
            LeftBlock = 6
        }
        
        public ActionIndex ActionName;
        public float Cooldown;
        public float Damage;
        public Side ActionSide;
    }
}