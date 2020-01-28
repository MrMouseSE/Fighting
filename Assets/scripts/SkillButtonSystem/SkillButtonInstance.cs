using UnityEngine;

namespace SkillButtonSystem
{    
    [CreateAssetMenu(fileName = "SkillButton", menuName = "CreateSkillButtonContainer", order = 1)]
    public class SkillButtonInstance:ScriptableObject
    {
        [SerializeField]
        public string Name;

        [SerializeField]
        public SkillButtonContainer.SkillButtonType Type;

        [SerializeField]
        public Sprite Icon;

        [SerializeField]
        public float Damage;

        [SerializeField]
        public float Resist;

        [SerializeField]
        public float Cooldown;
        
        [SerializeField]
        public float AwailableTime;
    }
}