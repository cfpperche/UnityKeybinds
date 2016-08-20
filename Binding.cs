using UnityEngine;
using System.Collections;

public delegate void TriggerFunction( );

public abstract class Binding {
    protected bool IsActive {
        get {
            return (Value != 0f);
        }
    }
    protected bool Toggleable { get; set; }
    public float Value { get; protected set; }
    public abstract void Process( );
}
