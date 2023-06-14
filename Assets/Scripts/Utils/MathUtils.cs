using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Utils
{
    public class MathUtils
    {
        public static int Mod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }
    }
}