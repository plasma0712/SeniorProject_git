using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlacement : Singleton<MonsterPlacement>
{
    [HideInInspector]
    public int InherentNumber;
    [HideInInspector]
    public int iCount;
    [HideInInspector]
    public float MonsterPosXData;
    [HideInInspector]
    public float MonsterPosYData;

    XMLMonsterSummonData Current;

    [HideInInspector]
    public Vector3 vPos;

    GameObject Monster;
    public GameObject Parent;

    //public MonsterSummon[] MonsterSummons = new MonsterSummon[10];

    private void Awake()
    {
        CullingMonster();
    }

    public void CurrentMonsterData(int _monsterdata)
    {
        Current = XMLMonsterSummon.Instance.GetMonsterSummonData(_monsterdata);
        iCount = Current.iCount;
        //Debug.Log(iCount);
        InherentNumber = Current.InherentNumber;
        MonsterPosXData = Current.fPosX;
        MonsterPosYData = Current.fPosY;
        vPos.x = MonsterPosXData;
        vPos.y = MonsterPosYData;

        GameObject instance = (GameObject)Instantiate(MonsterSummon.Instance.BuyMonsterSummon[InherentNumber], vPos, Quaternion.identity);
        //MonsterSummon.Instance.SummonCurring(InherentNumberData,vPos.x,vPos.y);
        instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
    }

    void CullingMonster()
    {
        XMLMonsterSummon.Instance.LoadXml();
        for(int k =0; k< XMLMonsterSummon.Instance.MonsterSummonLegth(); k++)
        {
            CurrentMonsterData(k);
        //    Debug.Log(k);
        }
    }
}
