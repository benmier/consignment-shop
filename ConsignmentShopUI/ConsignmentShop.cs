using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();
        }

        private void ConsignmentShop_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void shoppingCartListboxLabel_Click(object sender, EventArgs e)
        {

        }

        private void SetupData()
        {
            store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Jones" });
            store.Vendors.Add(new Vendor { FirstName = "Jim", LastName = "Howe" });
            store.Vendors.Add(new Vendor { FirstName = "John", LastName = "Nash" });
            store.Vendors.Add(new Vendor { FirstName = "Gale", LastName = "McDonald" });

            store.Items.Add(new Vendor { Title = "Moby Dick", Description = "A book about a whale", Price = 4.50, Owner = store.Vendors[0]});

        }
    }
}
