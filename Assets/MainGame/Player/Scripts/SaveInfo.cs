using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveInfo : MonoBehaviour {

    public static void SaveAllInfo()
    {
        PlayerPrefs.SetString("PLAYERNAME", GameInfo.CharacterName);
        PlayerPrefs.SetInt("PLAYERID", GameInfo.ThisID);
        PlayerPrefs.SetInt("PLAYERAGE", GameInfo.Age);
        PlayerPrefs.SetInt("PLAYERTO", Convert.ToInt32(GameInfo.TalkingOpportunity));
        PlayerPrefs.SetInt("PLAYERDO", Convert.ToInt32(GameInfo.DirectionOpportunity));
        PlayerPrefs.SetInt("PLAYERGENDER", (int)GameInfo.Gender);
        PlayerPrefs.SetInt("PLAYERRACE", (int)GameInfo.Race);
        PlayerPrefs.SetInt("PLAYERCLASS", (int)GameInfo.Class);
        PlayerPrefs.SetInt("PLAYERSTATUS", (int)GameInfo.Status);
        PlayerPrefs.SetInt("PLAYERDMG", Convert.ToInt32(GameInfo.CurrentDamage));
        PlayerPrefs.SetFloat("PLAYERATCSPD", GameInfo.CurrentAttackSpeed);
        PlayerPrefs.SetInt("PLAYERHP", Convert.ToInt32(GameInfo.CurrentHealth));
        PlayerPrefs.SetInt("PLAYERMAXHP", Convert.ToInt32(GameInfo.MaxHealth));
        PlayerPrefs.SetInt("PLAYERMP", Convert.ToInt32(GameInfo.CurrentMana));
        PlayerPrefs.SetInt("PLAYERMAXMP", Convert.ToInt32(GameInfo.MaxMana));
        PlayerPrefs.SetInt("PLAYEREXP", Convert.ToInt32(GameInfo.CurrentExperience));
        PlayerPrefs.SetInt("PLAYEREXPFORUP", Convert.ToInt32(GameInfo.ExperienceForUp));
        PlayerPrefs.SetInt("PLAYERLVL", Convert.ToInt32(GameInfo.CurrentLevel));
        PlayerPrefs.SetInt("PLAYERGOLD", Convert.ToInt32(GameInfo.Gold));
        PlayerPrefs.SetInt("PLAYERSTR", GameInfo.Strength);
        PlayerPrefs.SetInt("PLAYERINT", GameInfo.Intelligence);
        PlayerPrefs.SetInt("PLAYERAGIL", GameInfo.Agility);


    }
}
