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

        }


        /**
      * 根据填入获取ListBox的填入项
      * */
        public void Init_step_ListBox(List<TEMPLATE_Model> tEMPLATE_Models)
        {
            step_ListBox.Items.Clear();
            foreach (TEMPLATE_Model item in tEMPLATE_Models)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = item.Step_name;
                temp.FontSize = 40;
                temp.FontFamily = new FontFamily("Yu Gothic UI Semibold");
                step_ListBox.Items.Add(temp);
            }
        }

        /**
         * 根据选择的template加载对应的template数据
         * */
        private void template_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string temp_no = template_combobox.Text;
            if (temp_no.Length<1||"请选择".Equals(temp_no))
            {
                return;
            }
            List<TEMPLATE_Model> tEMPLATE_Models = new List<TEMPLATE_Model>();
            tEMPLATE_Models = Dao.TEMPLATE_DAO.QueryByTypeAndTEMPNo("cri", temp_no);
            DATA = tEMPLATE_Models;
            /*初始化listBox*/
            Init_step_ListBox(tEMPLATE_Models);
        }
    }
}
