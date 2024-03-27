using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class FightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    private char WhosTurn = 'h';
    private Monster aMonster;
    private Vector3 homePositionHero, homePositionMonster;
    private bool attackDone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        aMonster = new Monster("Boo");
        aMonster.setStats();
        this.hero_hp_TMP.text = "Hero HP: " + MySingleton.thePlayer.getHP();
        this.monster_hp_TMP.text = "monster HP: " + aMonster.getHP();
        homePositionMonster = this.monster_GO.transform.position;
        homePositionHero = this.hero_GO.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(WhosTurn == 'h')
        {
            if (Vector3.Distance(hero_GO.transform.position, monster_GO.transform.position) > 12.0f && attackDone == false)
            {
                hero_GO.transform.position = Vector3.MoveTowards(hero_GO.transform.position, monster_GO.transform.position, 1.0f * Time.deltaTime);
            }
            else
            {
                if (attackDone == false)
                {
                    if (aMonster.ACCheck(rollDice(20)))
                    {
                        aMonster.setHP(rollDice(6));
                        
                    }
                    Debug.Log("attack done");
                    attackDone = true;
                }
                else
                {
                    if (homePositionHero != hero_GO.transform.position)
                    {
                        hero_GO.transform.position = Vector3.MoveTowards(hero_GO.transform.position, homePositionHero, 1.0f * Time.deltaTime);
                    }
                    else
                    {
                        WhosTurn = 'm';
                        attackDone = false;
                    }
                        
                }
                
            }
        }
        if (WhosTurn == 'm')
        {
            if (Vector3.Distance(hero_GO.transform.position, monster_GO.transform.position) > 12.0f && attackDone == false)
            {
                monster_GO.transform.position = Vector3.MoveTowards(monster_GO.transform.position, hero_GO.transform.position, 1.0f * Time.deltaTime);
            }
            else
            {
                if (attackDone == false)
                {
                    if (MySingleton.thePlayer.ACCheck(rollDice(20)))
                    {
                        MySingleton.thePlayer.setHP(rollDice(6));
                    }
                    attackDone = true;
                }
                else
                {
                    if (homePositionMonster != monster_GO.transform.position)
                    {
                        monster_GO.transform.position = Vector3.MoveTowards(monster_GO.transform.position, homePositionMonster, 1.0f * Time.deltaTime);
                    }
                    else
                    {
                        WhosTurn = 'h';
                        attackDone = false;
                    }

                }

            }
        }
        this.hero_hp_TMP.text = "Hero HP: " + MySingleton.thePlayer.getHP();
        this.monster_hp_TMP.text = "monster HP: " + aMonster.getHP();
        if (MySingleton.thePlayer.getHP() <= 0 || aMonster.getHP() <= 0)
        {
            EditorSceneManager.LoadScene("DungeonRoom");
        }
    }
    int rollDice(int faces)
    {
        int result = Random.Range(1, faces + 1);
        return result;
    }
}
