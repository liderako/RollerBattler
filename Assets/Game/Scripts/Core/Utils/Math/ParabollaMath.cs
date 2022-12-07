﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoreGame.Math
{
    public class ParabollaMath
    {
        public static Vector3[] parabolicMovement(Vector3 startingPos, Vector3 arrivingPos, float animationDuration=2.0f, float framesPesSECOND=30.0f, float Height=1)
        {
            int framesNum = (int)(animationDuration * framesPesSECOND);
            Vector3[] frames = new Vector3[framesNum];

            //PROJECTING ON Z AXIS
            Vector3 stP = new Vector3(0, startingPos.y, startingPos.z);
            Vector3 arP = new Vector3(0, arrivingPos.y, arrivingPos.z);

            Vector3 diff;

            Vector3 height = new Vector3(0, Height, 0);
            diff = ((arP - stP) / 2) + height;
            Vector3 vertex = stP + diff;

            float x1 = startingPos.z;
            float y1 = startingPos.y;
            float x2 = arrivingPos.z;
            float y2 = arrivingPos.y;
            float x3 = vertex.z;
            float y3 = vertex.y;

            float denom = (x1 - x2) * (x1 - x3) * (x2 - x3);

            var z_dist = (arrivingPos.z - startingPos.z) / framesNum;
            var x_dist = (arrivingPos.x - startingPos.x) / framesNum;

            float A = (x3 * (y2 - y1) + x2 * (y1 - y3) + x1 * (y3 - y2)) / denom;
            float B = (float)((x3 * x3) * (y1 - y2) + (x2 * x2) * (y3 - y1) + (x1 * x1) * (y2 - y3)) / denom;
            float C = (x2 * x3 * (x2 - x3) * y1 + x3 * x1 * (x3 - x1) * y2 + x1 * x2 * (x1 - x2) * y3) / denom;

            float newX = startingPos.z;
            float newZ = startingPos.x;

            for (int i = 0; i < framesNum; i++)
            {
                newX += z_dist;
                newZ += x_dist;
                float yToBeFound = A * (newX * newX) + B * newX + C;
                frames[i] = new Vector3(newZ, yToBeFound, newX);
            }
            return frames;
        }
    }
}