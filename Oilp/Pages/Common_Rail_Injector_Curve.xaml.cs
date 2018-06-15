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
    /// Common_Rail_Injector_Curve.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Injector_Curve : Page
    {
        public Common_Rail_Injector_Curve()
        {
            InitializeComponent();
        }

        public void SetData(CRI_Curve_Model cRI_Curve_Model)
        {
            TiSheng_TextBox.Text = cRI_Curve_Model.V_tisheng;
            XiDong_TextBox.Text = cRI_Curve_Model.V_xidong;
            BaoChi_TextBox.Text = cRI_Curve_Model.V_baochi;
            TiSheng_A_TextBox.Text = cRI_Curve_Model.A_tisheng;
            XiDong_A_TextBox.Text = cRI_Curve_Model.A_xidong;
            BaoChi_A_TextBox.Text = cRI_Curve_Model.A_baochi;
            XiDong_A_DEV_TextBox.Text = cRI_Curve_Model.A_xidong_dev;
            BaoChi_A_DEV_TextBox.Text = cRI_Curve_Model.A_baochi_dev;
            ChiXu_time_TextBox.Text = cRI_Curve_Model.Chixu_time;
            Min_ChiXu_time_TextBox.Text = cRI_Curve_Model.Min_chixu_time;
            if (ziran_item.Content.Equals(cRI_Curve_Model.After_xidong))
            {
                ziran_item.IsSelected = true;
            }
            else
            {
                fuya_item.IsSelected = true;
            }

            if (item_0.Content.Equals(cRI_Curve_Model.Fuya))
            {
                item_0.IsSelected = true;
            }
            else if (item_36.Content.Equals(cRI_Curve_Model.Fuya))
            {
                item_36.IsSelected = true;
            }
            else
            {
                item_60.IsSelected = true;
            }

            if (b_ziran_item.Content.Equals(cRI_Curve_Model.After_baochi))
            {
                b_ziran_item.IsSelected = true;
            }
            else if (b_fuya_item.Content.Equals(cRI_Curve_Model.After_baochi))
            {
                b_fuya_item.IsSelected = true;
            }
            else
            {
                b_chixufuya_item.IsSelected = true;
            }

            QieDuan_TextBox.Text = cRI_Curve_Model.Qieduan;

            if (ComboBoxItem_1.Content.Equals(cRI_Curve_Model.Curve))
            {
                ComboBoxItem_1.IsSelected = true;
            }
            else
            {
                ComboBoxItem_2.IsSelected = true;
            }
        }

       
        /**
         * 选择的曲线改变后重新获取值
         * */
        private void Curve_ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string curve_name = Curve_ComboBox.SelectedValue.ToString();
            curve_name = curve_name.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            if (curve_name.Length < 1 || "请选择".Equals(curve_name))
            {
                return;
            }
            /*读取curve数据*/
            CRI_Curve_Model cRI_Curve_Model = new CRI_Curve_Model();
            cRI_Curve_Model = GetCurveData(curve_name);
            SetData(cRI_Curve_Model);
        }

        public static CRI_Curve_Model GetCurveData(string curve_name)
        {
            CRI_Curve_Model cRI_Curve_Model = new CRI_Curve_Model();
            cRI_Curve_Model = Dao.CRI_Curve_DAO.QueryByCurveName(curve_name);
            return cRI_Curve_Model;
        }
    }
}
