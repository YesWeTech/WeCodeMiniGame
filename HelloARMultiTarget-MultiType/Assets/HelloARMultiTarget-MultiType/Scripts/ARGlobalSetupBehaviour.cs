//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using EasyAR;

namespace Sample
{
    public class ARGlobalSetupBehaviour : MonoBehaviour
    {
        private const string title = "Please enter KEY first!";
        private const string boxtitle = "===PLEASE ENTER YOUR KEY HERE===";
        private const string keyMessage = ""
            + "Steps to create the key for this sample:\n"
            + "  1. login www.easyar.com\n"
            + "  2. create app with\n"
            + "      Name: HelloARMultiTarget-MultiType (Unity)\n"
            + "      Bundle ID: cn.easyar.samples.unity.helloarmultitarget.mt\n"
            + "  3. find the created item in the list and show key\n"
            + "  4. replace all text in TextArea with your key";

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
            foreach (var behaviour in ARBuilder.Instance.ARCameraBehaviours)
            {
                behaviour.TargetFound += OnTargetFound;
                behaviour.TargetLost += OnTargetLost;
            }
            foreach (var behaviour in ARBuilder.Instance.ImageTrackerBehaviours)
            {
                behaviour.TargetLoad += OnTargetLoad;
                behaviour.TargetUnload += OnTargetUnload;
            }
            foreach (var behaviour in ARBuilder.Instance.ObjectTrackerBehaviours)
            {
                behaviour.TargetLoad += OnTargetLoad;
                behaviour.TargetUnload += OnTargetUnload;
            }
        }

        void OnTargetFound(ARCameraBaseBehaviour arcameraBehaviour, TargetAbstractBehaviour targetBehaviour, Target target)
        {
            Debug.Log("<Global Handler> Found: " + target.Id);
        }

        void OnTargetLost(ARCameraBaseBehaviour arcameraBehaviour, TargetAbstractBehaviour targetBehaviour, Target target)
        {
            Debug.Log("<Global Handler> Lost: " + target.Id);
        }

        void OnTargetLoad(ImageTrackerBaseBehaviour trackerBehaviour, ImageTargetBaseBehaviour targetBehaviour, Target target, bool status)
        {
            Debug.Log("<Global Handler> Load target (" + status + "): " + target.Id + " (" + target.Name + ") " + " -> " + trackerBehaviour);
        }

        void OnTargetUnload(ImageTrackerBaseBehaviour trackerBehaviour, ImageTargetBaseBehaviour targetBehaviour, Target target, bool status)
        {
            Debug.Log("<Global Handler> Unload target (" + status + "): " + target.Id + " (" + target.Name + ") " + " -> " + trackerBehaviour);
        }

        void OnTargetLoad(ObjectTrackerBaseBehaviour trackerBehaviour, ObjectTargetBaseBehaviour targetBehaviour, Target target, bool status)
        {
            Debug.Log("<Global Handler> Load target (" + status + "): " + target.Id + " (" + target.Name + ") " + " -> " + trackerBehaviour);
        }

        void OnTargetUnload(ObjectTrackerBaseBehaviour trackerBehaviour, ObjectTargetBaseBehaviour targetBehaviour, Target target, bool status)
        {
            Debug.Log("<Global Handler> Unload target (" + status + "): " + target.Id + " (" + target.Name + ") " + " -> " + trackerBehaviour);
        }
    }
}
