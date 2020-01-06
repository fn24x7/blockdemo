using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.Common;

[RequireComponent(typeof(RawImage))]
public class QRCodedemo : MonoBehaviour
{
    [SerializeField] private BarcodeFormat format = BarcodeFormat.QR_CODE;
    [SerializeField] private string data = "test";
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;

    static int i = 0;

    public RawImage cRawImage;
    public Texture2D tex;
    //public Button button;

    void Start()
    {
        cRawImage = GetComponent<RawImage>();

        // Generate the texture
        AssignData();
        //AssignTex();
    }

    private void AssignData ()
    {
        data = "Start on " + System.DateTime.Now;
    }

    public void AssignTex()
    {
        tex = GenerateBarcode(data, format, width, height);

        // Setup the RawImage
        cRawImage.texture = tex;
        cRawImage.rectTransform.sizeDelta = new Vector2(tex.width, tex.height);
    }

    public void SaveTex()
    {
        string filepath = Application.dataPath + "/QRLog";
        byte[] imageBytes = tex.EncodeToPNG();
        bool filecheck = false;

        while (!filecheck)
        { 
            if (!File.Exists(filepath + "/QR Code - " + i + ".png"))
            {
                File.WriteAllBytes(filepath + "/QR Code - " + i + ".png", imageBytes);
                filecheck = true;
            }

            i++;
        }
        
        
    }

    private Texture2D GenerateBarcode(string data, BarcodeFormat format, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Height = height,
                Width = width
            }
        };

        Debug.Log("Generating QR Code...");

        Color32[] pixels = writer.Write(data);

        Texture2D tex1 = new Texture2D(width, height);
        tex1.SetPixels32(pixels);
        tex1.Apply();

        return tex1;
    }
}