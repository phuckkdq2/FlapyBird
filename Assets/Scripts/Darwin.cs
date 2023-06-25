using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darwin : MonoBehaviour
{
    private void Awake() {
        this.LoadComponent();
        this.Reset();
    }

    protected virtual void Reset() {
        this.LoadComponent();
    }
    protected virtual void LoadComponent(){

    }
    protected virtual void OnEnable() {
        
    }
}
