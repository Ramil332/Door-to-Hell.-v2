//Скрипт ссылка на сайт или ещё куда
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Sych_scripts
{
	public class Link : MonoBehaviour
	{

		[Tooltip("Ссылка")]
		public string link = "https://vk.com/pixel_star";
		public void Active()
		{
			Application.OpenURL(link);
		}
	}
}