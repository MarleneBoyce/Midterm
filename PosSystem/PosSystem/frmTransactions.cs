using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    public partial class frmTransactions : Form
    {
        // Private Member Variable
        OpenFileDialog opener;

        //11 Apr 2021 MBOYCE NEW: This opens the "Transactions" form 
        public frmTransactions()
        {
            InitializeComponent();

            // This Initializies OpenFileDialog settings
            opener = new OpenFileDialog();

            opener.InitialDirectory = "../../PosSystem";
            opener.Filter = "Text|*.txt";
            opener.Title = "Select Customer's Order File to Open";
            opener.RestoreDirectory = true;
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            // This should all occur before the Transactions form is loaded.

            // This line shows the OpenFileDialog
            opener.ShowDialog();
            
            //If statement to ensure the file name is not empty, and there is a file
            if (opener.FileName != "")
            {
                string[] record = null;

                string[] fileContent = File.ReadAllLines(opener.FileName);

                // This foreach statement prints the file content to txtTransactions.
                foreach (string line in fileContent)
                {
                    record = line.Split(new char[] { '\t', '\n' });

                    //Text is appended and formatted 
                    txtTranactions.AppendText(
                                              "Order #" + record[0] + Environment.NewLine +
                                              "Name: " + record[1] + Environment.NewLine +
                                              "Price: " + record[2] + Environment.NewLine +
                                              "Customer Name: " + record[3] + Environment.NewLine + Environment.NewLine
                                             );

                }
            }
        }

        //On the Transactions form, there is a menu button, when clicked it'll take the user to the menu form 
        private void btnMenu_Click(object sender, EventArgs e)
        {
            // This line returns the user to Menu screen (frmWelcome)
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

    }
}
