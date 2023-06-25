using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Darwin
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
    }
     protected virtual void LoadHolder()
    {
        if(this.holder != null) return;           
        this.holder = transform.Find("Holder");     
    }

    protected virtual Transform Spawn( Transform prefab, Vector2 spawnpos, Quaternion rotation)           
    {
        Transform newPrefabs = this.GetObjectformPool(prefab);                                           // lấy ra từ pool để spawn lại                               
        newPrefabs.SetPositionAndRotation(spawnpos, rotation);                                          
        newPrefabs.name = prefab.name;                                                                  
        newPrefabs.parent = this.holder;                                                                // thêm nó vào object holder
        return newPrefabs;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);                     // thêm vào pool
        obj.gameObject.SetActive(false);            // off nó đi
    }

    protected virtual Transform GetObjectformPool(Transform prefab)     // lấy những thằng từ trong pool đã dc thêm vào 
    {
        foreach (Transform poolObj in this.poolObjs) 
        {
            if(poolObj.name == prefab.name){                            // nếu có thì return nó ra để spawn lại
                this.poolObjs.Remove(poolObj);        
                return poolObj;                       
            }
        }
        Transform newPerfab = Instantiate(prefab);                      // nếu trong pool không có thì tạo cái mới
        newPerfab.name = prefab.name;                   
        return newPerfab;                               
    }
}
