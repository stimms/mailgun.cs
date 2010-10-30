using System;
using System.Collections.Generic;
using MailgunClient;

namespace MailgunSamples
{
    class RouteSample
    {
        /// <summary>
        /// Prints all routes under your account
        /// </summary>
        public static void printRoutes() 
        {
            List<Route> list = Route.Find();
            Console.WriteLine("Routes: {0}", list.Count);
            foreach (Route r in list)
                Console.WriteLine("{0}\t=> {1}", r.Pattern, r.Destination);
        }

        /// <summary>
        /// Update destination of all routes
        /// </summary>
        public static void updateRoutes()
        {
            Console.WriteLine("Updating...");
            foreach (Route r in Route.Find())
            {
                Console.WriteLine(r.Id);
                r.Destination = r.Destination.Replace("feedback", "handler");
                r.Save();
            }
        }

        public static void deleteRoutes()
        {
            Console.WriteLine("Removing routes we've created...");
            foreach (Route r in Route.Find())
                if (r.Destination.StartsWith("http://samples.mailgun.org"))
                {
                    Console.WriteLine(r.Id);
                    r.Delete();
                }
        }


        public static void Main()
        {
            Mailgun.Init("key-afy6amxoo2fnj$u@mc");

            Route route = new Route("*@samples.mailgun.org", "http://samples.mailgun.org/feedback");
            try
            {
                // Create new route
                route.Upsert();
                printRoutes();

                // Update it
                updateRoutes();
                printRoutes();
                
                // And remove
                deleteRoutes();
                printRoutes();
            }
            catch (MailgunException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
