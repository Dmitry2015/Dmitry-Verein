using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDiv7
{
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #1  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // Any one signing up for our new event type must provide a listener method, a "what do you want to do when the event happens"  
        // we need a spec, a contract between the publisher and the subscriber, which is a delegate signature, so define it
        public delegate void DivBy7DelegSignature(object o, DivBy7EventArgs e);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #2  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // When passing in this delagate method as a param to some other method, 
        // we must supply two objects, 

        // the first object is usually a reference to the sending object (e.g., the button object on a form)
        // but in this program, we are just passing a null object which we call o, since we have no use for it

        // the second object, must be a subclass of the EventArgs supplied superclass
        // so we need to define this class to be used as an arguemnt in our delegate method.
        // It can pass back whatever information we want to load it up with
        public class DivBy7EventArgs : EventArgs
        {
            public int TheNumber { get; set; }
        // here we define a property so we can later use  e.TheNumber to get this value

            public DateTime TheTime { get; set; }  // define a property so it can hold the time

        public DivBy7EventArgs(int num)  
            // constructor takes in a number and sets the property to that value.
            {
                TheNumber = num;  // this is just a mechannism to pass the value of our counter when the event happens back to our listeners
            }
    }
              
    
    public class EventGenerator  
        // simulates some other part of an application that does something we want to be told about
        {

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT 4  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public event DivBy7DelegSignature OurEvent;
            // create this "event" thing, which drags in the system code that does all this asyc processing
            // gave it a name, "OurEvent" but its "type" is event
            // requires calrification of the format (signature) of the methods that will be passed into it
            // so here we use our defintion DivBy7DelegSignature (PPT item #1)

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #3a  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // this is our human simulator, to create events
            public void GenNumbers()    //method that causes events to be fired
            // generate 100 sequential numbers and every time we generate a number 
            // that is divisible by 7, raise an event
            {
                for (int i = 0; i < 99; i++)
                {
                    if (i % 7 == 0)
                    {

                    System.Threading.Thread.Sleep(2000);  // 2 seconds pause between events

                    // here we call the constructor for the EventArgs child we defined
                    DivBy7EventArgs EventArgCarriesTheNumber = new DivBy7EventArgs(i);
                    // each time we hit this line of code, we replace the prior eaCarriesTheNumber object with a new one,
                    // which then carries the new value of this number
                    // remember the constructor for the subclass of EventArgs takes an int 
                    // and stores it as a readable property of this object type

                    EventArgCarriesTheNumber.TheTime = DateTime.Now;

                    object ourUselessObject = new object();
                        // create a useless object, just cause we need to pass one in with the Event

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PPT #3b  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        OurEvent(ourUselessObject, EventArgCarriesTheNumber);
                        //  this "fires" the Event, which will then execute every listner method that signed up, 
                        // (each method satisfying the delegate format)
                        // This "event" thing, comes with all the code needed to do this work for us,
                        // sequentially excuting every delegate method that was passed into it (registered)
                        // in the real world, a mouse click would generate a "hardware interrupt", which yanks the CPU
                        // out of what ever it was doing, and runs a "mouse click driver interrupt process" which would
                        // be the code that fires this software event.
                    }
                }
        
        }
    }
}
