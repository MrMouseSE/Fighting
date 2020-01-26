using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerContainer PlayerContainer;

        [Space]
        public HitSystemController HitSystemController;

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
            _action = (ActionContainer.ActionIndex) actionIndex;
            
            HitSystemController.CheckAction(PlayerContainer.WhoAmI, _action);
        }

        public void DoAction(ActionContainer action)
        {
            if (_cooldown) return;

            _block = (int) action.ActionName > 4 ? action : null;

            _cooldown = true;
            StartCoroutine(StartCooldown(action.Cooldown));
        }

        public void GetHit(ActionContainer action)
        {
            if (_block != null)
            {
                if (_block.ActionSide == action.ActionSide)
                {
                    PlayerContainer.HitPoints -= action.Damage / 10;
                    return;
                }
            }
            PlayerContainer.HitPoints -= action.Damage;
        }
        
        private IEnumerator StartCooldown(float time)
        {
            yield return new WaitForSeconds(time);
            _action = ActionContainer.ActionIndex.Empty;
            _cooldown = false;
            _block = null;
        }

        public ActionContainer FindActionByIndex(ActionContainer.ActionIndex actionIndex)
        {
            return PlayerContainer.Actions.Find((x) => x.ActionName == actionIndex);
        }
    }
}