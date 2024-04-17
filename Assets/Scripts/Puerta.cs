using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
   public Animator laPuerta;

  private void OnTriggerEnter(Collider other){
    laPuerta.Play("door_1_open");
  }

  private void OnTriggerExit(Collider other){
    laPuerta.Play("door_1_close");
  }
}
