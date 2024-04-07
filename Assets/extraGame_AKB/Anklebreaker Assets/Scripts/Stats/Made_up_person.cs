namespace extraGame_AKB
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0108
public class Made_up_person : Stat_Dict
{

    public string name = "no name";
    public int[] values = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int chance_pool = 10;

    // Start is called before the first frame update
    void Start()
    {
        player[0] = name;
        player["name"] = values[0];
        player["dunking"] = values[1];
        player["three point"] = values[2];
        player["free throw"] = values[3];
        player["offensive rebound"] = values[4];
        player["deffensive rebound"] = values[5];
        player["assist"] = values[6];
        player["turnover"] = values[7];
    }

    public string get_name()
    {
        return name;
    }

    private void example()
    {
       if ( this.gameObject.GetComponent<Made_up_person>().dunk_chance() == true)
        {
            //dunk is succesful
        }
    }

    public bool dunk_chance()
    {
        int rand = Random.Range(0, chance_pool);


        if (values[1] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool three_point_chance()
    {
        int rand = Random.Range(0, chance_pool);


        if (values[2] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool free_thorw_chance()
    {
        int rand = Random.Range(0, chance_pool);


        if (values[3] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool offensive_rebound_chance()
    {
        int rand = Random.Range(0, chance_pool);


        if (values[4] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool deffensive_rebound() //steal_ball
    {
        int rand = Random.Range(0, chance_pool);


        if (values[5] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool assist() // passing chance
    {
        int rand = Random.Range(0, chance_pool);


        if (values[6] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool turnover() //fumble_ball
    {
        int rand = Random.Range(0, chance_pool);


        if (values[7] < rand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}

