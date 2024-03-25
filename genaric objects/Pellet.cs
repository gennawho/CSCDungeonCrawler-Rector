using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet 
{
    protected int bonus;
    protected string name;
    protected Pellet(int bonus)
    {
        this.bonus = bonus;
        name = "pellet";
    }
 
}
