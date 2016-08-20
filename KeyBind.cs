using UnityEngine;
using System.Collections.Generic;
using System;


public class KeyBind : Binding {
    public KeyCode Button { get; protected set; }
    TriggerFunction KeyDown, KeyUp;
    public void AddKeyDown(TriggerFunction down) {
        KeyDown += down;
    }
    public void RemoveKeyDown(TriggerFunction down) {
        KeyDown -= down;
    }
    public void AddKeyUp(TriggerFunction up) {
        KeyUp += up;
    }
    public void RemoveKeyUp(TriggerFunction up) {
        KeyUp -= up;
    }
    public KeyBind(KeyCode bind, TriggerFunction down, bool tog) {
        Button = bind;
        KeyDown = down;
        Toggleable = tog;
    }
    public KeyBind(KeyCode bind, TriggerFunction down, TriggerFunction up, bool tog) {
        Button = bind;
        KeyDown = down;
        KeyUp = up;
        Toggleable = tog;
    }
    public override void Process( ) {
        if(!IsActive)
            this.Value = Input.GetKey(Button) ? 1 : 0;
        else {
            if(Input.GetKey(Button)) {
                if(Toggleable) 
                    KeyDown.Invoke( );
            } else {
                if(KeyUp != null)
                    KeyUp.Invoke( );
                Value = Input.GetKey(Button) ? 1 : 0;
            }
            return;
        }
        if(IsActive) 
            KeyDown.Invoke( );
    }
}
