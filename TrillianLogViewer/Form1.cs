using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrillianLogViewer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Properties
        /// </summary>
        private int SelectedBuddyIndex;
        private string SelectedBuddyName;
        private History theHistory;



        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();


            // Create a new history
            theHistory = new History();

            // Assign the names to the combo box
            this.BuddyNameCombo.DataSource = theHistory.BuddyNames;
        }



        /// <summary>
        /// Called when the buddy combo box is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BuddyNameCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            // Get the selected index
            this.SelectedBuddyIndex = BuddyNameCombo.SelectedIndex;

            // Get the selected buddy name
            this.SelectedBuddyName = theHistory.BuddyNames[ this.SelectedBuddyIndex ];

            // Get the message list
            List<Message> MessageList = this.theHistory.GetMessages( this.SelectedBuddyName );

            // Get the message text list
            string MessageText = this.GetMessageText( MessageList );

            // Assign the message text to the text box
            this.HistoryText.Text = MessageText;
        }



        /// <summary>
        /// Returns a string of messages from the input list of messages
        /// </summary>
        /// <param name="theMessageList"></param>
        /// <returns></returns>
        public string GetMessageText( List<Message> theMessageList )
        {
            // Initialize the message string
            string theMessageText = "";

            // Loop through the messages
            foreach( Message CurrentMessage in theMessageList )
            {
                // Get the sender
                string CurrentSender = "";
                switch (CurrentMessage.Type)
                {
                    case TypeEnum.Incoming:
                        CurrentSender = this.SelectedBuddyName;
                        break;

                    case TypeEnum.Outgoing:
                        CurrentSender = "Me";
                        break;
                }

                // Add the current message to the string
                theMessageText += CurrentMessage.Date + " " + CurrentMessage.Time + " " + CurrentSender + ": " + CurrentMessage.Text + Environment.NewLine;
            }

            // Return the message string
            return theMessageText;
        }
    }
}
