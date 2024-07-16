using System.Collections;
using UnityEngine;

namespace Engine.Utils
{
    public class MonoUtils : MonoBehaviour
    {
        public void Start_Coroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void Stop_Coroutine(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }
    }

}