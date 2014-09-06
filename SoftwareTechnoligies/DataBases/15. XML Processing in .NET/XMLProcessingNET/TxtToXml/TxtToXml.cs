using System;
using System.IO;
using System.Text;
using System.Xml;

public class TxtToXml
{
    private static string[] Names = { "Anna", "Boris", "Vasil", "Gergana", "Dimitar", "Elena", "Zdravko", "Ivan", "Kalina","Lyubomir","Maria","Nasko","Ogi",
                                    "Pesho","Ralitza","Sasho","Tosho","Hristina"};
    private static string[] Address = { "Burgas, ul. {0}-ta", "Varna, ul. {0}-ta", "Gorno Uyno, ul. {0}-ta", "Dobritch, ul. {0}-ta", "Elena, ul. {0}-ta",
                                          "Kalofer, ul. {0}-ta", "Montana, ul. {0}-ta", "Plovdiv, ul. {0}-ta", "Ruse, ul. {0}-ta", "Sofia, ul. {0}-ta"};
    private static string PhoneNumber = "{0:D3}-{1:D3}-{2:D3}";

    private static Random rnd = new Random();
    private static int NumberOfPersons = 200;
    private static string xmlFilePath = @"../../../temp";
    private static string txtInputFileName = @"/07.inputText.txt";
    private static string xmlFileName = @"/07.persons.xml";

    public static void Main()
    {
        GenerataInputTextFile(NumberOfPersons);
        GenerateXml();
    }

    private static void GenerataInputTextFile(int numberOfPersons)
    {
        TextWriter writer = File.CreateText(xmlFilePath + txtInputFileName);
        using (writer)
        {
            for (int person = 0; person < numberOfPersons; person++)
            {
                writer.WriteLine(Names[rnd.Next(Names.Length)]);
                writer.WriteLine(string.Format(Address[rnd.Next(Address.Length)], rnd.Next(100)));
                writer.WriteLine(string.Format(PhoneNumber, rnd.Next(1000), rnd.Next(1000), rnd.Next(1000)));
            }
        }
    }
    private static void GenerateXml()
    {
        StreamReader reader = new StreamReader(xmlFilePath + txtInputFileName);
        using (reader)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter(xmlFilePath + xmlFileName, encoding);
            string line = string.Empty;
            int counter = 0;
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("Persons");

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 3 == 0)
                    {
                        writer.WriteStartElement("Person");
                    }

                    switch (counter % 3)
                    {
                        case 0:
                            {
                                writer.WriteElementString("Name", line);
                                break;
                            }
                        case 1:
                            {
                                writer.WriteElementString("Address", line);
                                break;
                            }
                        case 2:
                            {
                                writer.WriteElementString("PhoneNumber", line);
                                writer.WriteEndElement();
                                break;
                            }
                        default:
                            break;
                    }

                    counter++;
                }

                writer.WriteEndDocument();
            }
        }
    }
}