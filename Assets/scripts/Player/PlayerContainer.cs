using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerContainer : MonoBehaviour
    {
        public string WhoAmI;
        public float HitPoints;
        public List<ActionContainer> Actions;
    }
}