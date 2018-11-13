using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.ImageEffects {
    public class TimeController : PostEffectsBase
    {
        public GameObject maincmera;
        public GameObject layerrendercamera;
        public GameObject player1;
        public GameObject player2;
        private float t=0;
     
        private int p1andp2 = 768;
        private int p2 = 512;
        private int p1 = 256;
        // Use this for initialization


        // Update is called once per frame
        void FixedUpdate() {
           
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)&&t<=0&& player2.GetComponent<ControllerP2_SLowMotion>().remainLife>1)
            {
                t = 2;
                Time.timeScale = 0.5f;
                maincmera.GetComponent<ColorCorrectionCurves>().saturation = 0;
               
                layerrendercamera.GetComponent<Camera>().cullingMask = p2;
                player2.GetComponent<ControllerP2_SLowMotion>().remainLife--;
                    
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button1)&&t<=0&& player1.GetComponent<ControllerP1_SlowMotion>().remainLife>1)
            {
                t = 2;
                Time.timeScale = 0.5f;
                maincmera.GetComponent<ColorCorrectionCurves>().saturation = 0;
                
                layerrendercamera.GetComponent<Camera>().cullingMask = p1;
                player1.GetComponent<ControllerP1_SlowMotion>().remainLife--;
            }
            t -= Time.deltaTime * (1 / Time.timeScale);
            if (t < 0)
            {
                Time.timeScale = 1f;
                maincmera.GetComponent<ColorCorrectionCurves>().saturation = 1;
                layerrendercamera.GetComponent<Camera>().cullingMask = p1andp2;
            }

        }
    }
}