using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Dal.Repository;

namespace LegendMotor.WinForm
{
    public partial class AddSupplierForm : Form
    {
        private string supplierCode;
        private readonly ISupplierRepository _supplierRepository;
        public AddSupplierForm(string supplierCode)
        {
            InitializeComponent();
            this.supplierCode = supplierCode;
            this._supplierRepository = new SupplierRepository();
            if (supplierCode != null)
            {
                this.Text = "Edit Supplier";
                this.button1.Text = "Save";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string address = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;
            if (name == "" || address == "" || phone == "" || email == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            try
            {
                if (supplierCode != null)
                {
                        string query = "UPDATE Supplier SET Name = '" + name + "', Address = '" + address + "', Phone = '" + phone + "', Email = '" + email + "' WHERE SupplierCode = '" + supplierCode + "'";
                        Supplier supplier = _supplierRepository.GetSupplierBySupplierCode(supplierCode);
                        supplier.Name = name;
                        supplier.Address = address;
                        supplier.Phone = phone;
                        supplier.Email = email;
                    try
                    {
                        _supplierRepository.UpdateSupplier(supplier);
                    }
                       
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error updating data into Database!");
                        }

                }
                else
                {
                        int count = _supplierRepository.GetAllSupplier().Count();
                        count++;
                        string supplierCode = "S" + count.ToString("000000000");
                        Supplier supplier = new Supplier();
                        supplier.SupplierCode = supplierCode;
                        supplier.Name = name;
                        supplier.Address = address;
                        supplier.Phone = phone;
                        supplier.Email= email;
                    try
                    {
                        _supplierRepository.CreateSupplier(supplier);
                    }catch(Exception ex)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                }
                this.Close();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {
            if (supplierCode != null)
            {

                    
                    Supplier supplier = _supplierRepository.GetSupplierBySupplierCode(supplierCode);
                    if (supplier!=null)
                    {
                        textBox1.Text = supplier.Name;
                        textBox2.Text =supplier.Address;
                        textBox3.Text = supplier.Phone;
                        textBox4.Text = supplier.Email;
                    }
            }
        }
    }
}
