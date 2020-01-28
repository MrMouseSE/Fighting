using System.Collections;
using SkillButtonSystem;
using UnityEngine;

namespace Player
{
    public class EnemyBeheviour : MonoBehaviour
    {
        public ActionController controller;
        private void Start()
        {
            Action();
        }

        private void Action()
        {
            SkillButtonInstance action = ChoseAction();
            controller.Action(action.Type);
            StartCoroutine(DelayAfterAction(action.Cooldown));
        }

        private IEnumerator DelayAfterAction(float time)
        {
            yield return new WaitForSeconds(time);
            Action();
        }

        private SkillButtonInstance ChoseAction()
        {
            SkillButtonStore sbs = GetComponent<PlayerContainer>().SkillStore;

            SkillButtonInstance sbc = sbs.SkillButtons[Random.Range(1, 3)];

            return sbc;
        }
    }
}