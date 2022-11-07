using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace william.utilities
{
    class SharedCoroutineStarter : MonoBehaviour
    {
        private static SharedCoroutineStarter _instance;

        public static new Coroutine StartCoroutine(IEnumerator routine)
        {
            _instance ??= new GameObject("Shared Coroutine Starter").AddComponent<SharedCoroutineStarter>();

            return ((MonoBehaviour)_instance).StartCoroutine(routine);
        }
    }
}
