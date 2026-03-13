using System.Collections;
using CookieClicker.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace CookieClicker.Tests.PlayModeTests
{
	public class PurchaseButtonTests
	{
		[UnityTest]
		public IEnumerator PurchaseAutoclickerButtonIsNotInteractableByDefault()
		{
			yield return SceneManager.LoadSceneAsync(0);

			var button = Object.FindAnyObjectByType<PurchaseAutoclickerButton>().GetComponent<Button>();

			Assert.That(button.interactable, Is.False);
		}
	}
}
