using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatronic : MonoBehaviour
{
    //Publicas 
    public float timeToMove, probabilityOfMoving;
    public Transform[] positions;
    public Door door;

    public GameObject jumpscareMeah;
    //Pribadas 
    private int positionIndex;


    // Start is called before the first frame update
    void Start()
    {
        positionIndex = 0;
        StartCoroutine(MovementCoroutine(Random.Range(timeToMove - 5f, timeToMove + 5f)));
    }

 
    void Muve()
    {
        if(Random.Range(0f, 100f)<= probabilityOfMoving) { 
            if (positionIndex== positions.Length - 1)
            {
                //verificar si lapuerta esta abierta 
                if(door == null || door.IsOpen())
                {
                    //ataca
                    StopAllCoroutines();
                    Attack();
                    return;
                }
                else
                {
                    //retirada
                    positionIndex = 0;
                    transform.position = positions[positionIndex].position;
                    transform.rotation = positions[positionIndex].rotation;
                }
            }// si no estamos en la puerta 
            else
            {
                //sigiente pocicion 
                positionIndex ++;
                transform.position = positions[positionIndex].position;
                transform.rotation = positions[positionIndex].rotation;
            }
        }
        //Iniciamos la rutina para el siguente movimiento 
        StartCoroutine(MovementCoroutine(Random.Range(timeToMove - 5f, timeToMove + 5f)));
    }

    //atacar
    public void Attack()
    {
        jumpscareMeah.SetActive(true);
        LevelManager.Instance.PlayerDead();
    }

    //corrutina de movimiento 
    IEnumerator MovementCoroutine(float _time)
    {
        yield return new WaitForSecands(_time);

    }
}
