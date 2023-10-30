using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeFrameWork;

namespace CoffeeFrameWork
{
	public class GameLauncher : MonoBehaviour
	{
		public static GameLauncher Instance { get; private set; }
		
		
		[SerializeField]
		private float timeScale;
		[SerializeField]
		private int _frameRate = 30;
		
		[HideInInspector]
		public Transform SingletonRoot;
		
		void Awake()
		{
			Instance = this;
			
			var singletonGo = new GameObject("SingletonRoot");
			singletonGo.transform.SetParent(transform);
			SingletonRoot = singletonGo.transform;
			
			DontDestroyOnLoad(this);
		}
		
		void Start()
		{
			timeScale = 10;
			Debug.LogError(TestSingle.Instance.GetName());
			Debug.LogError(TestSingletonMono.Instance.GetName());
		}

		void Update()
		{
			
		}
	}
}


