using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRotator : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0, 0, 5* speed * Time.deltaTime);
    }
}
