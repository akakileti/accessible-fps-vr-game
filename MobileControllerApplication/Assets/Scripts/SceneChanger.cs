using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public enum SceneIndex
    {
        EntryScene=0,
        RemoteControlScene=1,
        IPScene=2,
        SettingsScene=3,
        GuideScene =4

    
    }

   public void OpenSettings()
    {
   SceneManager.LoadScene((int) SceneIndex.SettingsScene);
    }

 public void EntryScene()
 {
 SceneManager.LoadScene((int)SceneIndex.EntryScene);

 }
    public void OpenRemoteControl()
    {
        SceneManager.LoadScene((int)SceneIndex.RemoteControlScene);
    }
    public void OpenIP(){
        SceneManager.LoadScene((int)SceneIndex.IPScene);}

public void OpenGuide(){
   SceneManager.LoadScene((int)SceneIndex.GuideScene);
}
}
