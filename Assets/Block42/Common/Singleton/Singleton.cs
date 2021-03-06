﻿using UnityEngine;
using System;

namespace Block42
{
	
	/// <summary>
	/// Singleton class
	/// </summary>
	/// <typeparam name="T">Type of the singleton</typeparam>
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		private static T _instance;

		/// <summary>
		/// The static reference to the instance
		/// </summary>
		public static T Instance
		{
			get
			{
				if (!InstanceExists) { // Create a GameObject and attach an instance if not found
					GameObject gameObject = new GameObject(typeof(T).Name.ToString());
					_instance = gameObject.AddComponent<T>();
				}
				return _instance;
			}
			protected set
			{
				_instance = value;
			}
		}

		/// <summary>
		/// Gets whether an instance of this singleton exists
		/// </summary>
		public static bool InstanceExists { get { return _instance != null; } }

		public static event Action instanceSetEvent;

		/// <summary>
		/// Awake method to associate singleton with instance
		/// </summary>
		protected virtual void Awake()
		{
			if (_instance != null) {
				Destroy(gameObject);
			} else {
				_instance = (T)this;
				instanceSetEvent?.Invoke();
			}
		}

		/// <summary>
		/// OnDestroy method to clear singleton association
		/// </summary>
		protected virtual void OnDestroy()
		{
			if (_instance == this)
				_instance = null;
		}

	}

}