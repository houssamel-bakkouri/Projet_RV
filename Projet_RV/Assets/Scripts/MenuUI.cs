using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{ 
    [SerializeField] private string sceneToLoad;
   public void ClickTest()
   {
      print("Button clicked");
   }

   public void Play()
   {
       SceneManager.LoadScene(sceneToLoad);
   }

   public void Quit()
   {
       #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
       #else
                Application.Quit();
       #endif
   }
}
