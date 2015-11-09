namespace ConsumingWebServices
{
    using System;
    using System.IO;
    using System.Net;
    
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter a query to search by - i.e \"best places to eat\"");
            string query = Console.ReadLine();
            Console.WriteLine("Enter a positive number of results to display and press enter. Maxinum is 40");
            uint maxResults = uint.Parse(Console.ReadLine());

            var request = WebRequest.Create(string.Format(
                "https://www.googleapis.com/books/v1/volumes?q={0}&maxResults={1}&key=AIzaSyCPtdYm7kpbdI5FAysIr3LiJwVjzRIivd4",
                query,maxResults));

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
        }
    }
}
