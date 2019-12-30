using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace SendtoGoogle
{ 
    public class SendtoGoogle : MonoBehaviour
    {
        public Text speechtext;
        private string currentText = "";
        void Update()
        {
            speechtext = GameObject.Find("Text").GetComponent<Text>();
            if (currentText != speechtext.text)
            {
                CreateText(speechtext.text);
                currentText = speechtext.text;
            }
        }

        public void CreateText(string text)
        {
            //Path of file
            string path = Application.dataPath + "/Log.txt";
            //Create file if doesn't exist
            if(!File.Exists(path))
            {
                File.WriteAllText(path, "Speech Streaming Log \n\n");
            }
            //Content of file
            string content = "Speech time: " + System.DateTime.Now + "\n" + "Speech text: " + text + "\n";
            //Add text
            File.AppendAllText(path, content);
        }

    }
}
