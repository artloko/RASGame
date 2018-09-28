using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadInfo : MonoBehaviour {

    public static void LoadAllInfo()
    {
        GameInfo.CharacterName = PlayerPrefs.GetString("PLAYERNAME");
        GameInfo.ThisID = PlayerPrefs.GetInt("PLAYERID");
        GameInfo.Age = PlayerPrefs.GetInt("PLAYERAGE");
        GameInfo.TalkingOpportunity = Convert.ToBoolean(PlayerPrefs.GetInt("PLAYERTO"));
        GameInfo.DirectionOpportunity = Convert.ToBoolean(PlayerPrefs.GetInt("PLAYERDO"));
        GameInfo.Gender = (PlayerMainScript.genderEnum)PlayerPrefs.GetInt("PLAYERGENDER");
        GameInfo.Race = (PlayerMainScript.raceEnum)PlayerPrefs.GetInt("PLAYERRACE");
        GameInfo.Class = (PlayerMainScript.classEnum)PlayerPrefs.GetInt("PLAYERCLASS");
        GameInfo.Status = (PlayerMainScript.statusEnum)PlayerPrefs.GetInt("PLAYERSTATUS");
        GameInfo.CurrentAttackSpeed = PlayerPrefs.GetFloat("PLAYERATCSPD");
        GameInfo.CurrentDamage = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERDMG"));
        GameInfo.CurrentHealth = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERHP"));
        GameInfo.MaxHealth = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERMAXHP"));
        GameInfo.CurrentMana = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERMP"));
        GameInfo.MaxMana = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERMAXMP"));
        GameInfo.CurrentExperience = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYEREXP"));
        GameInfo.ExperienceForUp = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYEREXPFORUP"));
        GameInfo.CurrentLevel = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERLVL"));
        GameInfo.Gold = Convert.ToUInt32(PlayerPrefs.GetInt("PLAYERGOLD"));
        GameInfo.Strength = PlayerPrefs.GetInt("PLAYERSTR");
        GameInfo.Intelligence = PlayerPrefs.GetInt("PLAYERINT");
        GameInfo.Agility = PlayerPrefs.GetInt("PLAYERAGIL");

    }
}
