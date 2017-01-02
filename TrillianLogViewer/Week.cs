using System.Collections.Generic;
using System.IO;

namespace TrillianLogViewer
{
    class Week
    {
        /// <summary>
        /// Properties
        /// </summary>
        public string Name;
        public List<Buddy> Buddies = new List<Buddy>();



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theName"></param>
        public Week( string theName )
        {
            // Assign the name
            this.Name = theName;

            // Get the list of buddy chat log files
            string[] BuddyList = Directory.GetFiles( this.Name );
            foreach (string BuddyName in BuddyList)
            {
                // Only add xml files
                if (BuddyName.EndsWith( ".xml" ))
                {
                    Buddies.Add( new Buddy( BuddyName ) );
                }
            }
        }



        /// <summary>
        /// Returns a list of buddy names
        /// </summary>
        /// <returns></returns>
        public List<string> GetBuddyNames()
        {
            // Initialize the buddy name list
            List<string> theNames = new List<string>();

            // Loop through the buddies
            foreach (Buddy CurrentBuddy in this.Buddies)
            {
                // Add the name to the list
                theNames.Add( CurrentBuddy.Name );
            }

            // Return the buddy name list
            return theNames;
        }



        /// <summary>
        /// Returns a list of messages for the specified buddy
        /// </summary>
        /// <returns></returns>
        public List<Message> GetMessages( string Buddy )
        {
            // Initialize the message list
            List<Message> theMessages = new List<Message>();

            // Get the buddy
            Buddy theBuddy = this.GetBuddy( Buddy );

            // If the buddy was found
            if( !(theBuddy == null) )
            {
                // Get the messages
                theMessages = theBuddy.Messages;
            }

            // Return the message list
            return theMessages;
        }



        /// <summary>
        /// Returns a list of messages from the specified buddy
        /// </summary>
        /// <param name="theBuddyName"></param>
        /// <returns></returns>
        private Buddy GetBuddy( string theBuddyName )
        {
            // Initialize the buddy
            Buddy theBuddy = null;

            // Find the buddy in the list
            theBuddy = this.Buddies.Find( item => item.Name == theBuddyName );

            // Return the buddy
            return theBuddy;
        }
    }
}
