using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummon : Singleton<MonsterSummon>
{
    public GameObject[] BuyMonsterSummon;

    public int iNumber;

    GameObject followingSummonMonster;
    GameObject Dummy;
    public bool bBuy = false;

    TileInfo NowTile;
    XMLMonsterData NowMonster;

    float iNearPoint; //가까운 거리
    float iDistance; // 두점사이의 거리
    public Vector3 vPoint;

    public bool TileIn = false;

    void Update()   // 코루틴으로 변경예정 
    {
        if (bBuy == true)
        {
            Vector3 NewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
            //Debug.Log("마우스 좌표 X : " + NewPosition.x + " 마우스 좌표 Y : " + NewPosition.y);
            //followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], NewPosition, Quaternion.identity);
            MouseClick();
            if (bBuy == true)
            {
                if (TileIn == false)
                {
                    followingSummonMonster.transform.position = NewPosition;

                }
                else
                { 
                    followingSummonMonster.transform.position = vPoint;
                }
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

        /*
        if (bBuy == true)
        {
            Vector3 NewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
            //Debug.Log("마우스 좌표 X : " + NewPosition.x + " 마우스 좌표 Y : " + NewPosition.y);
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
        */

    }

    public void Summon(int _iNumber)
    {
        // 자원소모하고 나서 진행이 되야하기 때문에 여기서 할 예정

        iNumber = _iNumber;
        bBuy = true;
        Debug.Log(iNumber);
        followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void MouseClick()
    {
        if (bBuy == true)
        {
            if (Input.GetMouseButtonDown(0))        // 소환 시키기
            {
                followingSummonMonster = Dummy;
                bBuy = false;
                TileIn = false;
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

    /*
        public void Distance(float _fsmX, float _fsmY)  // 가장 짧은 거리 구하기  
        {
            Map.Instance.CurrentMapData(0);
            iNearPoint = DistanceBetweenTwoPoints(_fsmX, _fsmY, Map.Instance.vPos.x, Map.Instance.vPos.y);

            for (int i = 0; i < XMLMap.Instance.MapLength(); i++)
            {
                Map.Instance.CurrentMapData(i);
                iDistance = DistanceBetweenTwoPoints(_fsmX, _fsmY, Map.Instance.vPos.x, Map.Instance.vPos.y);
                if(iNearPoint>=iDistance)
                {
                    vNearPoint.x = Map.Instance.vPos.x;
                    vNearPoint.y = Map.Instance.vPos.y;
                }
            }
            //Debug.Log("두점사이의 거리에 대한 최소값 " + "x값 : " + vNearPoint.x + " y값 : " + vNearPoint.y);
        }

        public float DistanceBetweenTwoPoints(float _fsmX, float _fsmY, float _mapVposX, float _mapVposY) // 두점사이의 거리 구하기
        {
            float fsmX = _fsmX;
            float fsmY = _fsmY;
            float mapVposX = _mapVposX;
            float mapVposY = _mapVposY;

            return ((fsmX - mapVposX) * (fsmX - mapVposX) + (fsmY - mapVposY) * (fsmY - mapVposY));
        }
    */
}
