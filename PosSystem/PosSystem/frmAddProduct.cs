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
    public partial class frmAddProduct : Form
    {
        // Private Member Variable
        SaveFileDialog saver;

        //11 Apr 2021 MBOYCE NEW: This is when the user wants to add a new product 
        public frmAddProduct()
        {
            InitializeComponent();

            // This initializies SaveFileDialog settings (the title, file type, and directory is already set for the user! Neat!)
            saver = new SaveFileDialog();
            saver.InitialDirectory = "../../PosSystem";
            saver.Filter = "Text|*.txt";
            saver.Title = "Save to Products File";
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            // This should all occur before the Add Product form is loaded.

            // This shows the SaveFileDialog  
            saver.ShowDialog();

            //Here the product counter is set 
            txtID.Text = (Product.Counter + 1).ToString();
        }

        //This is when the user hits the "Submit button" 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
          //If statement to make sure the file name is not empty, and there is a file
            if (saver.FileName != "")
            {
                // Here the information is saved to record, and the product is added to the file

                string record = txtID.Text + "\t" + txtName.Text + "\t" +
                          txtPrice.Text + "\t" + txtDescription.Text + "\n";

                File.AppendAllText(saver.FileName, record);

                //The product counter is incremented 
                Product.Counter++;

                //The field displays the incremented counter, and the rest of the fields are cleared for another entry
                txtID.Text = (Product.Counter + 1).ToString();
                txtName.Clear();
                txtPrice.Clear();
                txtDescription.Clear();

                //Message box alerts the user that the product as been saved! Cool feature! 
                MessageBox.Show(this, "Product has been saved to our system", "PRODUCT SAVED",                   
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        //If the user wants to return to the menu, they click the menu button
        private void btnMenu_Click(object sender, EventArgs e)
        {
            // Here the user is returned to the Menu screen 
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        
    }
}
