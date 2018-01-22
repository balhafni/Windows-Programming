using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_University_App_Enhanced.Models;
using Student_University_App_Enhanced.BusinessLayer;
namespace Student_University_App_Enhanced
{
    public partial class ViewGrades : Form
    {
        IBusinessStudent _ibusinessStudent = null;
        public ViewGrades()
        {
            InitializeComponent();
            _ibusinessStudent = new Business() as IBusinessStudent;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<CoursesTaken> cList = null;
            try
            {
                cList = _ibusinessStudent.GetGradeByStudentId(txtId.Text);
                if(cList.Count == 0)
                {
                    MessageBox.Show("Invalid Id");
                    return;
                }
                dataGrid.DataSource = cList;
                dataGrid.Refresh();


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
