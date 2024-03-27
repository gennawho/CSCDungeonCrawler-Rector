using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class inhabitent
{
    protected string name;
    protected room currentRoom;
    protected int AC;
    protected int HP;
    public inhabitent(string name)
    {
        this.name = name;
       
    }
    public room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(room r)
    {
        this.currentRoom = r;
    }
    public bool ACCheck(int roll)
    {
        return roll >= AC;
    }
    public int getHP()
    {
        return HP;
    }
    public void setStats()
    {
        HP = Random.Range(20, 51);
        AC = Random.Range(10, 17);
    }
    public void setHP(int damage)
    {
        HP = HP - damage;
    }
}
   
