using System.Collections;
using Player;
using UnityEngine;

namespace AI
{
    public class AIController : MonoBehaviour
    {
        public Animator Animator;
        public PlayerController PlayerController;
        public AIVisualSignalSystem VisualSignalSystem;

        private int _actionIndex;

        private void Start()
        {
            _actionIndex = Animator.StringToHash("ActionIndex");
            NewActionStart();
        }

        private void NewActionStart()
        {
            if (PlayerController.Cooldown) StartCoroutine(DelayAfterAction(1f));
            
            PrepareToAction();
        }

        private void PrepareToAction()
        {
            var actionIndex = ChoseTheAction();
            VisualSignalSystem.PlaceAttackSignal(actionIndex);
            var time = 1f;
            StartCoroutine(DelayBeforeAction(time, actionIndex));
        }

        private int ChoseTheAction()
        {
            return Random.Range(1, 7);
        }

        private IEnumerator DelayBeforeAction(float time, int actionIndex)
        {
            yield return new WaitForSeconds(time);
            DoAction(actionIndex);
        }

        private void DoAction(int actionIndex)
        {
            Animator.SetInteger(_actionIndex, actionIndex);
            PlayerController.CheckPlayerAction(actionIndex);
            StartCoroutine(DelayAfterAction(1f));
        }

        private IEnumerator DelayAfterAction(float time)
        {
            yield return new WaitForSeconds(time);
            NewActionStart();
        }
    }
}