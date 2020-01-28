using UnityEngine;

namespace SkillButtonSystem
{
    interface IFactory
    {
        GameObject Create(SkillButtonContainer so);
    }
}