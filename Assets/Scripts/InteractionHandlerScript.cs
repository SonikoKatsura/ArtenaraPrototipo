using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionHandlerScript : MonoBehaviour,
    IMixedRealityInputActionHandler,
    IMixedRealityFocusHandler
{
    private bool isFocused = false;

    private void OnEnable()
    {
        CoreServices.InputSystem.RegisterHandler<IMixedRealityInputActionHandler>(this);
        CoreServices.InputSystem.RegisterHandler<IMixedRealityFocusHandler>(this);
    }

    private void OnDisable()
    {
        CoreServices.InputSystem.UnregisterHandler<IMixedRealityInputActionHandler>(this);
        CoreServices.InputSystem.UnregisterHandler<IMixedRealityFocusHandler>(this);
    }

    void IMixedRealityInputActionHandler.OnActionStarted(BaseInputEventData eventData)
    {
        if (!isFocused)
        {
            return;
        }

        if (eventData.MixedRealityInputAction.Description == "Select") {
            Debug.Log("Funciona");
            gameObject.GetComponent<SimpleCollectibleScript>().Collect();
            /*if (gameObject.tag == "Menu")
            {
                SceneManager.LoadScene("Main");
            }
            else if (gameObject.tag == "Sky")
            {
                Debug.Log("Sky");
                SceneManager.LoadScene("Skybox");
            }
            else if(gameObject.tag == "Timelapse")
            {
                SceneManager.LoadScene("Video_timelapse");
            }
            else if(gameObject.tag == "Credits")
            {
                SceneManager.LoadScene("Credits");
            }
            else if (gameObject.tag == "Video") {
                Debug.Log("Video");
                SceneManager.LoadScene("Video_canteras");
            }
            else if (gameObject.tag == "Matterport") {
                Debug.Log("Matterport");
                Application.OpenURL("https://my.matterport.com/show/?m=KWP67Z6gwTb");
                Application.Quit();
            }*/
        }
    }

    void IMixedRealityInputActionHandler.OnActionEnded(BaseInputEventData eventData) { }

    void IMixedRealityFocusHandler.OnFocusEnter(FocusEventData eventData)
    {
        isFocused = eventData.NewFocusedObject.GetHashCode() == gameObject.GetHashCode();
    }

    void IMixedRealityFocusHandler.OnFocusExit(FocusEventData eventData)
    {
        isFocused = false;
    }
}
