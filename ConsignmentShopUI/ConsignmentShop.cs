﻿using ConsignmentShopLibrary;
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
        private List<Item> shoppingCartData = new List<Item>();
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();
        private decimal storeProfit = 0;

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold==false).ToList();
            itemsListbox.DataSource = itemsBinding;
            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListbox.DataSource = cartBinding;
            shoppingCartListbox.DisplayMember = "Display";
            shoppingCartListbox.ValueMember = "Display";

            vendorsBinding.DataSource = store.Vendors;
            vendorListbox.DataSource = vendorsBinding;
            vendorListbox.DisplayMember = "Display";
            vendorListbox.ValueMember = "Display";
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

        private void addToCart_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemsListbox.SelectedItem;
            bool inCart = false;
            foreach(Item x in shoppingCartData)
            {
                if (selectedItem == x)
                {
                    MessageBox.Show("Cannot add duplicates!");
                    inCart = true;
                    break;
                }
            }
            if (!inCart) { shoppingCartData.Add(selectedItem); }
            cartBinding.ResetBindings(false);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            foreach(Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += item.Price * (decimal)item.Owner.Commission;
                storeProfit += item.Price * (1 - (decimal)item.Owner.Commission);

            }
            shoppingCartData.Clear();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorsBinding.ResetBindings(false);

            storeProfitValue.Text = string.Format("$" + storeProfit);
            MessageBox.Show("Items have been purchased!");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
