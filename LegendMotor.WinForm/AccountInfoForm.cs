using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using LegendMotor.Dal;
using LegendMotor.Dal.Repository;


namespace LegendMotor.WinForm
{
    public partial class AccountInfoForm : Form
    {
        private Staff staff;
        private IStaffRepository _staffRepository;
        public AccountInfoForm()
        {
            InitializeComponent();
            _staffRepository = new StaffRepository();
        }

        private void AccountInfoForm_Load(object sender, EventArgs e)
        {
            staff = _staffRepository.GetStaffById(StaffManager.Instance.GetStaffId());
            emailTextBox.Text = staff.Email;
            createdAtDateTimePicker.Value = staff.CreateAt;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void createdAtDateTimePickerDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
