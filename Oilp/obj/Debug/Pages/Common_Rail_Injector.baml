   M S B A M L   `   `   `  ����?  ;OilP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:OilP.Pages
OilP.Pages  5      H DShowMeTheXAML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAMLShowMeTheXAML 5
   	   %    OilP.Pages.Common_Rail_Injector   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:OilP.Pages     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   =smtx2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML  5
   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$G A电控共轨系统测试软件(版本V1.0) - Common rail injector��5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Flipper.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Popupbox.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Shadows.xaml?�6%   �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   �� 5       $l fpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ToggleButton.xaml?�6%   %    5#      .��5&      � -   5        $��common_rail_injector_grid��5&        � ShowGridLines . 	 � RowDefinitions	 5'   
   �� 5(      $��* �6   6)   �� 5)      $��0.15* �6   6-   
 � ColumnDefinitions
 5+   
   �� 5,      $��0.65* �6   6/   �� 5-      $��* �6   6+   .+�50   
   � -   5        $��search_grid��50   $    . $��0��67   $��0��6D   	 51      �� 52      $
��0.2* �6    60   �� 53      $
��0.6* �6    60   �� 54      $��0.15* �6    61   
 56      .+�59      �  . $��0��6(   	 5:      �� 5;      6&   �� 5<      6&   .+�5>      �� -   5        $��model_no_name��5>   ?   $��60,15,15,15q�6   $��型号-零件号��61   $��YouYuan)�5?      $��40(�61   $
��Bold"�5@      5B      �� 5C      -   5        $��model_no��5C      $��1��6+   $��0��68   $�� ��5D      $��30,10,30,10q�6   $��50(�64   .��5E      5F      5H      �� 5I      -   5        $��search��5I   "   $��查找��6   $��2��60   $��0��6=   $��30,10,30,10q�6M    # MaterialDesignRaisedLightButton#���  5J      
����ح�$��50(�5K      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5M      � 5N       . $��1��6(   
 5O      �� 5P      6)   �� 5Q      6)   .+�5S      �� -   5        $��manufacturer_list��5S      $��0��63   $��0��6@   $��10,10,10,10q�6Q   {�5T      �� *	IsChecked+ �� ElementName$ EnableListBox��.@�5U      �� $��Bosch��6#   $��30(�63    �� 
IsSelected . 6A   �� 5V      $��Denso��6#   $��30(�63   �� 5W      $��Delphi��6#   $��30(�64   �� 5X      $��Siemens��6#   $��30(�65   �� 5Y      $��Caterpillar��6#   $��30(�69   �� 5Z      $	��BYC��6#   $��30(�61   �� 5[      $��Cummins��6#   $��30(�65   �� 5\      $��LongBeng��6#   $��30(�66   �� 5]      $��NanYue��6#   $��30(�64   �� 5^      $	��WIT��6#   $��30(�61   5_      � 5a       . $��1��6,   	 5b      �� 5c      $
��0.1* �6(   68   �� 5d      $
��0.9* �6(   68   .+�5f      �� -   5        $��history_TextBlock��5f       $��历史记录��69   $��YouYuan)�6E   $��40(�6Z   $��Center=�5g       $��Center=�6<   6[   &   System.Windows.Controls.DataGrid  5h      -	   5        $��history_datagrid��5h      $��1��67   $��0��6D   $��5,5,5,5q�5i         AutoGenerateColumns .     
IsReadOnly . ��6@   ��    Columns 5k      0  *System.Windows.Controls.DataGridTextColumn  5l      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      Header$ 型号��6;      FontSize$ 25Q�6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
Model_no+6u   5n      5o      5q      5s        5t   
   -
   5        $!��device_information_datagrid��5t      $��0��66   $��1��6C   $��50,50,50,50q�5u       .   . ��6D   ��  5w        5x      $ * 6%   $ 型号��6/   $ 20Q�6Y    6<   �� *
Model_no+6i     5y      $ * 6%   $ 	制造商��6/   $ 20Q�6]    6<   �� *Manufacturer+6m     5z      $ * 6%   $ 版本��6/   $ 20Q�6W    6;   �� *	Version+6g     5{      $ * 6%   $ 创建时间��6/   $ 20Q�6]    6=   �� *Create_time+6m   5}      �� 5      -   5        $��exit_system��5   $   $��退出系统��6   $��3��67   $��0��6D   $��30,20,30,20q�6T   #���  5�      
����ح�$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      � 5�   
    . $��2��6$   $��1��61   
 5�      �� 5�      6%   �� 5�      6%   �� 5�      6%   �� 5�      6%   .+�5�      �� -   5        $	��add��5�   "   $��新增��6   $��0��6-   $��0��6:   $��30,20,30,20q�6J   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      �� 5�      -   5        $
��edit��5�   "   $��修改��6   $��0��6.   $��1��6;   $��30,20,30,20q�6K   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      �� 5�      -   5        $	��set��5�   "   $��设置��6   $��0��6-   $��2��6:   $��30,20,30,20q�6J   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      �� 5�      -   5        $��confirm��5�   "   $��确认��6   $��0��61   $��3��6>   $��30,20,30,20q�6N   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      5�      5�      5�      