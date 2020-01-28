using System.Collections;
using SkillButtonSystem;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerContainer PlayerContainer;

        private bool _cooldown;
        private SkillButtonFactory _buttonFactory = new SkillButtonFactory();

        public void DrawActionButton(SkillButtonContainer sbc)
        {
            GameObject skillButton = Create(_buttonFactory, sbc);
            Debug.Log(skillButton);
            skillButton.transform.SetParent(PlayerContainer.Canvas.transform);
            StartCoroutine(ButtonAwailable(skillButton,sbc.AwailableTime));
            _cooldown = true;
            StartCoroutine(Cooldown(sbc.Cooldown));
        }

        private GameObject Create(IFactory factory, SkillButtonContainer sbc)
        {
            return factory.Create(sbc);
        }

        private IEnumerator ButtonAwailable(GameObject button, float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(button);
        }

        private IEnumerator Cooldown(float time)
        {
            yield return new WaitForSeconds(time);
            _cooldown = false;
        }
    }
}
