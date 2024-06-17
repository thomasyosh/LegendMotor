using LegendMotor.Domain.Models;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Dal.Repository;

namespace LegendMotor.WinForm;

public partial class LoginForm : Form
{
    private readonly IStaffRepository _staffRepository;
    private readonly IBinLocationRepository _binLocationRepository;
    public LoginForm()
    {
        InitializeComponent();
        _staffRepository = new StaffRepository();
        _binLocationRepository = new BinLocationRepository();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            btn_login.PerformClick();
        }
    }

    private void btn_login_Click(object sender, EventArgs e)
    {

        string username = txt_username.Text;
        string password = txt_password.Text;
        Staff loginUser = _staffRepository.GetUserByName(username);
        try
        {
            if (loginUser != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(password, loginUser.Password))
                {
                    MessageBox.Show("Username or password incorrect");
                    txt_password.Text = "";
                    if (loginUser.LoginFailedCounter < 5)
                    {
                        loginUser.LoginFailedCounter++;
                    }
                    if (loginUser.LoginFailedCounter == 5)
                    {
                        loginUser.IsActive = false;
                    }
                }

                if (!_staffRepository.GetUserByName(username).IsActive)
                {
                    MessageBox.Show("Account is locked");
                    txt_username.Text = txt_password.Text = "";
                }
                if (_staffRepository.GetUserByName(username).IsActive && BCrypt.Net.BCrypt.Verify(password, loginUser.Password))
                {
                    MessageBox.Show("Login Successful");
                    StaffManager.Instance.SetStaff(loginUser);
                    this.getBinLocationCode();
                    loginUser.LastLoginDateTime = DateTime.Now;
                    loginUser.LoginFailedCounter = 0;
                    txt_username.Text = txt_password.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No such account");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message);
        }
        finally
        {
            _staffRepository.UpdateUser(loginUser);
        }
    }

    private void getBinLocationCode()
    {
        BinLocationStaff binLocation = _binLocationRepository.
                                        GetBinLocationByStaffId(StaffManager.Instance.GetStaffId());
        try
        {
            if (binLocation != null)
            {

                StaffManager.Instance.SetBinLocationCode(binLocation.BinLocationCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            txt_password.Text = "";
            txt_username.Text = "";
            this.Hide();
            string positionCode = StaffManager.Instance.GetStaffPosition();
            if (positionCode.Equals("admin"))
            {
                AdminMenu adminMenu = new AdminMenu(this);
                adminMenu.Show();
            }
            else if (positionCode.Equals("sales"))
            {
                SalesOfficerMenu salesOfficerMenu = new SalesOfficerMenu(this);
                salesOfficerMenu.Show();
            }
            else if (positionCode.Equals("smanager"))
            {
                SalesManagerMenu salesManagerMenu = new SalesManagerMenu(this);
                salesManagerMenu.Show();
            }
            else if (positionCode.Equals("storemen"))
            {
                StoremenMenu storemenMenu = new StoremenMenu(this);
                storemenMenu.Show();
            }
            else if (positionCode.Equals("amanager"))
            {
                AreaManagerMenu areaManagerMenu = new AreaManagerMenu(this);
                areaManagerMenu.Show();
            }
            else if (positionCode.Equals("pd"))
            {
                PurchasingDepartmentMenu productDepartmentMenu = new PurchasingDepartmentMenu(this);
                productDepartmentMenu.Show();
            }/* else if (positionCode.Equals("src"))
            {
                UpdateStockForm updateStockForm = new UpdateStockForm(this);
                updateStockForm.Show();
            } else if (positionCode.Equals("dm"))
            {
                DeliveryMenMenu deliveryMenMenu = new DeliveryMenMenu(this);
                deliveryMenMenu.Show();
            }*/
        }
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {

    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en");
    }

    private void 繁體中文ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("zh-HK");
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("zh-HK");
    }

    private void 簡體中文ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("zh-Hans-HK");
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("zh-Hans-HK");
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
        txt_username.Text = txt_password.Text = "";
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        txt_password.UseSystemPasswordChar = !checkBox1.Checked;
    }
}
