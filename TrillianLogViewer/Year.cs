using System.Collections.Generic;
using System.IO;

namespace TrillianLogViewer
{
    /// <summary>
    /// Year
    /// </summary>
    class Year
    {
        /// <summary>
        /// Properties
        /// </summary>
        public string Name;
        public List<Week> Weeks = new List<Week>();



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theName"></param>
        public Year( string theName )
        {
            // Assign the name
            this.Name = theName;

            // Get the list of weeks
            string[] WeekList = Directory.GetDirectories( this.Name );
            foreach (string WeekName in WeekList)
            {
                Weeks.Add( new Week( WeekName ) );
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

            // Loop through the weeks
            foreach (Week CurrentWeek in this.Weeks)
            {
                // Get the current buddy list
                List<string> CurrentBuddies = CurrentWeek.GetBuddyNames();

                // Loop through the current buddies
                foreach (string CurrentBuddy in CurrentBuddies)
                {
                    // If it does not exist in the main list
                    if (!theNames.Contains( CurrentBuddy ))
                    {
                        // Add it to the list
                        theNames.Add( CurrentBuddy );
                    }
                }
            }

            // Return the buddy name list
            return theNames;
        }



        /// <summary>
        /// Returns a list of messages from the specified buddies
        /// </summary>
        /// <param name="Buddy"></param>
        /// <returns></returns>
        public List<Message> GetMessages( string Buddy )
        {
            // Initialize the message list
            List<Message> theMessages = new List<Message>();

            // Loop through the weeks
            foreach( Week CurrentWeek in this.Weeks )
            {
                // Get the messages for the current week
                List<Message> CurrentMessages = CurrentWeek.GetMessages( Buddy );

                // Add the messages to the main list
                theMessages.AddRange( CurrentMessages );
            }
            
            // Return the message list
            return theMessages;
        }
    }
}
