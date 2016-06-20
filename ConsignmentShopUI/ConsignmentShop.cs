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
        BindingSource itemsBinding = new BindingSource();

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items;
            itemsListbox.DataSource = itemsBinding;

            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";
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

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "Tom Sawyer",
                Description = "A book about a boy",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 5.20M,
                Owner = store.Vendors[2]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter: Book 2",
                Description = "A book about a wizard",
                Price = 1.50M,
                Owner = store.Vendors[3]
            });

            store.Name = "Seconds are Beter";
        }
    }
}
