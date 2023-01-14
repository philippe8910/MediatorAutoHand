//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: This object won't be destroyed when a new scene is loaded
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class DontDestroyOnLoad : MonoBehaviour
	{
		public static DontDestroyOnLoad instance;

		//-------------------------------------------------
		void Awake()
		{
			if (instance != null)
			{
				Destroy(gameObject); return;
			}
			else
			{
				instance = this;
			}
			
			DontDestroyOnLoad( this );
		}
	}
}
