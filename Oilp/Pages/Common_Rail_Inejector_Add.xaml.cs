using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OilP.Model;

namespace OilP.Pages
{
    /// <summary>
    /// Common_Rail_Inejector_Add.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Inejector_Add : Page
    {
        List<TEMPLATE_Model> DATA = new List<TEMPLATE_Model>();
        public Common_Rail_Inejector_Add()
        {
            InitializeComponent();
            InitTemplateBox();
        }

        /**
         * 初始化template_combobox数据
         **/
        public void InitTemplateBox()
        {
            List<string> itemString = new List<string>();
            itemString = Dao.TEMPLATE_DAO.QueryTEMPListByType("cri");
            foreach (string item in itemString)
            {
                ComboBoxItem tempItem = new ComboBoxItem();
                tempItem.Content = item;
                template_combobox.Items.Add(tempItem);
            }
        }

        /**
         * 根据选择的步骤加载数据
         * */
        private void step_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (step_ListBox.Items.Count<1)
            {
                return;
            }
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            TEMPLATE_Model tEMPLATE_Model = new TEMPLATE_Model();
            foreach (var item in DATA)
            {
                if (step_name.Equals(item.Step_name))
                {
                    tEMPLATE_Model = item;
                    break;
                }
            }
            /*在页面上填入数据*/
            FillData(tEMPLATE_Model);
        }

        /**
         * 页面填入数据
         * */
         public void FillData(TEMPLATE_Model tEMPLATE_Model)
        {

            last_time_TextBox.Text = tEMPLATE_Model.Pulse_width;
            pressure_TextBox.Text = tEMPLATE_Model.Rail_pressure.ToString();
            oil_p_hor_TextBox.Text = tEMPLATE_Model.Oil_p_standard;
            oil_p_ver_TextBox.Text = tEMPLATE_Model.Oil_p_deviation;
            oil_h_hor_TextBox.Text = tEMPLATE_Model.Oil_h_standard;
            oil_h_ver_TextBox.Text = tEMPLATE_Model.Oil_h_pressure;
            //脉宽和时间的区分？
            test_time_TextBox.Text = tEMPLATE_Model.Control_last_time;
            if (null == tEMPLATE_Model.Curve || tEMPLATE_Model.Curve.Length == 0)
            {
                curve_TextBox.Text = null;
            }
            else
            {
                curve_TextBox.Text = tEMPLATE_Model.Curve.ToString();
            }
            magn_TextBox.Text = tEMPLATE_Model.Manufacturer;
            period_TextBox.Text = "未设定";
            voltage_TextBox.Text = tEMPLATE_Model.Voltage;
            //读取数据后设置不可读

        }


        /**
      * 根据填入获取ListBox的填入项
      * */
        public void Init_step_ListBox(List<TEMPLATE_Model> tEMPLATE_Models)
        {
            step_ListBox.Items.Clear();
            ListBoxItem listBoxItem = new ListBoxItem();
            int i = 1;
            foreach (TEMPLATE_Model item in tEMPLATE_Models)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = item.Step_name;
                temp.FontSize = 40;
                temp.FontFamily = new FontFamily("Yu Gothic UI Semibold");              
                step_ListBox.Items.Add(temp);
                i++;
            }
            //默认选中第一项加载数据
            step_ListBox.SelectedIndex = 0;
        }

        /**
         * 根据选择的template加载对应的template数据
         * */
        private void template_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string temp_no = template_combobox.SelectedValue.ToString();
            temp_no = temp_no.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            if (temp_no.Length<1||"请选择".Equals(temp_no))
            {
                if (step_ListBox!=null)
                {
                    step_ListBox.Items.Clear();
                }
               
                return;
            }
            List<TEMPLATE_Model> tEMPLATE_Models = new List<TEMPLATE_Model>();
            tEMPLATE_Models = Dao.TEMPLATE_DAO.QueryByTypeAndTEMPNo("cri", temp_no);
            DATA = tEMPLATE_Models;
            /*初始化listBox*/
            Init_step_ListBox(tEMPLATE_Models);
        }

        /**
         * 保存新建的数据，创建一个新的txt文件
         * */
        private void save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
