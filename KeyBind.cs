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

public class KeyBind {
    // Events for key up and key down
    public event EventHandler KeyDown;
    public event EventHandler KeyUp;
    // Whether or not holding the key down with spam the KeyDown events
    public bool CanToggle;
    // Flag for if the key is pressed
    private bool IsKeyDown;
    // The actual key 
    public KeyCode Button;

    // The function that processes the keybind logic
    public void Process() {
        if(Input.GetKeyDown(Button) && !IsKeyDown) {
            IsKeyDown = true;
            if(KeyDown.Method != null) {
                KeyDown.Invoke(this, null);
            }
        } else if(Input.GetKey(Button) && IsKeyDown && CanToggle) {
            KeyDown.Invoke(this, null);
        } else if(!Input.GetKeyDown(Button) && IsKeyDown) {
            IsKeyDown = false;
            if(KeyUp != null) {
                KeyUp.Invoke(this, null);
            }
        }
    }
}