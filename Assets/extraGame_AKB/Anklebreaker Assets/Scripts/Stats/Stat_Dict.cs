using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stat_Dict : MonoBehaviour
{

    public IDictionary player = new Dictionary<string, float>()
    {
        { "Name", 7},//name and jersy number
        { "dunking", 7}, //chance of making a shoot with in the box
        { "three point", 3}, //chance of making a shot out side of 3point permiter
        { "free throw", 6},// chance of making a shoot with in 3point permiter
        { "offensive rebound", 5}, //chance of being able to recover a missed shoot when duncking
        { "deffensive rebound", 5}, //chance of stealling
        { "assist", 9}, //effective pass chance
        { "turnover", 3}, //fumble chance

    };

    void Start()
    {

    }
}
