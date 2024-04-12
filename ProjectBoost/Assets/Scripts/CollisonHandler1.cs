using System;
using UnityEngine;
//to use different scenes
using UnityEngine.SceneManagement;
public class CollisonHandler1 : MonoBehaviour
{
    [SerializeField] float levelLoadDelay=2f;
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip lostSound;
    [SerializeField] ParticleSystem finishParticals;
    [SerializeField] ParticleSystem lostParticals;

    AudioSource audioSource;
    Movement movement;

    bool isTransitioning=false;

    private void Start() {
        audioSource=GetComponent<AudioSource>();
        movement=GetComponent<Movement>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning){return;}
        
        switch(other.gameObject.tag)
        {
            case "start":
                Debug.Log("start");
                break;
            case "Finish":
                Debug.Log("Finish");
                //LoadNextLevel();
                StartSuccessSequence();
                break;
            case "fuel":
                Debug.Log("fuel");
                break;
            case "rest":
                Debug.Log("safe");
                break;
            default:
                Debug.Log("lost");
                //ReloadLevel();
                //to make the load a little later use invoke()
                StartCrashSequence();
                break;

        }
        
    }

    void StartSuccessSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(finishSound);
        finishParticals.Play();
        movement.enabled=false;
        Invoke("LoadNextLevel",levelLoadDelay); 
    }

    void StartCrashSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(lostSound);
        lostParticals.Play();
        movement.enabled=false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        //SceneManager.LoadScene(0);
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex= currentSceneIndex+1;
        //SceneManager.sceneCountInBuildSettings gives the count of total scenes
        if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex=0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
