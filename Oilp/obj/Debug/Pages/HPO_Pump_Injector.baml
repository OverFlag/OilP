   M S B A M L   `   `   `  ����  OilP"    OilP.Pages.HPO_Pump_Injector   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$G A电控共轨系统测试软件(版本V1.0) - Common rail injector��5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Flipper.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Popupbox.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Shadows.xaml?�6%   �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   �� 5      $l fpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ToggleButton.xaml?�6%   %    5      .��5!      � -   5        $��hpo_pump_injector_grid��5!        � ShowGridLines . 	 � RowDefinitions	 5"   
   �� 5#      $��* �6   6)   �� 5$      $��0.15* �6   6-   
 � ColumnDefinitions
 5&   
   �� 5'      $
��0.5* �6   6.   �� 5(      $��* �6   6+   .+�5+   
   � -   5        $��search_grid��5+   $    . $��0��67   $��0��6D   	 5,      �� 5-      $
��0.2* �6    60   �� 5.      $
��0.6* �6    60   �� 5/      $��0.15* �6    61   .+�51      �  . 	 52      �� 53      6&   �� 54      6&   .+�56      �� -   5        $��model_no_name��56   ?   $��60,15,15,15q�6   $��型号-零件号��61   $��YouYuan)�57      $��40(�61   $
��Bold"�58      5:      �� 5;      -   5        $��model_no��5;      $��1��6+   $��0��68   $�� ��5<      $��30,10,30,10q�6   $��50(�64   .��5=      5>      5?      �� 5@      -   5        $��search��5@   "   $��查询��6   $��2��60   $��0��6=   $��30,10,30,10q�6M    # MaterialDesignRaisedLightButton#���  5A      
����ح�$��50(�5B      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5D      � 5F       . $��1��6(   
 5G      �� 5H      6)   �� 5I      6)   .+�5K      �� -   5        $��manufacturer_list��5K      $��1��63   $��0��6@   $��10,10,10,10q�6Q   {�5L      �� *	IsChecked+ �� ElementName$ EnableListBox��.@�5M      �� $��Bosch��6"   $��30(�62    �� 
IsSelected . 6@   �� 5N      $��Denso��6"   $��30(�62   �� 5O      $��Delphi��6"   $��30(�63   �� 5P      $��Siemens��6"   $��30(�64   �� 5Q      $��Caterpillar��6"   $��30(�68   5R      � 5T       . $��1��6,   	 5U      �� 5V      $
��0.1* �6(   68   �� 5W      $
��0.9* �6(   68   .+�5Y      �� -   5        $��history_TextBlock��5Y       $��历史记录��69   $��YouYuan)�6E   $��40(�6Z   $��Center=�5Z       $��Center=�6<   6[   &   System.Windows.Controls.DataGrid  5[      -	   5        $��history_datagrid��5[      $��1��67   $��0��6D   $��5,5,5,5q�5\         AutoGenerateColumns .     
IsReadOnly . ��6@   ��    Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      Header$ 型号��6;      FontSize$ 25Q�6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
Model_no+6u   5a      5b      5d      5f        5g   
   -
   5        $!��device_information_datagrid��5g      $��0��66   $��1��6C   $��50,50,50,50q�5h       .   . ��6D   ��  5j        5k      $ * 6%   $ 型号��6/   $ 20Q�6Y    6<   �� *
Model_no+6i     5l      $ * 6%   $ 	制造商��6/   $ 20Q�6]    6<   �� *Manufacturer+6m     5m      $ * 6%   $ 说明��6/   $ 20Q�6[    6;   �� *Description+6k     5n      $ * 6%   $ 创建时间��6/   $ 20Q�6]    6=   �� *Create_time+6m   5p      �� 5r   
   -   5        $��exit_system��5r       $��退出系统��6   $��3��63   $��0��6@   $��30,20,30,20q�6P   #���  5s      
����ح�$��35(�5t      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5v      � 5w   
    . $��2��6$   $��1��61   
 5x      �� 5y      6%   �� 5z      6%   �� 5{      6%   �� 5|      6%   .+�5~      �� -   5        $	��add��5~   "   $��新增��6   $��0��6-   $��0��6:   $��30,20,30,20q�6J   #���  5      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      �� 5�      -   5        $
��edit��5�   "   $��修改��6   $��0��6.   $��1��6;   $��30,20,30,20q�6K   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      �� 5�      -   5        $��delete��5�   "   $��删除��6   $��0��60   $��2��6=   $��30,20,30,20q�6M   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      �� 5�      -   5        $��confirm��5�   "   $��确认��6   $��0��61   $��3��6>   $��30,20,30,20q�6N   #���  5�      
������$��35(�5�      $
��Auto��6#   $
��Bold"�61   $��YouYuan)�6C   5�      5�      5�      5�      