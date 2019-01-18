using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
	public Slider slider;

	public void LoadLevel(int SceneIndex)
	{
		StartCoroutine(LoadAsync(SceneIndex));
	}
	
	IEnumerator LoadAsync(int SceneIndex)
	{
		AsyncOperation Load = SceneManager.LoadSceneAsync(SceneIndex);
		while (!Load.isDone)
		{
			slider.value = Load.progress;
			yield return null;
		}
	}
}