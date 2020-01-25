using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerContainer PlayerContainer;

        [Space]
        public HitSystemController _HitSystemController;

        public string WhoAmI;

        private ActionContainer _block;
        
        private ActionContainer.ActionIndex _action;
        private bool _cooldown = false;

        public bool Cooldown
        {
            get { return _cooldown; }
            set { _cooldown = value; }
        }

        public void CheckPlayerAction(int actionIndex)
        {
            switch (actionIndex)
            {
                case 1:
                    _action = ActionContainer.ActionIndex.UpperRightHit;
                    break;
                case 2:
                    _action = ActionContainer.ActionIndex.LowerRightHit;
                    break;
                case 3:
                    _action = ActionContainer.ActionIndex.UpperLeftHit;
                    break;
                case 4:
                    _action = ActionContainer.ActionIndex.LowerLeftHit;
                    break;
                case 5:
                    _action = ActionContainer.ActionIndex.RightBlock;
                    break;
                case 6:
                    _action = ActionContainer.ActionIndex.LeftBlock;
                    break;
                default:
                    _action = ActionContainer.ActionIndex.Empty;
                    break;
            }

            _HitSystemController.CheckAction(WhoAmI, _action);
        }

        
        
        // KAKAYA TO HUITA
        public void HitAction(ActionContainer action)
        {
            if (_cooldown || action == null) return;
            _cooldown = true;
            
            StartCoroutine(StartCooldown(action.Cooldown));
        }

        public void BlockAction(ActionContainer action)
        {
            if(action.ActionName.ToString().Contains("Block")) _block = action;
            if (_block != null)
            {
                if (_block.ActionSide == action.ActionSide)
                {
                    PlayerContainer.HitPoints -= action.Damage / 10;   
                }
            }
            PlayerContainer.HitPoints -= action.Damage;
            
            StartCoroutine(StartCooldown(action.Cooldown));
        }
        //
        
        private IEnumerator StartCooldown(float time)
        {
            yield return new WaitForSeconds(time);
            _cooldown = false;
            _block = null;
        }

        public ActionContainer FindActionByIndex(ActionContainer.ActionIndex actionIndex)
        {
            return PlayerContainer.Actions.Find((x) => x.ActionName == actionIndex);
        }
    }
}