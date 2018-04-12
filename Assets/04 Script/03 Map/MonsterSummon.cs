using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummon : Singleton<MonsterSummon>
{
    public GameObject[] BuyMonsterSummon;

    public int iNumber;

    GameObject followingSummonMonster;
    GameObject Dummy;
    bool bBuy = false;

    TileInfo NowTile;
    XMLMonsterData NowMonster;

    void Update()   // 코루틴으로 변경예정 
    {
        if (bBuy == true)
        {
            Vector3 NewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
            //followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], NewPosition, Quaternion.identity);
            MouseClick();
            if (bBuy == true)
            {
                followingSummonMonster.transform.position = NewPosition;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public void Summon(int _iNumber)
    {
        // 자원소모하고 나서 진행이 되야하기 때문에 여기서 할 예정

        iNumber = _iNumber;
        bBuy = true;
        Debug.Log(iNumber);
        followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber],new Vector3(0,0,0), Quaternion.identity);
    }

    public void MouseClick()
    {
        if (bBuy == true)
        {
            if (Input.GetMouseButtonDown(0))        // 소환 시키기
            {
                followingSummonMonster = Dummy;
                bBuy = false;
                
            }
            else if (Input.GetMouseButtonDown(1))   // 소환 취소 
            {
                Destroy(followingSummonMonster);
                bBuy = false;
                //자원소모 된것에 대해서 다시 되돌리기
            }
        }
    }

    //////////////////////////////////////////////////////////////////
    //public void

    public bool SummonMonsters()
    {
        Vector3 pos = GetTilePos(NowTile.pos[0], NowTile.pos[1]);
        //GameObject tmp2 = Instantiate(BuyMonsterSummon[])
        return true;
    }

    public Vector3 GetTilePos(int _i, int _j)
    {
        Vector3 result = new Vector3(Map.TileX * _i, Map.TileY * _j);
        return result;
    }

}
