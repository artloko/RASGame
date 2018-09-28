using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour, IComparable
{

    #region Data
    static private int idCount = 0;
    public enum genderEnum { Male, Female, Unknown };
    public enum statusEnum { Normal, Weakened, Ill, Paralyzed, Dead };
    public enum raceEnum { Gnome, Human, Ork, Undead, Unknown };
    public enum classEnum { Mage, Priest, Rogue, Warrior, Unknown };

    public readonly int ThisID;
    public readonly string CharacterName;
    public int Age { get; set; }
    public bool TalkingOpportunity { get; set; }
    public bool DirectionOpportunity { get; set; }
    public bool isInvulnerability { get; set; }

    public readonly genderEnum Gender;
    public readonly raceEnum Race;
    public readonly classEnum Class;
    public statusEnum Status { get; set; }

    private uint currentHealth;
    public uint MaxHealth { get; set; }
    public uint CurrentExperience { get; set; }
    public uint ExperienceForUp { get; set; }
    public uint CurrentLevel { get; set; }
    public uint CurrentDamage { get; set; }
    public float CurrentAttackSpeed { get; set; }

    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }
    
    public uint Gold { get; set; }
    
    

    #endregion

    public PlayerMainScript(string currName, raceEnum currRace, classEnum currClass, genderEnum currGender,
        int currStrength, int currIntelligence, int currAgility)
    {
        TalkingOpportunity = DirectionOpportunity = true;
        isInvulnerability = false;
        ThisID = idCount++;
        CharacterName = currName;
        Race = currRace;
        Gender = currGender;
        Class = currClass;
        Age = UnityEngine.Random.Range(20, 30);
        Strength = currStrength;
        Intelligence = currIntelligence;
        Agility = currAgility;
       
        MaxHealth = Convert.ToUInt32(100.0f * (1.0 + Convert.ToDouble(Strength) / 10));
        Gold = Convert.ToUInt32(300.0f * (1.0 + Convert.ToDouble(Agility) / 10));
        CurrentHealth = MaxHealth;
        CurrentAttackSpeed = Convert.ToUInt32(100.0f * (1.0 + Convert.ToDouble(Agility) / 10));
        CurrentDamage = Convert.ToUInt32(10.0f * (1.0 + Convert.ToDouble(Strength) / 10));
        CurrentLevel = 1;
        CurrentExperience = 0;
        ExperienceForUp = Convert.ToUInt32(150.0f * 1.0 / (1.0 + Convert.ToDouble(Intelligence) / 10));
        Status = statusEnum.Normal;
    }

    #region Properties
    public uint CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value > MaxHealth)
                currentHealth = MaxHealth;
            else
                currentHealth = value;
            whatStatus();
        }
    }
    #endregion

    public int CompareTo(object obj)
    {
        if (!(obj is PlayerMainScript))
            throw new DataMisalignedException("Object is not a Player");
        PlayerMainScript otherPlayer = (PlayerMainScript)obj;
        return (otherPlayer.CurrentExperience.CompareTo(otherPlayer.CurrentExperience));
    }

    public void whatStatus()
    {
        if ((int)currentHealth <= 0)
        {
            Status = statusEnum.Dead;
        }
        if (Status == statusEnum.Paralyzed)
            return;
        if (Status == statusEnum.Normal && (float)currentHealth / (float)MaxHealth < 0.1f)
            Status = statusEnum.Weakened;
        else if (Status == statusEnum.Weakened && (float)currentHealth / (float)MaxHealth >= 0.1f)
            Status = statusEnum.Normal;
    }

    public void GetExperience(uint currExperience)
    {
        while (true)
        {
            if (CurrentExperience + currExperience >= ExperienceForUp)
            {
                uint temp = CurrentExperience;
                CurrentExperience = 0;
                CurrentLevel++;
                currExperience -= (ExperienceForUp - temp);
            }
            else
            {
                CurrentExperience += currExperience;
                return;
            }
        }
    }

    public void takeDamage(uint damage)
    {
        Debug.Log("Player takes" + damage + " damage.");
        if ((int)CurrentHealth - (int)damage <= 0)
            CurrentHealth = 0;
        else
            CurrentHealth -= damage;
    }
    

    public virtual string Info()
    {
        return String.Format("The Character's ID is: {0}\n" + "The character's Name is: {1}\n"
            + "The character's Age is: {2}\n" + "The character's Gender is: {3}\n" + "The character's Race is: {4}\n"
            + "The character's Class is: {5}\n" + "The character's Status is: {6}\n" + "The character's Strength is: {7}\n"
            + "The character's Intelligence is: {8}\n" + "The character's Agility is: {9}\n"
            + "The character's current Health is: {10}\\{11}\n" + "The character's current Experience is: {12}\\{13}\n"
            + "The character's Level is: {14}\n" + "The character's Gold is: {15}\n" + "The character's Damage is: {16}\n" + "The character's Attack Speed is: {17}\n",
            ThisID, CharacterName, Age, Gender, Race, Class, Status, Strength, Intelligence, Agility,
            CurrentHealth, MaxHealth, CurrentExperience, ExperienceForUp, CurrentLevel, Gold, CurrentDamage, CurrentAttackSpeed);
    }

}