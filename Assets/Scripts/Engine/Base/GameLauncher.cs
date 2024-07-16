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
		
		
		[SerializeField]
		private float timeScale;
		[SerializeField]
		private int _frameRate = 30;
		
		[HideInInspector]
		public Transform SingletonRoot;
	
		private TestThread _thread;
		
		void Awake()
		{
			Instance = this;
			
			var singletonGo = new GameObject("SingletonRoot");
			singletonGo.transform.SetParent(transform);
			SingletonRoot = singletonGo.transform;
			
			DontDestroyOnLoad(this);

			_thread = new TestThread(() =>
			{
				UnityMainThreadDispatcher.Dispatcher.Enqueue(() =>
				{
					GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
					go.name = "tread action create";
					go.transform.position = new Vector3(1, 2, 3);
				});
			});
			
			_thread.Start();
			
			Debug.LogError("TestAsync start =");
			_testGo = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			
			TestAsync(100);
			TestLog();
		}
		
		void Start()
		{
			timeScale = 10;
			Debug.LogError(TestSingle.Instance.GetName());
			Debug.LogError(TestSingletonMono.Instance.GetName());

			Debug.LogError("Start" + _tickCount);
			
			// 使用什么方式开启，需要使用对应方式关闭
			// var routine = StartCoroutine(TestCoroutine("aaaa", 123));
			// StopCoroutine(routine);
			//
			// StartCoroutine("TestCoroutine", "1111");
			// StopCoroutine("TestCoroutine");

			StartCoroutine(CoroutineProcess());
		}

		private int _tickCount = 0;
		private GameObject _testGo;
		void Update()
		{
			_tickCount++;
			if (_tickCount == 60)
			{
				// _testGo = new GameObject("TestGo");
				// _testGo.transform.SetParent();
			}
		}

		private ResourceRequest _request;
		IEnumerator TestCoroutine(string name, int age)
		{
			// Debug.LogError("_testGo = " + name + " age"+age);
			// _testGo.transform.localScale = new Vector3(1, 2, 3);
			// yield return transform.Find("TestGo");
			// Debug.LogError("TestCoroutine" + _tickCount);
			// yield return null;
			// Debug.LogError("1111" + _tickCount);
			// yield break;
			// Debug.Log(77777777);
			_request = Resources.LoadAsync("Cube");
			var abRequest = AssetBundle.LoadFromFileAsync("aaaaa");
			yield return abRequest.isDone;

			Debug.Log("Cube 加载完成 了 " + _tickCount);
		}

		IEnumerator CoroutineProcess()
		{
			// Debug.LogError("开始协程，算第一帧 1帧");
			// yield return null;	// 暂定协程，等待下一次唤醒
			// Debug.LogError("下一次唤醒，这是下一帧了，2帧");
			// yield return null;	// 继续暂定，等待下一帧唤醒
			// Debug.LogError("下一次唤醒，这是下一帧了，3帧");
			// yield return _testGo;	// _testGo 是null的话，暂定协程，等待下一帧，执行下边逻辑
			// Debug.LogError("下一次唤醒，刚才_testGo是空的，走到第4帧了");
			Debug.LogError("开始帧 = " + _tickCount);
			yield return new TestYieldInstruction(100);
			Debug.LogError("结束帧 = " + _tickCount);
		}
		
		IEnumerator LoadAssetAsync()
		{
			var goPath = "Asset/GameAsset/UI/UIMain.prefab";
			var abPath = "Asset/GameAsset/Bundle/ui_bundle.ab";
			AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(abPath);
			// 方式1 isDone 是否加载完了
			while (!request.isDone)
			{
				yield return null;
			}

			// 方式2 request 是 AssetBundleCreateRequest 底层继承自 AsyncOperation => YieldInstruction (底层应该是提供了IEnumerator相关的方法 current MoveNext)
			yield return request;
			
			var go = request.assetBundle.LoadAsset(goPath);
			AssetBundleRequest go2 = request.assetBundle.LoadAssetAsync(goPath);

			while (!go2.isDone)
			{
				yield return null;
			}

			yield return new WaitForSeconds(1.0f);
		}
		
		
		private async Task TestAsync(long count)
		{
			await Task.Run(async () =>
			{
				for (long i = 0; i < count; i++)
				{
					await Task.Delay(TimeSpan.FromSeconds(0.2f));
					UnityMainThreadDispatcher.Dispatcher.Enqueue(() =>
					{
						_testGo.transform.position = new Vector3(i, i, i);
					});
				}
			});
		}

		private void TestLog()
		{
			for (long i = 0; i < 10000; i++)
			{
				Debug.LogError("TestLog index = " + i);;
			}
		}
	}

	// 实现延迟帧 协程指令
	public class TestYieldInstruction : CustomYieldInstruction
	{
		public override bool keepWaiting {
			get
			{
				m_DelayFrame--;
				if (m_DelayFrame <= 0)
				{
					return false;
				}

				return true;
			}
		}
		private int m_DelayFrame;
		public TestYieldInstruction(int delayFrame)
		{
			m_DelayFrame = delayFrame;
		}
	}

}


