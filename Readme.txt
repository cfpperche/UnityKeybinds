BindController.Register
	- This function will allow you to bind a key, or axis. Use intellisense to see


Types you will have to glance at
delegate TriggerFunction, AnalogTriggerFunction

In only one Update() function in Unity, you need to put BindController.Process()
The rest will be taken care of for you. 


The following functions permit you to bind additional events to a key
AddKeyUp
AddKeyDown
RemoveKeyUp
RemoveKeyDown
AddAnalog
RemoveAnalog

Functions were written in such a way that little documentation is required to understand how to use it.

Adding a valid axis can be done through the input manager in Unity.

Some examples of binding code.
	
	// The first three are explicit key binds
	// The fourth is binding an axis
	// The boolean at the end of the register signature is whether or not the
	// keydown function will repeat itself when a key is being held.
        BindController.Register(KeyCode.Mouse0, ( ) => { PerformFire(1); }, false);
        BindController.Register(KeyCode.Mouse1, ( ) => { PerformFire(2); }, false);
        BindController.Register(KeyCode.Space, PerformThrust, true);
        BindController.Register("Horizontal", PerformRotation);
