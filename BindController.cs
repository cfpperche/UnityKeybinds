using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public static class BindController {
    private static BindingLibrary Bindings = new BindingLibrary( );

    public static void AddKeyDown(KeyCode key, TriggerFunction func) {
        Bindings.GetBind(key).AddKeyDown(func);
    }
    public static void RemoveKeyDown(KeyCode key, TriggerFunction func) {
        Bindings.GetBind(key).RemoveKeyDown(func);
    }
    public static void AddKeyUp(KeyCode key, TriggerFunction func) {
        Bindings.GetBind(key).AddKeyUp(func);
    }
    public static void RemoveKeyUp(KeyCode key, TriggerFunction func) {
        Bindings.GetBind(key).RemoveKeyUp(func);
    }
    public static void AddAnalog(string axisname, AnalogTriggerFunction func) {
        Bindings.GetBind(axisname).Trigger += func;
    }
    public static void RemoveAnalog(string axisname, AnalogTriggerFunction func) {
        Bindings.GetBind(axisname).Trigger -= func;
    }
    // Registration functions
    public static void Register(KeyCode btn, TriggerFunction down, bool tog) {
        Bindings.Add(Create(btn, down, tog));
    }
    public static void Register(KeyCode btn, TriggerFunction KeyDown, TriggerFunction KeyUp, bool CanToggle) {
        Bindings.Add(Create(btn, KeyDown, KeyUp, CanToggle));
    }
    public static void Register(string Axis, AnalogTriggerFunction func) {
        Debug.Log("Bound axis " + Axis);
        Bindings.Add(Create(Axis, func));
    }
    public static void Process( ) {
        Bindings.Process( );
    }
    private static KeyBind Create(KeyCode btn, TriggerFunction down, bool tog) {
        return new KeyBind(btn, down, tog);
    }
    private static KeyBind Create(KeyCode btn, TriggerFunction down, TriggerFunction up, bool tog) {
        return new KeyBind(btn, down, up, tog);
    }
    private static AxisBind Create(string name, AnalogTriggerFunction bind) {
        return new AxisBind(name, bind);
    }
}
