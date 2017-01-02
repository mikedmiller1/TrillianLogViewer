using System;
using System.Collections.Generic;

namespace TrillianLogViewer
{
    public enum TypeEnum { Incoming, Outgoing };


    /// <summary>
    /// Constructor
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Properties
        /// </summary>
        public string Date;
        public string Time;
        public TypeEnum Type;
        public string Text;



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theMessage"></param>
        public Message( string theMessage )
        {
            // Parse the message into the time, type and text sections using a space as the delimiter
            string[] ParsedMessage = theMessage.Split( ' ' );

            // Get the time
            string TimeString = GetValue( ParsedMessage[ 1 ] );
            TimeString = TimeString.Remove( 10, 3 );
            double TimeDouble = Double.Parse( TimeString );
            DateTime TimeParsed = UnixTimeStampToDateTime( TimeDouble );
            this.Date = TimeParsed.ToShortDateString();
            this.Time = TimeParsed.ToLongTimeString();

            // Get the type
            string TypeString = GetValue( ParsedMessage[ 2 ] );
            switch( TypeString )
            {
                case "incoming_privateMessage":
                    this.Type = TypeEnum.Incoming;
                    break;

                case "outgoing_privateMessage":
                    this.Type = TypeEnum.Outgoing;
                    break;
            }

            // Get the text
            string TextString = GetValue( ParsedMessage[ 3 ] );
            this.Text = Uri.UnescapeDataString( TextString );
        }



        /// <summary>
        /// Returns the value of a string of the form key = "value"
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        private static string GetValue( string theString )
        {
            // Initialize the value string
            string theValue = "";

            // Parse the string at the double quotes
            string[] ParsedString = theString.Split( '"' );

            // Get the value
            theValue = ParsedString[ ParsedString.Length - 2 ];

            // Return the value
            return theValue;
        }



        /// <summary>
        /// Converts a Units time stamp (number of seconds from 1/1/1970) to a DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        private static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            return dtDateTime;
        }
    }
}
