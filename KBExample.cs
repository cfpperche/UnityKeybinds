using UnityEngine;
using System.Collections;
using System;

public class KBExample : MonoBehaviour {

    // Keys to make setting the buttons in the IDE easier
    public KeyCode MoveRightKey;
    public KeyCode MoveLeftKey;
    public KeyCode JumpKey;

    void RegisterBindings() {
        /*
         * Register works like this:
         *      First argument is the nickname
         *      Second argument is the actual key
         *      Third argument is whether or not it is toggleable, or the KeyDown event
         *      Fourth argument is whether or not it is toggleable, or the KeyUp event
         *      Fifth argument (assuming third and second) is the toggleable event
         *      
         *      - Nickname is a nice name you use to reference the binding in code
         *      - The keycode is set in the IDE via KeyCode, although you can do this by hand
         *      - The KeyUp and KeyDown events are just functions passed into the binding system
         *      - The Toggleable simply asks if you want to repeat the KeyDown function as long as
         *      it is held
         */
        KeyBindController.Register(
            "Move Right",
            MoveRightKey,
            // KeyDown function
            (object sender, EventArgs e) => {
                // KeyDown Logic
            },
            // KeyUp function
            (object sender, EventArgs e) => {
                // KeyUp Logic
            },
            true);
        KeyBindController.Register(
            "Move Left",
            MoveLeftKey,
            MoveLeft_KeyDown,
            MoveLeft_KeyUp,
            true);
        KeyBindController.Register(
            "Jump",
            JumpKey,
            (object sender, EventArgs e) => {
                // Jump logic
            },
            false);
    }

    // The next two functions are the event functions for MoveLeft
    void MoveLeft_KeyDown(object sender, EventArgs e) {
        // KeyDown logic
    }

    void MoveLeft_KeyUp(object sender, EventArgs e) {
        // KeyUp logic
    }
	void Start () {
        // I like to not put all my keybindings in the Start function
        RegisterBindings( );
	}

	void Update () {
        // Only needed once
        KeyBindController.ProcessBindings( );
	}
}
