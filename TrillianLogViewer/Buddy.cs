using System.Collections.Generic;
using System.IO;

namespace TrillianLogViewer
{
    class Buddy
    {
        /// <summary>
        /// Properties
        /// </summary>
        public string Filename;
        public string Name;
        public List< Message > Messages = new List<Message>();
        


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theFilename"></param>
        public Buddy( string theFilename )
        {
            // Assign the filename
            this.Filename = theFilename;

            // Get the buddy name from the filename
            this.Name = GetBuddyName();

            // Read the file
            this.ReadFile();
        }



        /// <summary>
        /// Reads the log file and assigns each line to a Message
        /// </summary>
        private void ReadFile()
        {
            // Create a new file reader
            StreamReader reader = new StreamReader( this.Filename );

            // Try for file reading
            try
            {
                // Loop while the end of the file is not yet reached
                do
                {
                    // Read the current line
                    string CurrentLine = reader.ReadLine();

                    // If this is the history line, skip it
                    if( CurrentLine.Contains( @"<history" ) )
                    {
                        continue;
                    }

                    // Create a new message from the current line
                    this.Messages.Add( new Message( CurrentLine ) );
                    
                } while (reader.Peek() != -1);
            }

            catch { }

            finally
            {
                // Close the file reader
                reader.Close();
            }
        }



        /// <summary>
        /// Gets the buddy name from the filename
        /// </summary>
        /// <returns></returns>
        private string GetBuddyName()
        {
            // Initialize the name string
            string theName = "";

            // Get the filename
            string theFilename = Path.GetFileNameWithoutExtension( this.Filename );

            // Parse at the first dash
            string[] ParseDash = theFilename.Split( '-' );
            theName = ParseDash[ 1 ];

            // Return the name
            return theName;
        }
    }
}
