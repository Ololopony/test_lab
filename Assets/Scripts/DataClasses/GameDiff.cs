using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Golf
{
    [System.Serializable]
    public class GameDiff
    {
        public float delay = 10f;
        public float maxDelayChange = 10f;
        public float stepDelay = 0f;
    }
}
