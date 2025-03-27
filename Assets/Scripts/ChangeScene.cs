using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
 public GameObject location1;
 public GameObject location2;
 public GameObject Collider;
    void Start()
    {
        Collider.SetActive (true);
        location1.SetActive (true);
        location2.SetActive (false);
    }

    void OnTriggerEnter()
    {
        Collider.SetActive (false);
        location1.SetActive (false);
        location2.SetActive (true);
    }
}
