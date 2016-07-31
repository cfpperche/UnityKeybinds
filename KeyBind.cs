/*
 * Purpose: 
 *      To provide a datatype for the keybinds, and the events that are 
 *      related to the binding.
 *  Functions:
 *      Process:
 *          This never needs to actually be called. the KeyBindController 
 *          does this for you, so unless you want to be creating your 
 *          own controller, you don't need to use anything in this file.
 *          But, this contains the logic involved in processing keypresses.
 */
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;


public class KeyBind {
    // Events for key up and key down
    public event EventHandler KeyDown;
    public event EventHandler KeyUp;
    // Whether or not holding the key down with spam the KeyDown events
    public bool CanToggle;
    // Flag for if the key is pressed
    private bool IsBindActive;
    // The actual key 
    public List<KeyCode> BtnCodes;

    // The function that processes the keybind logic
    public void Process() {
        bool BindButtonPressed = false;
        foreach(KeyCode btn in BtnCodes) {
            if(Input.GetKey(btn)) {
                BindButtonPressed = true;
                break;
            }
        }
        if(BindButtonPressed) {
            if(CanToggle || !IsBindActive) {
                KeyDown.Invoke(this, null);
                IsBindActive = true;
            }
        } else if(!BindButtonPressed) {
            if(IsBindActive) {
                IsBindActive = false;
                if(KeyUp != null) {
                    KeyUp.Invoke(this, null);
                }
            }
        }
    }
}