using SkillButtonSystem;
using UnityEngine;

namespace Player
{
    public class ActionController : MonoBehaviour
    {
        public PlayerController PlayerController;

        public void Action(SkillButtonContainer.SkillButtonType sbt)
        {
            SkillButtonContainer sbc = null;
            switch (sbt)
            {
                case SkillButtonContainer.SkillButtonType.Attack:
                    sbc = new SkillButtonContainer(PlayerController.PlayerContainer.SkillStore.FindSkillByName("TestBlock"));
                    break;
                default:
                    sbc = new SkillButtonContainer(PlayerController.PlayerContainer.SkillStore.FindSkillByName("TestAttack"));
                    break;
            }
            
            PlayerController.DrawActionButton(sbc);
        }
    }
}
