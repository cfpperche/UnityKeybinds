/*
 * KeyBindings Controller
 * 
 * Purpose: To make easy, event based key bindings
 * 
 * Functions:
 *      Registers
 *          All of the Registers functions are intended to be multi-line, each adding
 *          a keybind with a nickname and button. Personal preference for me is to hand it a
 *          lambda to avoid having to point it to another area, but use of partial classes
 *          may permit programmers to treat key binds like a UI
 *      Exists
 *          These just simply check if the button or nickname has already been taken.
 *      AddKeyUp
 *      AddKeyDown
 *      RemoveKeyUp
 *      RemoveKeyDown
 *          These functions are intended to make the "event" system more easily accessible.
 *          Pass it a function that you intend to use, or already used, and it will do as
 *          the function says it should.
 *      ProcessBindings
 *          This has to run on an Update function. Probably a good idea to put this in a
 *          player object, or something that will simply always exist.
 *
 * 
 * 
 *      Personal comments:
 *          The code written in this controller is pretty self explanatory, as are the 
 *          function names. This was intended for reuse, and credit is not needed. The
 *          code was written to be minimalistic as well, so some personal conventions
 *          were broken to conserve space. See the if statements in the first few
 *          functions to see what I mean.
 */
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
