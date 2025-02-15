﻿using UnityEngine;

namespace RoboFactory.Factory.Cameras
{
    public class CameraPointView : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }
}