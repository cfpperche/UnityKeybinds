using UnityEngine;
using System.Collections;
public delegate void AnalogTriggerFunction(float value);
public class AxisBind : Binding {

    public string AxisName { get; private set; }
    public AnalogTriggerFunction Trigger;

    public AxisBind(string axis, AnalogTriggerFunction trg) {
        this.AxisName = axis;
        this.Trigger = trg;
    }

    public override void Process( ) {
        Value = Input.GetAxis(AxisName);
        if(IsActive) {
            Debug.Log("Active. Calling axis delegate, value " + Value);
            Trigger.Invoke(Value);
        }
    }
}
