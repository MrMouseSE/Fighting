using Player;
using UnityEngine;
using UnityEngine.UI;

public class HitSystemController : MonoBehaviour
{
    public PlayerController PlayerController;
    public PlayerController EnemyController;

    public Text PlayerHitpoints;
    public Text EnemyHitpoints;
    
    public void CheckAction(string whoDoThis, ActionContainer.ActionIndex actionIndex)
    {
        PlayerController attacker;
        PlayerController defender;
        
        if (whoDoThis == "enemy")
        {
            attacker = EnemyController;
            defender = PlayerController;
        }
        else if (whoDoThis == "player")
        {
            attacker = PlayerController;
            defender = EnemyController;
        }
        else
        {
            Debug.Log("kakoito pidor ebet logiky");
            return;
        }

        var action = attacker.FindActionByIndex(actionIndex);
        if (action != null)
        {
            HitCheck(attacker, defender, action);
        }
    }

    private void HitCheck(PlayerController attacker, PlayerController defender, ActionContainer action)
    {
        attacker.DoAction(action);
        defender.GetHit(action);
    }

    private void Update()
    {
        UpdateHitpointCount(EnemyHitpoints, EnemyController.PlayerContainer.HitPoints);
        UpdateHitpointCount(PlayerHitpoints, PlayerController.PlayerContainer.HitPoints);
    }

    private void UpdateHitpointCount(Text textFieldToUpdate, float currentHitpoint)
    {
        textFieldToUpdate.text = "hits: " + currentHitpoint;
    }
}