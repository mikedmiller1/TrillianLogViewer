using System.Collections.Generic;
using System.IO;

namespace TrillianLogViewer
{
    class History
    {
        /// <summary>
        /// Properties
        /// </summary>
        private readonly string HistoryFolderName = @"C:\Users\Mike\AppData\Roaming\Trillian\users\drdisco69\logs\_CLOUD\";
        public List<string> BuddyNames = new List<string>();
        public List<Buddy> Buddies = new List<Buddy>();
        private List<Year> Years = new List<Year>();



        /// <summary>
        /// Constructor
        /// </summary>
        public History()
        {
            // Get the list of years
            string[] YearList = Directory.GetDirectories( HistoryFolderName );
            foreach( string YearName in YearList )
            {
                Years.Add( new Year( YearName ) );
            }


            // Get the list of buddies
            this.BuddyNames = this.GetBuddyNames();
        }



        /// <summary>
        /// Returns a list of buddy names
        /// </summary>
        /// <returns></returns>
        public List<string> GetBuddyNames()
        {
            // Initialize the buddy name list
            List<string> theNames = new List<string>();

            // Loop through the years
            foreach( Year CurrentYear in this.Years )
            {
                // Get the current buddy list
                List<string> CurrentBuddies = CurrentYear.GetBuddyNames();

                // Loop through the current buddies
                foreach( string CurrentBuddy in CurrentBuddies )
                {
                    // If it does not exist in the main list
                    if( !theNames.Contains( CurrentBuddy ) )
                    {
                        // Add it to the list
                        theNames.Add( CurrentBuddy );
                    }
                }
            }

            // Sort the list alphabetically
            theNames.Sort();

            // Return the buddy name list
            return theNames;
        }



        public List<Message> GetMessages( string Buddy )
        {
            // Initialize the message list
            List<Message> theMessages = new List<Message>();

            // Loop through the years
            foreach( Year CurrentYear in this.Years )
            {
                // Get the messages for the current year
                List<Message> CurrentMessages = CurrentYear.GetMessages( Buddy );

                // Add the messages to the main list
                theMessages.AddRange( CurrentMessages );
            }

            // Return the message list
            return theMessages;
        }
    }
}
