using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    //11 Apr 2021 MBOYCE NEW FORM: "Home Page" or "Menu Page" 
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }
        //11 Apr 2021 MBOYCE NEW: This is when the button "Add Product is clicked"
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // This hides the "Welcome Form"
            this.Hide();
          
            // This opens the "Add Product" Form
            Form productForm = new frmAddProduct();
            productForm.ShowDialog();

            // This displays the "Welcome form" again
            this.Show();
        }

        //11 Apr 2021 MBOYCE NEW: This occurs when the user clicks "Add Order" 
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // This hides the "Welcome" Form
            this.Hide();

            // This opens the "Add Order" Form
            Form orderForm = new frmAddOrder();
            orderForm.ShowDialog();

            // This displays the "Welcome" form again
            this.Show();
        }

        //11 Apr 2021 MBOYCE NEW: This occurs when the user wants to see all transactions
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            // This hides the "Welcome" Form
            this.Hide();

            // This opens the "Transactions" Form
            Form transactionForm = new frmTransactions();
            transactionForm.ShowDialog();

            // This displays the "Welcome" form again
            this.Show();
        }

       
    }
}
