using UnityEngine;
using UnityEngine.UI;

namespace MenuRealization
{
    public class HpBarController : MonoBehaviour
    {
        public Text Hp;
        private int _hitPoints = 100;

        public int HitPoints
        {
            get { return _hitPoints; }
            set { _hitPoints = value; }
        }

        public void RecalculateHitPoints(int damage)
        {
            _hitPoints -= damage;
            Hp.text = _hitPoints.ToString();
        }
    }
}