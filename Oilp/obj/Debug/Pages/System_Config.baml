   M S B A M L   `   `   `  ����?  ;OilP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:OilP.Pages
OilP.Pages  5      H DShowMeTheXAML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAMLShowMeTheXAML 5	   	       OilP.Pages.System_Config   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:OilP.Pages     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   =smtx2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$G A电控共轨系统测试软件(版本V1.0) - Common rail injector��5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   %    5      .��5      �  � ShowGridLines . 	 � RowDefinitions	 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5       6   
 � ColumnDefinitions
 5"   
   �� 5#      6!   �� 5$      6!   �� 5%      6!   �� 5&      6!   .+�5(   
   �� -   5        $��language��5(   >   $��0��6   $��0��6!   $��系统语言��61   $��Center=�5)      $��Center=�61   $��YouYuan)�5*      $��20(�6)   69     ShowMeTheXAML.XamlDisplay  5+   
   
   Key$ language_field��6   $��0��60   $��1��6=   .��5,      �� -   5        $��language_combobox��5,   ?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6    �� 
IsEditable .    HintOpacity$	 .26Q�5-   %   .@�5.      �� -   5        $��zh_CN��5.   .   $��简体中文��6   6=   �� 5/      -   5        $��en_US��5/   ,   $��英文��6   6;   51      52      �� 53   
   -   5        $��confirm��53      $��确认��6    $��YouYuan)�6-   $
��Bold"�6B   
����ح�$��3��54   (   $��2��65   $��10,10,10,10q�6E   56      �� 58   
   -   5        $��cancel��58      $��取消��6   $��YouYuan)�6,   $
��Bold"�6A   
����ح�$��3��59   (   $��3��65   $��10,10,10,10q�6F   5;      5=      5>      