using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using CoffeeFrameWork;

namespace CoffeeFrameWork
{
	public class GameLauncher : MonoBehaviour
	{
		public static GameLauncher Instance { get; private set; }

		public Transform SingletonRoot;
		
		void Awake()
		{
			Instance = this;
		}
	}
	
}


