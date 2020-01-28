using System.Collections.Generic;
using UnityEngine;

namespace SkillButtonSystem
{
    [CreateAssetMenu(fileName = "SkillButtonsStore", menuName = "CreateSkillButtonsStore", order = 1)]
    public class SkillButtonStore : ScriptableObject
    {
        [SerializeField]
        public List<SkillButtonInstance> SkillButtons;

        public SkillButtonInstance FindSkillByName(string name)
        {
            SkillButtonInstance sbc = SkillButtons.Find((x) => x.Name == name);

            return sbc;
        }
    }
}