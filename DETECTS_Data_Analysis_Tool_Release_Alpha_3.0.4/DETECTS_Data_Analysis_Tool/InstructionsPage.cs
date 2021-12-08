using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DETECTS_Data_Analysis_Tool
{
    public partial class InstructionsPage : Form
    {
        public InstructionsPage()
        {
            InitializeComponent();
        }
        // Assuming you need a custom signature for your event. If not, use an existing standard event delegate
        public delegate void instructionPageClosed(object sender);

        // Expose the event off your component
        public event instructionPageClosed instructionPageClosedEvent;

        private void InstructionPage_FormClosed(Object sender, FormClosedEventArgs e)
        {

            // And to raise it
            var eventSubscribers = instructionPageClosedEvent;
            if (eventSubscribers != null)
            {
                eventSubscribers(this);
            }



        }
        private void InstructionsPage_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
