using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour {

    #region Singleton
    public static SpellBook instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    GameProcess gameProcess;
    PlayerController playerController;

    public Image[] skillButtons;


    public Text textHP;

    AddHealth addHealth;
    Heal heal;
    Antidote antidote;
    Revitalization revitalization;
    Armor armor;
    TakeOff takeOff;
    List<Spell> spellBook = new List<Spell>();

	// Use this for initialization
	void Start () {
        gameProcess = GameProcess.instance;
        playerController = gameProcess.PlayerObj.GetComponent<PlayerController>();

        addHealth = new AddHealth();
        heal = new Heal();
        antidote = new Antidote();
        revitalization = new Revitalization();
        armor = new Armor();
        takeOff = new TakeOff();
        spellBook.Add(addHealth);
        spellBook.Add(heal);
        spellBook.Add(antidote);
        spellBook.Add(revitalization);
        spellBook.Add(armor);
        spellBook.Add(takeOff);

        foreach(Image check in skillButtons)
        { 
            check.enabled = false;
        }
    }

    public void AddToSpellBook(int index)
    {
        if (skillButtons[index].enabled == false)
            skillButtons[index].enabled = true;
    }

    public void RemoveFromSpellBook(int index)
    {
        if (skillButtons[index].enabled == true)
            skillButtons[index].enabled = false;
    }

    public void UseSkill(int index)
    {
        if (skillButtons[index].enabled)
        {
            if (playerController.focus == null || playerController.focus is EnemyNPC)
            {
                if (index == 0)
                {
                    if (playerController.focus == null)
                        spellBook[index].Magically(gameProcess.Player, gameProcess.Player, Convert.ToUInt32(textHP.text));
                    else
                        spellBook[index].Magically(gameProcess.Player, (playerController.focus as EnemyNPC).enemy, Convert.ToUInt32(textHP.text));
                }
                else
                {
                    if (playerController.focus == null)
                        spellBook[index].Magically(gameProcess.Player, gameProcess.Player);
                    else
                        spellBook[index].Magically(gameProcess.Player, (playerController.focus as EnemyNPC).enemy);
                }
            }
        }
    }

}
