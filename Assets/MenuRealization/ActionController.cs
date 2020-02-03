using System.Collections;
using UnityEngine;

namespace MenuRealization
{
    public class ActionController : MonoBehaviour
    {
        public HpBarController PlayerHitPoints;
        public HpBarController EnemyHitPoints;
        
        
        private ButtonContainer _playerContainer;
        private ButtonContainer _enemyContainer;

        private Coroutine _actionWaiter;

        public void ActionToCalculate(ButtonContainer container, string whoAmI)
        {
            if (whoAmI == "player")
            {
                _playerContainer = container;
            }
            else
            {
                _enemyContainer = container;
            }
            
            if (_actionWaiter == null)
            {
                _actionWaiter = StartCoroutine(WaitActionReation(0.3f));
                return;
            }
            CalculateActionResult();
        }

        private void CalculateActionResult()
        {
            float playerDamage = 0;
            float playerResist = 0;
            float enemyDamage = 0;
            float enemyResist = 0;
            if (_playerContainer != null)
            {
                playerDamage = _playerContainer.Damage;
                playerResist = _playerContainer.Resist;
            }

            if (_enemyContainer != null)
            {
                enemyDamage = _enemyContainer.Damage;
                enemyResist = _enemyContainer.Resist;
            }
            
            PlayerHitPoints.RecalculateHitPoints((int)(enemyDamage - playerResist));
            EnemyHitPoints.RecalculateHitPoints((int)(playerDamage - enemyResist));
        }
        
        private IEnumerator WaitActionReation(float time)
        {
            yield return new WaitForSeconds(time);
            CalculateActionResult();
        }
    }
}