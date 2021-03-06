﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Moves the Camera whenever the player gets a certain portion of the Screen
namespace Albatross
{
    public class TransitionCameraSpace : MonoBehaviour
    {

        Vector3 NewCameraPosition = Vector3.zero;

        [SerializeField]
        Direction CameraDirection; 

        void Update()
        {            
            float height = 5.0f;
            float width = 15.0f;
            if (CameraDirection == Direction.North)
            {
                NewCameraPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + height, transform.parent.transform.position.z);
            }
            if (CameraDirection == Direction.South)
            {
                NewCameraPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y - height, transform.parent.transform.position.z);
            }
            if (CameraDirection == Direction.East)
            {
                NewCameraPosition = new Vector3(transform.parent.transform.position.x + width, transform.parent.transform.position.y, transform.parent.transform.position.z);
            }
            if (CameraDirection == Direction.West)
            {
                NewCameraPosition = new Vector3(transform.parent.transform.position.x- width, transform.parent.transform.position.y, transform.parent.transform.position.z);
            }
        }


        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.transform.CompareTag("Player"))
            transform.parent.transform.position = NewCameraPosition;
        }
        
    }
}