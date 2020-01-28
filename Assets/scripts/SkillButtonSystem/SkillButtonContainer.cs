using UnityEngine;

namespace SkillButtonSystem
{
    public class SkillButtonContainer
    {
        public enum SkillButtonType
        {
            Idle = 0,
            Attack = 1,
            Block = 2
        }

        private string _name;
        private SkillButtonType _type;
        private Sprite _icon;
        private float _damage;
        private float _resist;
        private float _cooldown;
        private float _awailableTime;
        
        public string Name => _name;
        public SkillButtonType Type => _type;
        public Sprite Icon => _icon;
        public float Damage => _damage;
        public float Resist => _resist;
        public float Cooldown => _cooldown;
        public float AwailableTime => _awailableTime;

        public SkillButtonContainer(SkillButtonInstance obj)
        {
            _name = obj.Name;
            _type = obj.Type;
            _icon = obj.Icon;
            _damage = obj.Damage;
            _resist = obj.Resist;
            _cooldown = obj.Cooldown;
            _awailableTime = obj.AwailableTime;
        }

        public SkillButtonContainer(string name, SkillButtonType type, Sprite icon, float damage, float resist,
            float cooldown, float awailableTime)
        {
            _name = name;
            _type = type;
            _icon = icon;
            _damage = damage;
            _resist = resist;
            _cooldown = cooldown;
            _awailableTime = awailableTime;
        }
    }
}