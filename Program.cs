using Assignment_24;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Creating an instance of the Employee class
        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Salary = 50000.0
        };

        // Binary Serialization
        using (FileStream binaryFile = new FileStream("C:\\DAY 21\\employee.bin", FileMode.Create))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(binaryFile, employee);
        }

        // Binary Deserialization
        using (FileStream binaryFile = new FileStream("C:\\DAY 21\\employee.bin", FileMode.Open))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Employee deserializedEmployee = (Employee)binaryFormatter.Deserialize(binaryFile);
            Console.WriteLine("Binary Deserialization:");
            Console.WriteLine(deserializedEmployee);
        }

        // XML Serialization
        using (FileStream xmlFile = new FileStream("C:\\DAY 21\\employee.xml", FileMode.Create))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            xmlSerializer.Serialize(xmlFile, employee);
        }

        // XML Deserialization
        using (FileStream xmlFile = new FileStream("C:\\DAY 21\\employee.xml", FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            Employee deserializedEmployee = (Employee)xmlSerializer.Deserialize(xmlFile);
            Console.WriteLine("\nXML Deserialization:");
            Console.WriteLine(deserializedEmployee);
        }
    }
}
