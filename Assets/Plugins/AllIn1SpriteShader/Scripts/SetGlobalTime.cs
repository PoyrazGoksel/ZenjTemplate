using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllIn1SpriteShader
{
    [ExecuteInEditMode]
    public class SetGlobalTime : MonoBehaviour
    {
        int globalTime;

        private void Start()
        {
            globalTime = Shader.PropertyToID("globalUnscaledTime");
        }

        private void Update()
        {
            Shader.SetGlobalFloat(globalTime, Time.time / 20f);
        }
    }
}