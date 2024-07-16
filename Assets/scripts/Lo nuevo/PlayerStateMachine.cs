using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    // Estados
    PlayerBaseState currentState;
    public PlayerSitState sitState;
    public PlayerMonitorState monitorState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = sitState;
        currentState.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate(this);
    }

    // Funcion para cambiar de estado
    public void SwitchState(PlayerBaseState _state)
    {
        currentState.OnExit(this);
        currentState = _state;
        currentState.OnEnter(this);
    }

    // Funcion que controla el cambio de estado en el boton del monitor
    public void MonitorButtonPressed()
    {
        if (currentState == sitState)
        {
            SwitchState(monitorState);
        }
        else
        {
            SwitchState(sitState);
        }
    }


}
