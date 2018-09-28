using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour {

    #region Singleton
    public static GameProcess instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    
    public GameObject PlayerObj;
    public MagicalCharacter Player;
    public Text infoText;
    public Text HPText;
    public Text MPText;
    public Text EXPText;
    public Text GOLDText;
    public Image HealthBar;
    public Image ManaBar;
    public Image ExperienceBar;
    public GameObject ShieldIcon;

    public GameObject FemaleImage;
    public GameObject MaleImage;

    public void SaveGameProcess()
    {
        GameInfo.ThisID = Player.ThisID;
        GameInfo.CharacterName = Player.CharacterName;
        GameInfo.Age = Player.Age;
        GameInfo.TalkingOpportunity = Player.TalkingOpportunity;
        GameInfo.DirectionOpportunity = Player.DirectionOpportunity;
        GameInfo.Gender = Player.Gender;
        GameInfo.Race = Player.Race;
        GameInfo.Class = Player.Class;
        GameInfo.Status = Player.Status;
        GameInfo.CurrentHealth = Player.CurrentHealth;
        GameInfo.MaxHealth = Player.MaxHealth;
        GameInfo.CurrentMana = Player.CurrentMana;
        GameInfo.MaxMana = Player.MaxMana;
        GameInfo.CurrentExperience = Player.CurrentExperience;
        GameInfo.ExperienceForUp = Player.ExperienceForUp;
        GameInfo.CurrentLevel = Player.CurrentLevel;
        GameInfo.Strength = Player.Strength;
        GameInfo.Agility = Player.Agility;
        GameInfo.Intelligence = Player.Intelligence;
        GameInfo.Gold = Player.Gold;
        GameInfo.CurrentDamage = Player.CurrentDamage;
        GameInfo.CurrentAttackSpeed = Player.CurrentAttackSpeed;
        SaveInfo.SaveAllInfo();
    }

    public void LoadGameProcess()
    {
        LoadInfo.LoadAllInfo();
        Player.Age = GameInfo.Age;
        Player.Strength = GameInfo.Strength;
        Player.Intelligence = GameInfo.Intelligence;
        Player.Agility = GameInfo.Agility;
        Player.Gold = GameInfo.Gold;
        Player.CurrentDamage = GameInfo.CurrentDamage;
        Player.CurrentAttackSpeed = GameInfo.CurrentAttackSpeed;
        Player.CurrentHealth = GameInfo.CurrentHealth;
        Player.MaxHealth = GameInfo.MaxHealth;
        Player.CurrentMana = GameInfo.CurrentMana;
        Player.MaxMana = GameInfo.MaxMana;
        Player.CurrentLevel = GameInfo.CurrentLevel;
        Player.CurrentExperience = GameInfo.CurrentExperience;
        Player.ExperienceForUp = GameInfo.ExperienceForUp;
        Player.Status = GameInfo.Status;
        Player.TalkingOpportunity = GameInfo.TalkingOpportunity;
        Player.DirectionOpportunity = GameInfo.DirectionOpportunity;
    }

    void Start()
    {
        Player = new MagicalCharacter(GameInfo.CharacterName,
            GameInfo.Race, GameInfo.Class, GameInfo.Gender, GameInfo.Strength,
            GameInfo.Intelligence, GameInfo.Agility);
        if (Player.Gender == PlayerMainScript.genderEnum.Female)
            FemaleImage.SetActive(true);
        else
            MaleImage.SetActive(true);
        LoadGameProcess();
    }

    void Update()
    {
        infoText.text = Player.Info();
        HealthBar.fillAmount = Player.CurrentHealth * 1.0f / Player.MaxHealth * 1.0f;
        ManaBar.fillAmount = Player.CurrentMana * 1.0f / Player.MaxMana * 1.0f;
        ExperienceBar.fillAmount = Player.CurrentExperience * 1.0f / Player.ExperienceForUp * 1.0f;
        HPText.text = String.Format("{0}/{1}", Player.CurrentHealth, Player.MaxHealth);
        MPText.text = String.Format("{0}/{1}", Player.CurrentMana, Player.MaxMana);
        GOLDText.text = Player.Gold.ToString();
        //EXPText.text = String.Format("{0}%", Convert.ToDouble(Player.CurrentExperience) / Convert.ToDouble(Player.ExperienceForUp));
        Armor.time -= Time.deltaTime;
        if (Player.isInvulnerability)
            ShieldIcon.SetActive(true);
        if (Armor.time <= 0)
        {
            ShieldIcon.SetActive(false);
            Player.isInvulnerability = false;
        }
    }

    public void KillPlayer()
    {

    }

}
