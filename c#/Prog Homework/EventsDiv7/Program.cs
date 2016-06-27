using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDiv7
{
    // http://www.codeproject.com/Articles/1474/Events-and-event-handling-in-C

    // generate some numbers and every time we generate a number 
    // that is divisible by 7, raise an event
    // The event handler will write message saying the event was raised, 
    // & also the number responsible for raising the event.

  

    public class UseEvents
    {

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #6  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public static void Main() 
        {
            // This is "composition" as we are composing our public class UseEvents by using the new 
            // key work to make this listener object part of this object.  We are dragging in some
            // code we want to use by bringing in an object from that class
            // we could have just coded the listener in here, rather than brining the code in as an object

            DivBy7Listener dbsListener = new DivBy7Listener();   // instantiate a listener, a subscriber, (class defined below)
                                                                 // It will register and then sleep, waiting an event

            DivBy7Listener2 dbsListener2 = new DivBy7Listener2();   // instantiate a listener2, a subscriber, (class defined below)
                                                                    // It will register and then sleep, waiting an event

            EventGenerator myEventGenerator = new EventGenerator();
            // instantiate our ~fake event generator, a Publisher, so that we have something to listen for


            // When an event occurs, "all" the event handlers are ‘notified’ 
            // (this simply means that all the event handler call back methods are invoked).

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #5b  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // we our adding our method (ShowOnSCreen) to a list of methods that the 
            // myEventGenerator object will process whenever it decides there is an event
            // so we pass in our "delelate conformant" method to the event ( OurEvent )
            myEventGenerator.OurEvent += new DivBy7DelegSignature(dbsListener.ShowOnScreen);
            // the event must know all the methods that expect to be notified (executed) when an event happens
            // So here, we "add" +=  a delegate method to the event (it can have multiple)

            myEventGenerator.OurEvent += new DivBy7DelegSignature(dbsListener2.ShowOnScreen); // for dbsListener2

            myEventGenerator.GenNumbers();
            // simple method call to kick off our synthetic event generator, 
            // which generates 100 sequential numbers
            // instead we could have started a game, and wait for mouse events

            Console.ReadLine();  // we are now done, and the rest of this all excutes based on events.
        }

    }

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #5a  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


    // Here is our class that wants something done when an event happens
    // Inside we find a method we used to "register" with the event (just above in the Main method)
    // We tell the event, run this when "it" happens
    public class DivBy7Listener    // our listener, our subscriber
    {
        public void ShowOnScreen(object o, DivBy7EventArgs e)  // notice this method matches the signature as required
        {
            Console.WriteLine(
                "divisible by seven event raised!!! the guilty party is {0}", e.TheNumber);
            // The event process created a DivBy7EventArgs object, e, and loaded it with the number which caused the event
            // so now we can access the property of the e object and write it out
        }
    }

    public class DivBy7Listener2    // our listener2, our subscriber
    {
        public void ShowOnScreen(object o, DivBy7EventArgs e)  // notice this method matches the signature as required
        {
            Console.WriteLine(
                "The time is {0}", e.TheTime);
        }
    }
}

