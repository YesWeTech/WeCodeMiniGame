//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using System.Collections;
using EasyAR;

namespace Sample
{
    public class HelloARSLAM : MonoBehaviour
    {
        private const string title = "Please enter KEY first!";
        private const string boxtitle = "===PLEASE ENTER YOUR KEY HERE===";
        private const string keyMessage = ""
            + "Steps to create the key for this sample:\n"
            + "  1. login www.easyar.com\n"
            + "  2. create app with\n"
            + "      Name: HelloARSLAM (Unity)\n"
            + "      Bundle ID: cn.easyar.samples.unity.helloarslam\n"
            + "  3. find the created item in the list and show key\n"
            + "  4. replace all text in TextArea with your key";

       // public GUISkin skin;
        GameObject arSceneTracker;
        private ARSceneTrackerBehaviour arSceneBaseBehaviour;

        private void Awake()
        {
            var EasyARBehaviour = FindObjectOfType<EasyARBehaviour>();
            if (EasyARBehaviour.Key.Contains(boxtitle))
            {
#if UNITY_EDITOR
                UnityEditor.EditorUtility.DisplayDialog(title, keyMessage, "OK");
#endif
                Debug.LogError(title + " " + keyMessage);
            }
            EasyARBehaviour.Initialize();
            arSceneTracker = new GameObject("ARSceneTracker");
            arSceneTracker.transform.parent = transform;
        }

       public  void StartSLAM()
        {
            arSceneBaseBehaviour = arSceneTracker.AddComponent<ARSceneTrackerBehaviour>();
            arSceneBaseBehaviour.Bind(ARBuilder.Instance.CameraDeviceBehaviours[0]);
            arSceneBaseBehaviour.StartTrack();
        }

        public void StopSLAM()
        {
            arSceneBaseBehaviour.StopTrack();
            DestroyImmediate(arSceneBaseBehaviour);
        }

       

       public void StartButton()
        {
            if (!arSceneBaseBehaviour)
            {
              
                    StartSLAM();
            }
            else
            {
               
                    StopSLAM();
            }
        }
    }
}
