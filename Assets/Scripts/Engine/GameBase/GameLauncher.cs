using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeFrameWork;

namespace CoffeeFrameWork
{
	public class GameLauncher : MonoBehaviour
	{
		public float timeScale;
		
		
		void Awake()
		{
			DontDestroyOnLoad(this);
		}
		
		void Start()
		{
			
		}

		void Update()
		{
			
		}
	}
}


