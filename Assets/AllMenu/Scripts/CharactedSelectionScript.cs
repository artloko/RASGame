using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CharactedSelectionScript : MonoBehaviour {

    public GameObject panelNext;
    public GameObject panelPrev;
    public GameObject modelsView;
    public Text infoText;
    private List<GameObject> models;
    private MagicalCharacter Player;
    private List<PlayerMainScript.classEnum> classes;
    private List<PlayerMainScript.genderEnum> genders;
    private List<PlayerMainScript.raceEnum> races;
    private int selectionIndex = 0;
    private PlayerMainScript.genderEnum Gender = PlayerMainScript.genderEnum.Unknown;
    private PlayerMainScript.raceEnum Race = PlayerMainScript.raceEnum.Unknown;
    private PlayerMainScript.classEnum Class = PlayerMainScript.classEnum.Unknown;
    private string Name = "<UNKNOWN>";

    private int startStrength;
    private int startIntelligence;
    private int startAgility;

    private int strength;
    private int intelligence;
    private int agility;

    public Text strengthText;
    public Text intelligenceText;
    public Text agilityText;
    

    private int pointsToSpend = 10;
    public Text pointsText;

    public InputField wrongCreating;

    private void Start()
    {
        LoadInfo.LoadAllInfo();
        selectionIndex = PlayerPrefs.GetInt("CharacterSelected");
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        pointsText.text = pointsToSpend.ToString();
        models[selectionIndex].SetActive(true);
    }

    private void Update()
    {

    }
    public void SelectModel(int index)
    {
        Debug.Log(selectionIndex);
        Debug.Log(models.Count);
        if (index < 0 || index >= models.Count)
            return;
        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);
        //if (selectionIndex >= 0 && selectionIndex < 4)
        //    Gender = PlayerMainScript.genderEnum.Female;
        //else if (selectionIndex >= 4 && selectionIndex < 8)
        //    Gender = PlayerMainScript.genderEnum.Male;
        if (selectionIndex == 1)
            Gender = PlayerMainScript.genderEnum.Female;
        else if (selectionIndex == 0)
            Gender = PlayerMainScript.genderEnum.Male;
    }
    public void SelectRace(int index)
    {
        Race = (PlayerMainScript.raceEnum)index;
    }
    public void SelectClass(int index)
    {
        Class = (PlayerMainScript.classEnum)index;
        startStrength = strength = UnityEngine.Random.Range(1, 5);
        startIntelligence = intelligence = UnityEngine.Random.Range(1, 5);
        startAgility = agility = UnityEngine.Random.Range(1, 5);
        if (Class == PlayerMainScript.classEnum.Warrior)
            startStrength = strength += UnityEngine.Random.Range(1, 5);
        if (Class == PlayerMainScript.classEnum.Rogue)
            startAgility = agility += UnityEngine.Random.Range(1, 5);
        if (Class == PlayerMainScript.classEnum.Mage || Class == PlayerMainScript.classEnum.Priest)
            startIntelligence = intelligence += UnityEngine.Random.Range(1, 5);
        strengthText.text = strength.ToString();
        intelligenceText.text = intelligence.ToString();
        agilityText.text = agility.ToString();
        pointsText.text = pointsToSpend.ToString();
    }
    public void SelectName(string currName)
    {
        if (currName == "" || currName[0] == ' ' || currName.Length < 6)
            return;
        Name = currName;
    }

    public void setStrength(int amount)
    {
        if (Class != PlayerMainScript.classEnum.Unknown)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                strength++;
                pointsToSpend--;

            }
            else if (amount < 0 && strength > startStrength)
            {
                strength--;
                pointsToSpend++;
            }
            UpdateUI();
        }
    }
    public void setAgility(int amount)
    {
        if (Class != PlayerMainScript.classEnum.Unknown)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                agility++;
                pointsToSpend--;

            }
            else if (amount < 0 && agility > startAgility)
            {
                agility--;
                pointsToSpend++;
            }
            UpdateUI();
        }
    }
    public void setIntelligence(int amount)
    {
        if (Class != PlayerMainScript.classEnum.Unknown)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                intelligence++;
                pointsToSpend--;

            }
            else if(amount < 0 && intelligence > startIntelligence)
            {
                intelligence--;
                pointsToSpend++;
            }
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        strengthText.text = strength.ToString();
        agilityText.text = agility.ToString();
        intelligenceText.text = intelligence.ToString();
        pointsText.text = pointsToSpend.ToString();
    }

    public void CreateButton()
    {
        if (Gender == PlayerMainScript.genderEnum.Unknown || Race == PlayerMainScript.raceEnum.Unknown
            || Class == PlayerMainScript.classEnum.Unknown || Name == "<UNKNOWN>")
        {
            wrongCreating.text = "WRONG";
            return;
        }

        Player = new MagicalCharacter(Name, Race, Class, Gender,
            strength, intelligence, agility);
        
        GameInfo.ThisID = Player.ThisID;
        GameInfo.CharacterName = Player.CharacterName;
        GameInfo.Age = Player.Age;
        GameInfo.TalkingOpportunity = Player.TalkingOpportunity;
        GameInfo.DirectionOpportunity = Player.DirectionOpportunity;
        GameInfo.Gender = Player.Gender;
        GameInfo.Race = Player.Race;
        GameInfo.Class = Player.Class;
        GameInfo.Status = Player.Status;
        GameInfo.CurrentDamage = Player.CurrentDamage;
        GameInfo.CurrentAttackSpeed = Player.CurrentAttackSpeed;
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

        
        panelPrev.SetActive(true);
        panelNext.SetActive(false);

        SaveInfo.SaveAllInfo();
        isCreated();
    }


    public void LoadStuff()
    {
        PlayerPrefs.SetInt("CharacterSelected", selectionIndex);
        LoadInfo.LoadAllInfo();
        if (GameInfo.CharacterName != "")
            SceneManager.LoadScene("MainCityScene");
    }
        
    public void Create()
    {
        if (GameInfo.CharacterName == "")
        {
            modelsView.SetActive(true);
            panelPrev.SetActive(false);
            panelNext.SetActive(true);
        }
    }

    public void Delete()
    {
        infoText.text = "";
        GameInfo.CharacterName = "";
        Gender = PlayerMainScript.genderEnum.Unknown;
        Race = PlayerMainScript.raceEnum.Unknown;
        Class = PlayerMainScript.classEnum.Unknown;
        Name = "<UNKNOWN>";
        modelsView.SetActive(false);
        SaveInfo.SaveAllInfo();
    }

    public void isCreated()
    {
        LoadInfo.LoadAllInfo();
        if (GameInfo.CharacterName != "")
        {
            modelsView.SetActive(true);

            infoText.text = String.Format("The Character's ID is: {0}\n" + "The character's Name is: {1}\n"
            + "The character's Age is: {2}\n" + "The character's Gender is: {3}\n" + "The character's Race is: {4}\n"
            + "The character's Class is: {5}\n" + "The character's Status is: {6}\n" + "The character's Strength is: {7}\n"
            + "The character's Intelligence is: {8}\n" + "The character's Agility is: {9}\n"
            + "The character's current Health is: {10}\\{11}\n" + "The character's current Mana is: {12}\\{13}\n" 
            + "The character's current Experience is: {14}\\{15}\n"
            + "The character's Level is: {16}\n" + "The character's Gold is: {17}\n" + "The character's Damage is: {18}\n" + "The character's Attack Speed is: {19}\n",
            GameInfo.ThisID, GameInfo.CharacterName, GameInfo.Age, GameInfo.Gender, 
            GameInfo.Race, GameInfo.Class, GameInfo.Status, GameInfo.Strength, 
            GameInfo.Intelligence, GameInfo.Agility, GameInfo.CurrentHealth,
            GameInfo.MaxHealth, GameInfo.CurrentMana, GameInfo.MaxMana ,GameInfo.CurrentExperience, GameInfo.ExperienceForUp, 
            GameInfo.CurrentLevel, GameInfo.Gold, GameInfo.CurrentDamage, GameInfo.CurrentAttackSpeed);
        }
    }
}