   using System;
   using Newtonsoft.Json;

   namespace MyCliApp
   {
       class Program
       {
           static void Main(string[] args)
           {
               var person = new
               {
                   Name = "John Doe",
                   Age = 30
               };

               // Serialize the object to JSON
               string json = JsonConvert.SerializeObject(person, Formatting.Indented);

               Console.WriteLine("Serialized JSON:");
               Console.WriteLine(json);

               // Deserialize the JSON back to an object
               var deserializedPerson = JsonConvert.DeserializeObject(json);

               Console.WriteLine("Deserialized Object:");
               Console.WriteLine(deserializedPerson);
           }
       }
   }
   