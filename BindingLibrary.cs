using UnityEngine;
using System.Collections.Generic;

public enum BindType {
    Axis = 0,
    Button = 2,
}

public class BindingLibrary {
    List<AxisBind> AxisBinds;
    List<KeyBind> KeyBinds;
    public BindingLibrary( ) {
        AxisBinds = new List<AxisBind>( );
        KeyBinds = new List<KeyBind>( );
    }

    public void Add(KeyBind bnd) {
        this.KeyBinds.Add(bnd);
    }
    public void Remove(KeyBind bnd) {
        this.KeyBinds.Remove(bnd);
    }
    public void Add(AxisBind bnd) {
        this.AxisBinds.Add(bnd);
    }
    public void Remove(AxisBind bnd) {
        this.AxisBinds.Remove(bnd);
    }
    public KeyBind GetBind(KeyCode bnd) {
        foreach(KeyBind key in KeyBinds) {
            if(key.Button == bnd)
                return key;
        }
        throw new UnityException("Key not registered.");
    }
    public AxisBind GetBind(string bnd) {
        foreach(AxisBind ax in AxisBinds) {
            if(ax.AxisName == bnd)
                return ax;
        }
        throw new UnityException("Axis not registered.");
    }
    public void Process( ) {
        foreach(AxisBind bnd in AxisBinds) {
            bnd.Process( );
        }
        foreach(KeyBind bnd in KeyBinds) {
            bnd.Process( );
        }
    }
}
