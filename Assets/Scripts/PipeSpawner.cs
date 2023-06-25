using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : Spawner
{
    private static PipeSpawner instance;
    public static PipeSpawner Instance { get => instance;}
    [SerializeField] protected Transform pipe;     // tạo biến để gán obj pipe
    public Transform Pipe { get => pipe;}
    

    private void Awake() {
        PipeSpawner.instance= this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPipe();
    }

    protected virtual void LoadPipe() 
    {
        if(this.pipe != null) return;
        this.pipe = transform.Find("Pipe");
    }

    public void SpawnPipe(){
        float randYpos = Random.Range(-2f, 2f);
        Vector2 spanwPipex = new Vector2(4f , randYpos);
        if(pipe){
            Transform objs = Spawn(pipe, spanwPipex, Quaternion.identity);                     
            objs.gameObject.SetActive(true);
        }    
    }
}
