using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolutionOne : MonoBehaviour
{
    [Header("Character Sheet")]
    public string characterName;
    [Range(1,20)]
    public int level;
    [Range(1,30)]
    public int con;
    
    // establishes a drop down selection for race selection in Inspector
    public enum races 
    {
        Aasimar,
        Dragonborn, 
        Dwarf,
        Elf,
        Gnome,
        Goliath,
        Halfling,
        Human,
        Orc,
        Tiefling
    }
    public races race;
    
    // establishes a drop down selection for player class in Inspector
    public enum classes 
    {   Artificer,
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Ranger,
        Rogue,
        Paladin,
        Sorcerer,
        Wizard,
        Warlock
    }
    public classes playerClass;

    // establishes a drop down selection for hit point traits in Inspector
    public enum traitsHP 
    {
        None, 
        Stout, 
        Tough
    }
    public traitsHP trait;

    // establishes a drop down selection for how dice are treated in Inspector
    public enum diceBehavior {Averaged, Random};
    public diceBehavior dice;

    Dictionary<traitsHP, int> selectedTrait = new Dictionary<traitsHP, int>()
    {
        {traitsHP.None, 0},
        {traitsHP.Stout, 1}, 
        {traitsHP.Tough, 2}
    };

    // dictionary associates bonus hit points to player race
     Dictionary<races, int> selectedRace = new Dictionary<races, int>()
    {
        {races.Aasimar, 0},
        {races.Dragonborn, 0}, 
        {races.Dwarf, 2},
        {races.Elf, 0},
        {races.Gnome, 0},
        {races.Goliath, 1},
        {races.Halfling, 0},
        {races.Human, 0},
        {races.Orc, 1},
        {races.Tiefling, 0}
    };
    
    // dictionary associates hit dice to player class example: Artificer - D8
    Dictionary<classes, int> selectedClass = new Dictionary<classes, int>()
    {
       {classes.Artificer, 8},
       {classes.Barbarian, 12},
       {classes.Bard, 8},
       {classes.Cleric, 8},
       {classes.Druid, 8},
       {classes.Fighter, 10},
       {classes.Monk, 8},
       {classes.Ranger, 10},
       {classes.Rogue, 8},
       {classes.Paladin, 10},
       {classes.Sorcerer, 6},
       {classes.Wizard, 6},
       {classes.Warlock, 8}
    };

    //level * dice + conBonus * level + feat * level + race * level
    void Start()
    {
        int totalHP = RollSidedDie(level);
        finalHP(totalHP);
    }

    public int RollSidedDie(int level)
    {
        int loopNum;
        int totalHP = 0;

        for (loopNum=0; loopNum<level; loopNum++)
        {

            // Function that rolls die based on how many levels
            // loopNum counts how many times the loop runs
            // This loop stops when the players level is equal to loopNum
            // This loop adds 1 to loopNum after each run
            // This loop starts at 0
            // Class die type
            // Roll die Averaged
            // Roll die Rolled
            if (dice == diceBehavior.Random)
            {
                int roll = Random.Range(1,(selectedClass[playerClass])+1);
                totalHP += roll;
                Debug.Log(totalHP);
            }
            // This goes below the if dice random function
            //Roll die Averaged
            else
            {
                totalHP += ((selectedClass[playerClass])+1)/2;
                Debug.Log(totalHP);
            }

            
        }
        return totalHP;
    }

    // This function will print the final HP with everything added up
    // This function is named finalHP

    public void finalHP(int totalHP)
    {
        totalHP = ((con/2)-5)*level + totalHP + (selectedRace[race])*level + (selectedTrait[trait])*level;
        
        Debug.Log($"Welcome {characterName}! Your starting HP is : {totalHP}");
        return;
    }
    
}
