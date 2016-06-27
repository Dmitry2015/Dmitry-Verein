using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLL
{
    class WorkItenLinkedList
    {
        //*********************************************************************************************
        // define our Nested Class, a class that defines the objects that are in the linked lists
        protected class LinkedListNode
        {
            // get rid of this ...
            //public int node_data;  // 

            // add this new item, to hold data
            public WorkItem nodeWorkItem; // holds an object with real data

            // this is unchanged
            public LinkedListNode node_next_pointer;  // Property holds the "pointer" (actually a node with a pointer in it)  to the next node in the list

            // constructor: call it to create and store the data object 
            public LinkedListNode(WorkItem pWorkItem)
            {
                nodeWorkItem = pWorkItem; // set the value of the data object to the one passed in
                //pWorkItem.Value;
                //pWorkItem.What;
                //pWorkItem.Why;

            }
        }
        //*********************************************************************************************

        // now define the WorkItemLinkedList Class members
        // the only data item the class has is the pointer (actually a node with a pointer in it) to the first item in the list 
        protected LinkedListNode frontOfList; // either null for empty list, or it holds the name of the first node in the list

        //*********************************************************************************************

        // Method to add a node to the front of the list:  // only change needed was to change the method argument from int to WorkItem
        public void InsertAtFront(WorkItem pWorkItem)
        {
            LinkedListNode newNode = new LinkedListNode(pWorkItem);  // create a new node
            newNode.node_next_pointer = frontOfList; // make this new first node point to what was just the first node;
            // if the List had been empty, then we just made the newNode point to "null", which says there is no 2nd node.
            frontOfList = newNode; // change the "reference" to front of list to point to this new one, which itself now points to the prior front of list
            // we are dealing with this frontOfList because this method specifically says to add to the front.  Later we will insert into other places.
        }
        //*********************************************************************************************

        // Method to remove the node from the front of the list
        public WorkItem RemoveFromFront()  // just had to change method from int to return a WorkItem instead
        {
            WorkItem returnWorkItem = new WorkItem();

            if (frontOfList == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }
            else
            {
                // add extra step here, get the object to return out of the node
                returnWorkItem = frontOfList.nodeWorkItem; // get the object from the node at the front of the list
                frontOfList = frontOfList.node_next_pointer;  // copy the front of list's node's pointer to the next node, into the front of List
                // if there was not another node, we just copied a null into the pointer, which says the list is now empty
            }
            return returnWorkItem;
        }

        //*********************************************************************************************

        // Method to add a node in order, based on the Value field, in the list:
        public void InsertInOrder(WorkItem pWorkItem)
        {

            //If frontOfList is null (list is empty) or, if value of frontOfList node is less or same as the newData value
            // just call our existing method InsertAtFront(newData)

            // this has to changd
            if (frontOfList == null || frontOfList.nodeWorkItem.Value >= pWorkItem.Value)  // watch the pointers to see what happens
            {
                InsertAtFront(pWorkItem);
            }
            else  // we have to traverse the LL and find where to add a new node
            {
                LinkedListNode newNode = new LinkedListNode(pWorkItem);  // create a new node
                LinkedListNode current = frontOfList;

                //In a while loop, keep walking down the list as long as the current node’s next pointer is not null, 
                // AND the cur node’s next pointer.node’s value is less then our new datavalue.

                // note, the following two part AND statement will fail if you reverse the order of the test.
                // the null gets tested on the first part, and therefore the code after the && does not execute and throw an exception when it is null.

                // this line changed
                while (current.node_next_pointer != null && current.node_next_pointer.nodeWorkItem.Value < pWorkItem.Value)
                {
                    current = current.node_next_pointer; // move the value of our pointer to walk down one step in the list
                }

                // when we exit the while loop, we know current is pointing in front of the item where we want the new item
                // either the end of the list, or for example, its pointing to the 3 element and we want the new one to be the 3 element
                // following lines will plug in either the correct value for node_next_pointer, pointing to the next node in the list, or
                // if we are at the end of the list, it will copy a null into its pointer, making it the end of the list
                newNode.node_next_pointer = current.node_next_pointer;  //either a null if at end, or a pointer to what should be the next node
                current.node_next_pointer = newNode;  // we just inserted a new node after the one currernt is pointing too, so need to update current's pointer to the new node
                return;
            }
        }

        //*********************************************************************************************

       
    }
}