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


public static class KeyBindController {
    private static Dictionary<string, KeyBind> KeyBinds = new Dictionary<string, KeyBind>( );
    private static bool Exists(string nick) {
        if(KeyBinds.ContainsKey(nick))
            return true;
        else 
            return false;
    }
    private static bool Exists(KeyCode btn) {
        foreach(KeyValuePair<string, KeyBind> bind in KeyBinds) {
            if(bind.Value.Button == btn) {
                return true;
            }
        }
        return false;
    }
    public static void AddKeyDown(string nick, EventHandler func) {
        if(Exists(nick)) 
            KeyBinds[nick].KeyDown += func;
    }
    public static void RemoveKeyDown(string nick, EventHandler func) {
        if(Exists(nick)) 
            KeyBinds[nick].KeyDown -= func;
    }
    public static void AddKeyUp(string nick, EventHandler func) {
        if(Exists(nick))
            KeyBinds[nick].KeyUp += func;
    }
    public static void RemoveKeyUp(string nick, EventHandler func) {
        if(Exists(nick))
            KeyBinds[nick].KeyUp -= func;
    }
    public static void Register(string nick, KeyCode btn, bool toggleable) {
        if(Exists(btn) || Exists(nick)) {
            throw new Exception("Nickname or KeyCode already registered.");
        }
        KeyBinds.Add(nick, new KeyBind {
            Button = btn,
            CanToggle = toggleable
        });
    }
    public static void Register(string nick, KeyCode btn, EventHandler KeyDown, bool toggleable) {
        Register(nick, btn, toggleable);
        AddKeyDown(nick, KeyDown);
    }
    public static void Register(string nick, KeyCode btn, EventHandler KeyDown, EventHandler KeyUp, bool CanToggle) {
        Register(nick, btn, KeyDown, true);
        AddKeyUp(nick, KeyUp);
    }
    public static void ProcessBindings() {
        foreach(KeyValuePair<string, KeyBind> bind in KeyBinds) {
            bind.Value.Process( );
        }
    }
}
