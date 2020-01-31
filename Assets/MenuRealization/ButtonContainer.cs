using UnityEngine;

namespace MenuRealization
{
    public class ButtonContainer : MonoBehaviour
    {
        public ButtonType ByttonType;
        public float CooldownTime;
        public float DisappearTime;
        public ButtonState DisableState;
        public ButtonState EnableState;
    }

    public enum ButtonType
    {
        Default = 0,
        BasicAttack = 1,
        AdvancedAttack = 2,
        SuperAttack = 3,
        BasicBlock = 4,
        AdvancedBlock = 5,
        SuperBlock = 6
    }

    public class ButtonState
    {
        public Color BackColor;
    }
}