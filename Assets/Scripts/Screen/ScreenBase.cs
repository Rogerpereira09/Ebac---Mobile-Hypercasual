using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;


        public List<Transform> ListOfObjects;
        public List<Typer> ListOfPhrases;
        public Image uiBackground;

        public bool startHided = false;

        [Header("Animations")]
        public float delayBetweenObjects = .05f;
        public float animationDuration = .3f;

        private void Start()
        {
            if(startHided)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");
        }

        private void HideObjects()
        {
            ListOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            for(int i = 0; i < ListOfObjects.Count; i++)
            {
                var obj = ListOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
            Invoke(nameof(startType), delayBetweenObjects * ListOfObjects.Count);
            uiBackground.enabled = true;
        }
        private void startType()
        {
            for (int i = 0; i < ListOfPhrases.Count; i++)
            {
                ListOfPhrases[i].StartType();
               
            }
        }

        private void ForceShowObjects()
        {
            ListOfObjects.ForEach(i => i.gameObject.SetActive(true));
            uiBackground.enabled = true;
        }

    
     
    }

}