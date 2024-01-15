using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public Animator shipAnimator;
    public GameObject shipVolume;

    public GameObject[] famineStoryObjects;
    public int famineStoryObjectIndex;
    public bool famineStop = false;
    public bool famineStoppedOnce = false;
    public string[] famineTexts = new string[] {"[And their crops shall die to disease...]", "[...swarms of Locust blocking the sun, turning daylight into utter darkness...]",
    "[...leaving only barren land that may never bear fruit again.]"};
    public AudioSource[] famineAs;

    public GameObject[] warStoryObjects;
    public int warStoryObjectIndex;
    public bool warStop = false;
    public bool warStoppedOnce = false;
    public string[] warTexts = new string[] {"[Not alive nor dead...]", "[...aimlessly wandering, crying out...]", "[...inconspicuous pleads fade into nothingness.]"};
    public AudioSource[] warAs;

    public GameObject[] conquestStoryObjects;
    public int conquestStoryObjectIndex;
    public bool conquestStop = false;
    public bool conquestStoppedOnce = false;
    public string[] conquestTexts = new string[] {"[Stripped of their self...]", "[...they wander in lines...]", "[...scorching heat as their only salvation.]"};
    public AudioSource[] conquestAs;
    // Start is called before the first frame update
    void Start()
    {
        startFamineStory();
        startWarStory();
        startConquestStory();
    }

    // Update is called once per frame
    void Update()
    {
        StepFurtherInFamineStory();
        StepFurtherInWarStory();
        StepFurtherInConquestStory();

        if(famineStoppedOnce && warStoppedOnce && conquestStoppedOnce)
        {
            shipAnimator.SetTrigger("surface");
            shipVolume.SetActive(true);
        }
    }

    IEnumerator StepFurtherInStories()
    {
        yield return new WaitForSeconds(2.0f);
        StepFurtherInFamineStory();
        StepFurtherInWarStory();
        StepFurtherInConquestStory();
    }

    public void startFamineStory() 
    {
        famineStoryObjectIndex = 0;
        famineStoryObjects[famineStoryObjectIndex].SetActive(true);
        famineAs[famineStoryObjectIndex].Play();
    }

    public void startWarStory() 
    {
        warStoryObjectIndex = 0;
        warStoryObjects[warStoryObjectIndex].SetActive(true);
        warAs[warStoryObjectIndex].Play();
    }

    public void startConquestStory() 
    {
        conquestStoryObjectIndex = 0;
        conquestStoryObjects[conquestStoryObjectIndex].SetActive(true);
        conquestAs[conquestStoryObjectIndex].Play();
    }

    public void StepFurtherInFamineStory()
    {
        if(!famineStop)
        {
            famineStoryObjects[famineStoryObjectIndex].SetActive(false);
            famineAs[famineStoryObjectIndex].volume = 0;
            famineAs[famineStoryObjectIndex].Stop();
            famineStoryObjectIndex++;
            if(famineStoryObjectIndex >= famineStoryObjects.Length)
            {
                famineStoryObjectIndex = 0;
            }
            famineStoryObjects[famineStoryObjectIndex].SetActive(true);
            famineAs[famineStoryObjectIndex].volume = 1;
            famineAs[famineStoryObjectIndex].Play();
        }
    }

    public void StepFurtherInWarStory()
    {
        if(!warStop)
        {
            warStoryObjects[warStoryObjectIndex].SetActive(false);
            warAs[warStoryObjectIndex].volume = 0;
            warAs[warStoryObjectIndex].Stop();
            warStoryObjectIndex++;
            if(warStoryObjectIndex >= warStoryObjects.Length)
            {
                warStoryObjectIndex = 0;
            }
            warStoryObjects[warStoryObjectIndex].SetActive(true);
            warAs[warStoryObjectIndex].volume = 1;
            warAs[warStoryObjectIndex].Play();
        }
    }

    public void StepFurtherInConquestStory()
    {
        if(!conquestStop)
        {
            conquestStoryObjects[conquestStoryObjectIndex].SetActive(false);
            conquestAs[conquestStoryObjectIndex].volume = 0;
            conquestAs[conquestStoryObjectIndex].Stop();
            conquestStoryObjectIndex++;
            if(conquestStoryObjectIndex >= conquestStoryObjects.Length)
            {
                conquestStoryObjectIndex = 0;
            }
            conquestStoryObjects[conquestStoryObjectIndex].SetActive(true);
            conquestAs[conquestStoryObjectIndex].volume = 1;
            conquestAs[conquestStoryObjectIndex].Play();
        }
    }
}
