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
    public partial class frmAddOrder : Form
    {
        // Private Member Variables
        OpenFileDialog opener;

        SaveFileDialog saver;

        List<Product> products;

        int counter;

        //This form is loaded when the user hits "Add Order" 
        public frmAddOrder()
        {
            InitializeComponent();

            // This line initializies the OpenFileDialog settings
            opener = new OpenFileDialog();

            opener.InitialDirectory = "../../PosSystem"; 
            opener.Filter = "Text|*.txt";
            opener.Title = "Select Product File to Open";
            opener.RestoreDirectory = true;

        }

        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            // This should all occur before Add Order form is even loaded.

            // Show OpenFileDialog
            opener.ShowDialog();

            //If statement to make sure file name is listed, and file is there 
            if (opener.FileName != "")
            {
                products = new List<Product>();

                string[] record = null;

                string[] fileContent = File.ReadAllLines(opener.FileName);

                // The foreach statement reads in the file content to store the product name in the combo box
                // then the entire Product object is in the products list
                foreach (string line in fileContent)
                {
                    Product product = new Product();

                    record = line.Split(new char[] { '\t', '\n' });
                    
                    product.ID = int.Parse(record[0]);
                    product.Name = record[1];
                    product.Price = decimal.Parse(record[2]);
                    product.Description = record[3];

                    products.Add(product);

                    string prodText = product.Name; 
                    cmbProducts.Items.Add(prodText);

                }

                txtID.Text = (counter + 1).ToString();
            }
        }

        //If the menu button is clicked, then the user is taken back to the welcome form 
        private void btnMenu_Click(object sender, EventArgs e)
        {
            // this line returns to menu screen 
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        //When the user clicks "Save" order, the following occurs
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            // This opens a SaveFileDialog in order to create a filename for later use
            saver = new SaveFileDialog();
            saver.InitialDirectory = "../../PosSystem";
            saver.Filter = "Text|*.txt";
            saver.Title = "Create A New Customers' Order File";
            saver.ShowDialog();

            // Reset Order counter for new orders file
            counter = 0;
            txtID.Text = (counter + 1).ToString();
        }

        //When the user clicks "Submit" the following occurs 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Save each created order to a selected file
            if (saver.FileName != "")
            {
                string record = txtID.Text + "\t" + cmbProducts.SelectedItem + "\t" +
                            txtPrice.Text + "\t" + txtCustomer.Text + "\n";

                File.AppendAllText(saver.FileName, record);

                //counter is incremented 
                counter++;

                //ID field is incremented, but the rest of the fields are cleared 
                txtID.Text = (counter + 1).ToString();
                cmbProducts.SelectedItem = " ";
                txtPrice.Clear();
                txtCustomer.Clear();
                
                // Alert window created to let user know that information was saved!
                MessageBox.Show(this, "Order #" + counter + " has been saved to our system", "ORDER SAVED", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //This is when the user clicks a product in the combo box, the price must be matched to the product (HARDD!!)
        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate the products price to the selected products name
            string item = cmbProducts.SelectedItem.ToString();
            
            //Had to do a filtered list to find the price 
            var filteredList = from p in products
                               where p.Name == item
                               select p;
            //The price field is populated with the corresponding product price
            txtPrice.Text = filteredList.ElementAt<Product>(0).Price.ToString("c");

        }

       
    }
}
