using System.Collections.Generic;
using UnityEngine;

namespace MenuRealization
{
    public class CanvasController : MonoBehaviour
    {
        public List<ButtonController> Buttons;

        private void Awake()
        {
        }

        public void GetNewButton(ButtonContainer buttonContainer)
        {
            var buttonType = buttonContainer.ByttonType;
            switch (buttonType)
            {
                    case ButtonType.BasicAttack:
                        DrawNextButton(ButtonType.AdvancedAttack);
                        break;
                    case ButtonType.AdvancedAttack:
                        DrawNextButton(ButtonType.SuperAttack);
                        break;
                    case ButtonType.BasicBlock:
                        DrawNextButton(ButtonType.AdvancedBlock);
                        break;
                    case ButtonType.SuperBlock:
                        DrawNextButton(ButtonType.SuperBlock);
                        break;
            }
        }

        private void DrawNextButton(ButtonType buttonType)
        {
            foreach (var button in Buttons)
            {
                if (button.Container.ByttonType == buttonType)
                {
                    button.ButtonAppear();
                }
            }
        }
    }
}