using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class TimeController1 : PostEffectsBase
    {
        public GameObject maincmera;
        public GameObject layerrendercamera;
        public GameObject player1;
        public GameObject player2;
        private float t = 0;
       

        private int p1andp2 = 1792;
        private int p2 = 1536;
        private int p1 = 1280;
        public ParticleSystem flash;
        public GameObject clock1;
        public GameObject clock2;
        private float internalcd;
        private bool p1flash=false;
        private bool p2flash=false;
        private Vector3 p1pos;
        private Vector3 p2pos;
        // Use this for initialization

        // Update is called once per frame
        void FixedUpdate()
        {
            //Debug.Log(layerrendercamera.GetComponent<Camera>().cullingMask);
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && t <= 0 && player2.GetComponent<ControllerP2_time>().remainLife > 1)
            {
                t = 2;
                Time.timeScale = 0.1f;
                maincmera.GetComponent<ColorCorrectionCurves>().saturation = 0;
                layerrendercamera.GetComponent<Camera>().cullingMask = p2;
                player2.GetComponent<ControllerP2_time>().maxlifecnt--;
                p2pos = player2.GetComponent<ControllerP2_time>().time.Peek();
                float val = player2.GetComponent<ControllerP2_time>().hp.Peek();
                player2.GetComponent<ControllerP2_time>().remainLife = val > player2.GetComponent<ControllerP2_time>().maxlifecnt ? player2.GetComponent<ControllerP2_time>().maxlifecnt : val;
                clock1.SendMessage("setflag", Time.time);
                clock2.SendMessage("setflag", Time.time);
                Instantiate(flash, p2pos, Quaternion.identity);
                p2flash = true;
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button0) && t <= 0 && player1.GetComponent<ControllerP1_CostOfTime>().remainLife > 1)
            {
                t = 2;
               
                Time.timeScale = 0.1f;
                maincmera.GetComponent<ColorCorrectionCurves>().saturation = 0;
                layerrendercamera.GetComponent<Camera>().cullingMask = p1;
                player1.GetComponent<ControllerP1_CostOfTime>().maxlifecnt--;
                p1pos = player1.GetComponent<ControllerP1_CostOfTime>().time.Peek();
                float val = player1.GetComponent<ControllerP1_CostOfTime>().hp.Peek();
                player1.GetComponent<ControllerP1_CostOfTime>().remainLife = val > player1.GetComponent<ControllerP1_CostOfTime>().maxlifecnt ? player1.GetComponent<ControllerP1_CostOfTime>().maxlifecnt : val;
                clock1.SendMessage("setflag", Time.time);
                clock2.SendMessage("setflag", Time.time);
                Instantiate(flash, p1pos, Quaternion.identity);
                p1flash = true;
            }
            t -= Time.deltaTime * (1 / Time.timeScale);
         
            if (t < 0)
            {
                Time.timeScale = 1f;
                maincmera.GetComponent<ColorCorrectionCurves>().saturation = 1;
                layerrendercamera.GetComponent<Camera>().cullingMask = p1andp2;
                if (p2flash)
                {
                    player2.transform.position = p2pos;
                    p2flash = false;
                }
                if (p1flash)
                {
                    player1.transform.position = p2pos;
                    p1flash = false;
                }
            }

        }
    }
}