using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MenuRealization
{
    public class ButtonController : MonoBehaviour
    {
        public ButtonContainer Container;
        public Button Button;
        
        private bool _cooldown;

        public delegate void ButtonPressedDelegate(ButtonContainer buttonContainer);
        public static event ButtonPressedDelegate ButtonPressed;

        public void OnButtonClick(bool hide)
        {
            ButtonDisable(Container.CooldownTime);
            if (ButtonPressed != null) ButtonPressed(Container);
            if (!hide) return;
            StartCoroutine(DisappearCounter(0.3f));
            
        }

        public void ButtonAppear()
        {
            Button.gameObject.SetActive(true);
            if (Container.DisappearTime > 0)
            {
                StartCoroutine(DisappearCounter(Container.DisappearTime));    
            }
        }

        public void ButtonDisappear()
        {
            Button.gameObject.SetActive(false);
        }

        public void ButtonDisable(float cooldown)
        {
            ChangeButtonState(false);
            _cooldown = true;
            StartCoroutine(CooldownCounter(cooldown));
        }

        public void ButtonEnable()
        {
            ChangeButtonState(true);
        }

        private void ChangeButtonState(bool state)
        {
            Button.interactable = state;
        }

        private IEnumerator CooldownCounter(float time)
        {
            yield return new WaitForSeconds(time);
            _cooldown = false;
            ButtonEnable();
        }

        private IEnumerator DisappearCounter(float time)
        {
            yield return new WaitForSeconds(time);
            ButtonDisappear();
        }
    }
}