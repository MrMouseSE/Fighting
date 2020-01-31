using System.Collections.Generic;
using UnityEngine;

namespace MenuRealization
{
    public class CanvasController : MonoBehaviour
    {
        private static List<ButtonController> _buttons;

        public List<ButtonController> Buttons;
        

        private void Awake()
        {
            _buttons = Buttons;
            Subscribe();
        }

        private static void Subscribe()
        {
            ButtonController.ButtonPressed += GetNewButton;
            ButtonController.ButtonPressed += ActionResult;
        }

        private static void ActionResult(ButtonContainer buttonContainer)
        {
            
        }

        private static void GetNewButton(ButtonContainer buttonContainer)
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

        private static void DrawNextButton(ButtonType buttonType)
        {
            foreach (var button in _buttons)
            {
                if (button.Container.ByttonType == buttonType)
                {
                    button.ButtonAppear();
                }
            }
        }
    }
}