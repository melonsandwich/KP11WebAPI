   M S B A M L   `   `   `  ����N  JKP11.WPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:KP11.WPFApplication.MVVM.ModelKP11.WPFApplication.MVVM.Model  5      2    ,KP11.WPFApplication.MVVM.View.ManualEditPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >model,clr-namespace:KP11.WPFApplication.MVVM.Model     5        N� Title$  ManualEditPage��5
      .��5      � .+�5   
   �� 
���   � J� Opacity$
 0.75Q�6!    K� ZIndex$ 0��60   �� 5   
    �� Orientation$ Vertical=�6   $��Center=�5      $��Center=�5      .+�5      ��    
LabelTitle#��[  6   $1��+Редактирование пособия��5      
�������$��Center=�5      � 5      $��0,20,0,0q�6   $	��400��5      .+�5      �� 
�������$ 1Q�6,   �� 5      $ Vertical=�6   .+�5      �� $ Vertical=�6!   .+�5      �� $��Название��6      Manrope#��[ 5       $��15(�5       $��30��5       �� 5!      -   5        $��TextBoxManualName��5!   "   $��30��5$   "   $��0q�5%   "   
�������#��[ 5'   "   ��5"   "   �� *Name+5'   "   5)      �� 5+      $ Vertical=�6!   .+�5-      �� $(��"Ссылка на материал��6    #��[ 5.       $��15(�5/       $��30��50       �� 52      -   5        $��TextBoxManualContentLink��52   "   $��30��55   "   $��0q�56   "   
�������#��[ 58   "   ��53   "   �� *ContentLink+58   "   �� 5:      -   5        $��LabelFieldEmptyWarning��5;       $?��9Все поля должны быть заполнены!��5:       #��[ 5<       $
��Bold"�5=       $��10(�5>       $��30��5?       $��Center=�5@       $��Bottom=�5A       
���  ��$y�Hidden=�5C       5E      5F      5G      � 5H       � ColumnDefinitions 5I      �� 5J      $��1* �6'   �� 5K      $��1* �6'   �� 5L      $��1* �6'   .+�5O      �� -   5        $��ButtonClose��5P      $��Закрыть��5O      $��30��5R      $��0q�5S      ���#777777
�������#��[ 5V      $��DemiBold"�5W      $��0��5X      �� 5Z      -   5        $��ButtonDelete��5[      $��Удалить��5Z      $��30��5]      $��0q�5^      
���  ��
�������#��[ 5a      $��DemiBold"�5b      $��1��5c      �� 5e      -   5        $��
ButtonSave��5f      $��Сохранить��5e      $��30��5h      $��0q�5i      
��� ���
���   �#��[ 5l      $��DemiBold"�5m      $��2��5n      5o      5p      5q      5r      