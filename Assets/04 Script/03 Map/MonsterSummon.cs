using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummon : Singleton<MonsterSummon>
{
    public GameObject[] BuyMonsterSummon;

    public int iNumber;

    GameObject followingSummonMonster;
    

    bool bBuy = false;

    void Update()   // 코루틴으로 변경예정 
    {
        if (bBuy == true)
        {
            Vector3 NewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
            //followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], NewPosition, Quaternion.identity);
            followingSummonMonster.transform.position = NewPosition;
        }
        else
        {
            return;
        }
    }

    public void Summon(int _iNumber)
    {
        iNumber = _iNumber;
        bBuy = true;
        Debug.Log(iNumber);
        followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber],new Vector3(0,0,0), Quaternion.identity);
    }




}
