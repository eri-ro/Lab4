using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DNDCalculator : MonoBehaviour
{
    [Header("Character Sheet")]
    public string charaterName;
    [Range(1,20)]
    public int level;
    [Range(1,30)]
    public int con;
    
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

    public enum traitsHP {None, Stout, Tough};
    public traitsHP traitHP;

    public enum diceBehaviour {Averaged, Random};
    public diceBehaviour dice;

     Dictionary<string, int> selectedRace = new Dictionary<string, int>()
    {
       {"Human", 0},
       {"Dwarf", 2},
       {"Orc", 1},
       {"Goliath", 1}
    };
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
    Debug.Log(selectedClass[playerClass]);
    }
}
