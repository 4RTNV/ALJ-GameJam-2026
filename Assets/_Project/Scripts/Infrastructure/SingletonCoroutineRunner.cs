using System;
using System.Collections;
using UnityEngine;

namespace _Project.Infrastructure
{
    public sealed class SingletonCoroutineRunner : MonoBehaviour
    {
        private static SingletonCoroutineRunner _instance;

        public static SingletonCoroutineRunner Instance
        {
            get
            {
                if (_instance != null) 
                    return _instance;
                
                GameObject emptyInstance = new("[Coroutine Runner]");
                _instance = emptyInstance.AddComponent<SingletonCoroutineRunner>();
                DontDestroyOnLoad(emptyInstance);

                return _instance;
            }
        }

        public static Coroutine RunRoutine(IEnumerator coroutine) 
            => Instance.StartCoroutine(coroutine);
    
        public static void StopRoutine(Coroutine coroutine) 
            => Instance.StopCoroutine(coroutine);


        private void Update()
        {
            OnGameLoopUpdate?.Invoke(this, null);
        }
        public static event EventHandler OnGameLoopUpdate;
    }
}