using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour {

    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    public static int ThisID;
    public static string CharacterName = "";
    public static int Age { get; set; }
    public static bool TalkingOpportunity { get; set; }
    public static bool DirectionOpportunity { get; set; }

    public static PlayerMainScript.genderEnum Gender { get; set; }
    public static PlayerMainScript.raceEnum Race { get; set; }
    public static PlayerMainScript.classEnum Class { get; set; }
    public static PlayerMainScript.statusEnum Status { get; set; }

    public static uint CurrentHealth { get; set; }
    public static uint MaxHealth { get; set; }
    public static uint CurrentMana { get; set; }
    public static uint MaxMana { get; set; }
    public static float CurrentAttackSpeed { get; set; }
    public static uint CurrentDamage { get; set; }

    public static uint CurrentExperience { get; set; }
    public static uint ExperienceForUp { get; set; }
    public static uint CurrentLevel { get; set; }

    public static int Strength { get; set; }
    public static int Intelligence { get; set; }
    public static int Agility { get; set; }

    public static uint Gold { get; set; }
}
