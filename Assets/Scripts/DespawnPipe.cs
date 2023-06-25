using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnPipe : Darwin
{
    [SerializeField] protected float Delay = 10f;
    [SerializeField] protected float timer = 0;


    protected override void OnEnable() {
        base.OnEnable();
        this.ResetTimer();
    }

    protected virtual void ResetTimer()
    {
        this.timer = 0;
    }
    protected virtual void DespawnObject()
    {
        PipeSpawner.Instance.Despawn(transform.parent);
    }
    protected virtual void FixedUpdate() {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if(!CanSpawn()) return; 
        DespawnObject();        
    }
     protected virtual bool CanSpawn()
    {
        this.timer += Time.fixedDeltaTime;
        if(this.timer > this.Delay) return true;
        return false;
    }
}
