using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_StateMachine : MonoBehaviour
{
    private Dictionary<int, CV_State> CV_States = new Dictionary<int, CV_State>();
    private CV_State _currentState;
    private void Start() {
        //Adds all possible states that the AI has to a list
        AddState(0, GetComponent<CV_Idle>());
        AddState(1, GetComponent<CV_Move>());
        AddState(2, GetComponent<CV_Attack>());
        AddState(3, GetComponent<CV_Dead>());

        //Sets the state to Idle and starts the state
        _currentState = CV_States[0];
        _currentState.StartState();
    }

    private void Update() {
        _currentState.PerformState(); //Perform state is called to do what the state is ment to do
        _currentState.RequestToStopState(); //Request to stop is called to check when to break out of the state
    }

    private void AddState(int index, CV_State state) {
        //This adds a new state to the list of states
        CV_States.Add(index, state);
    }

    public void SwitchState(int stateIndex) {
        //This will stop the current state, switch the state and start the new active state
        _currentState.StopState();
        _currentState = CV_States[stateIndex];
        _currentState.StartState();
    }
}
