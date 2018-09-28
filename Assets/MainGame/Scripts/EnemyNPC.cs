using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyNPC : Interactable
{

    GameProcess gameProcces;
    public PlayerMainScript enemy;



    void Start()
    {
        gameProcces = GameProcess.instance;
        enemy = new PlayerMainScript("Warrior", PlayerMainScript.raceEnum.Human, PlayerMainScript.classEnum.Warrior, PlayerMainScript.genderEnum.Female,
             Convert.ToInt32(gameProcces.Player.Strength * 0.8f), Convert.ToInt32(gameProcces.Player.Intelligence * 0.8f), 
             Convert.ToInt32(gameProcces.Player.Agility * 0.4f));
        enemy.Status = PlayerMainScript.statusEnum.Ill;
    }
    

    public override void Interact()
    {
        base.Interact();
        Combat combat = gameProcces.PlayerObj.GetComponent<Combat>();
        if (combat != null)
        {
            combat.Attack(enemy);
        }
    }


    
}
