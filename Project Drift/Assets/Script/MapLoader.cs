using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MapLoader : MonoBehaviour
{

    public string Directory = Environment.CurrentDirectory + "\\Maps";
    public string MapName;
    public bool LoadFromUnityAssets;
    public GameObject Plane;
    void Start()
    {
        string buffer = null;
        if (LoadFromUnityAssets)
        {
            Directory = Directory.Remove(Environment.CurrentDirectory.Length) + "\\Assets\\Maps";
        }
        string[] data = new string[File.ReadAllLines(Directory + "\\" + MapName + ".dmap").Length];
        using (StreamReader reader = new StreamReader(Directory + "\\" + MapName + ".dmap"))
        {
            int i = 0;
            buffer = reader.ReadLine();
            while (buffer != null)
            {
                data[i] = buffer;
                buffer = reader.ReadLine();
                i++;
            }
            Debug.Log("Read " + data.Length + " lines. Constructing scene.");
            i = 0;
            while (i != data.Length)
            {
                if (data[i].Length >= 4)
                {
                    if (data[i].Substring(4, 17) == "public GameObject")
                    {
                        int PropertiesBegin = 0;
                        bool found = false;
                        while (found != true)
                        {
                            if (data[i].Substring(PropertiesBegin, 1) == "[")
                            {
                                found = true;
                            }
                            PropertiesBegin++;
                        }
                        int PropertiesEnd = PropertiesBegin;
                        found = false;
                        while (found != true)
                        {
                            if (data[i].Substring(PropertiesEnd, 1) == "]")
                            {
                                found = true;
                            }
                            PropertiesEnd++;
                        }
                        if (data[i].Substring(PropertiesBegin, 5) == "Plane")
                        {
                            int PosEnd = PropertiesBegin + 6;
                            found = false;
                            while (found != true)
                            {
                                if (data[i].Substring(PosEnd, 1) == " ")
                                {
                                    PosEnd -= 1;
                                    found = true;
                                }
                                PosEnd++;
                            }
                            PosEnd = PosEnd - (PropertiesBegin + 6);
                            buffer = data[i].Substring(29, PosEnd);
                            string[] Pos = buffer.Split(',');
                            Vector3 pos = new Vector3(
                                float.Parse(Pos[0]),
                                float.Parse(Pos[1]),
                                float.Parse(Pos[2]));
                            buffer = data[i].Substring(PosEnd + 2, PropertiesEnd);
                            string[] Rot = buffer.Split(',');
                            Quaternion rot = new Quaternion(
                                float.Parse(Rot[0]),
                                float.Parse(Rot[1]),
                                float.Parse(Rot[2]),
                                float.Parse(Rot[3]));
                            Instantiate(Plane, pos, rot);
                            Debug.Log("Created Plane at " + pos.x.ToString() + ", " + pos.y.ToString() + ", " + pos.z.ToString() + ".");
                        }
                    }
                }
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
