using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

[assembly: AssemblyVersion("1.0.*")]
public class debugBuildTime : MonoBehaviour
{
    private Text text;
    public Text versiontext;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        string gameVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        print(gameVersion);
        versiontext.text = $"Version {gameVersion}";
        System.Version version = Assembly.GetExecutingAssembly().GetName().Version;
        System.DateTime startDate = new System.DateTime(2000, 1, 1, 0, 0, 0);
        System.TimeSpan span = new System.TimeSpan(version.Build, 0, 0, version.Revision * 2);
        System.DateTime buildDate = startDate.Add(span);
        print(buildDate.ToString());
        string compiledDateAndTime = buildDate.ToString();
        text.text = $"DATE {compiledDateAndTime}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
