using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

public class ProjectSerializer
{
    public static void SaveProjects(List<Project> projects, string filePath)                //ЗБЕРЕЖЕННЯ ДАНИХ
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Project>), new Type[] { typeof(WebDevelopmentProject), typeof(MobileDevelopmentProject) });
        using (TextWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, projects);
        }
    }

    public static List<Project> LoadProjects(string filePath)                               //вивантаження проэктів 
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Project>), new Type[] { typeof(WebDevelopmentProject), typeof(MobileDevelopmentProject) });
        using (TextReader reader = new StreamReader(filePath))
        {
            return (List<Project>)serializer.Deserialize(reader);
        }
    }
}
