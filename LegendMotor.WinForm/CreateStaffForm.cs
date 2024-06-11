using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using BCrypt.Net;


namespace LegendMotor.WinForm;

public partial class CreateStaffForm : Form
{
    private readonly DataContext _ctx;
    private List<string> positionCodes = new List<string>();
    private List<string> binLocationCodes = new List<string>();
    private List<string> areaCodes = new List<string>();
    private string gender = "";
    public CreateStaffForm()
    {
        InitializeComponent();
        this._ctx = new DataContext();
    }

    private void CreateStaffForm_Load(object sender, EventArgs e)
    {
        var positions = _ctx.Position;
        foreach (var position in positions)
        {
            positionCodes.Add(position.PositionCode);
            comboBox1.Items.Add(position.Name);
        }
        var areas = _ctx.Area;

        foreach (var area in areas)
        {
            areaCodes.Add(area.AreaCode);
            comboBox2.Items.Add(area.Name);
        }


        var binLocations = _ctx.BinLocation;
        foreach (var binLocation in binLocations)
        {
            binLocationCodes.Add(binLocation.BinLocationCode);
            comboBox3.Items.Add(binLocation.Name);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text;
        string email = textBox4.Text;
        string address = textBox3.Text;
        string phone = textBox2.Text;
        string password = textBox5.Text;
        if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a position and area");
            return;
        }
        string positionCode = positionCodes[comboBox1.SelectedIndex];
        string areaCode = areaCodes[comboBox2.SelectedIndex];
        if (gender.Equals("") || name.Equals("") || email.Equals("") || address.Equals("") || phone.Equals("") || password.Equals(""))
        {
            MessageBox.Show("Please fill in all fields");
            return;
        }
        string binLocationCode = "";
        if (positionCode.Equals("storemen") || positionCode.Equals("src"))
        {
            if (comboBox3.SelectedIndex <= -1 || comboBox3.SelectedIndex >= binLocationCodes.Count)
            {
                MessageBox.Show("Please select a bin location");
                return;
            }
            binLocationCode = binLocationCodes[comboBox3.SelectedIndex];
        }
        string staffId = Guid.NewGuid().ToString();
        string hashedPassword = "abcd1234";
        Console.WriteLine(password);
        Staff staff = new Staff();
        staff.StaffId = staffId;
        staff.Name = name;
        staff.Password = BCrypt.Net.BCrypt.HashPassword(hashedPassword);
        staff.Gemder = gender;
        staff.Email = email;
        staff.Phone = phone;
        staff.Address = address;
        staff.AreaCode = areaCode;
        staff.PositionCode = positionCode;

        try
        {
            int failed = 0;
            {
                _ctx.Staff.Add(staff);
                try
                {
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    failed++;
                    Console.WriteLine("Error inserting data into Database!");
                }


                if (!binLocationCode.Equals(""))
                {
                    BinLocationStaff binLocationStaff = new BinLocationStaff();
                    binLocationStaff.BinLocationCode = binLocationCode;
                    binLocationStaff.StaffId = staffId;
                    _ctx.BinLocationStaff.Add(binLocationStaff);
                    try
                    {
                        _ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        Console.WriteLine("Error inserting data into Database!");
                    }

                }
                if (failed == 0)
                {
                    MessageBox.Show("Staff created successfully");
                    this.Close();
                }
                else
                {
                    Console.WriteLine(failed);
                    MessageBox.Show("Failed to create staff");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        textBox5.Text = "abcd1234";
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton1.Checked)
        {
            gender = "M";
            radioButton2.Checked = false;
        }
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton2.Checked)
        {
            gender = "F";
            radioButton1.Checked = false;
        }
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex <= -1 || comboBox1.SelectedIndex >= positionCodes.Count)
        {
            return;
        }
        if (positionCodes[comboBox1.SelectedIndex].Trim().Equals("storemen") || positionCodes[comboBox1.SelectedIndex].Trim().Equals("src"))
        {
            comboBox3.Visible = true;
            label7.Visible = true;
        }
        else
        {
            comboBox3.Visible = false;
            comboBox3.SelectedIndex = -1;
            label7.Visible = false;
        }
    }
}

