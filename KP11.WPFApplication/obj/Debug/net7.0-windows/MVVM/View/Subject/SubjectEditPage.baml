   M S B A M L   `   `   `  ����N  JKP11.WPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:KP11.WPFApplication.MVVM.ModelKP11.WPFApplication.MVVM.Model  5   D   3    -KP11.WPFApplication.MVVM.View.SubjectEditPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >model,clr-namespace:KP11.WPFApplication.MVVM.Model     6D     N� Title$  SubjectEditPage��5      .��5
      � .+�5   
   �� 
���   � J� Opacity$
 0.75Q�6!    K� ZIndex$ 0��60   �� 5   
    �� Orientation$ Vertical=�6   $��Center=�5      $��Center=�5      .+�5      ��    
LabelTitle#��[  6   $3��-Редактирование предмета��5      
�������$��Center=�5      � 5      $��0,20,0,0q�6   $	��400��5      .+�5      �� 
�������$ 1Q�6,   �� 5      $ Vertical=�6   .+�5      �� $ Vertical=�6!   .+�5      �� $��Название��6      Manrope#��[ 5       $��15(�5       $��30��5       �� 5      -   5        $��TextBoxSubjectName��5   "   $��30��5"   "   $��0q�5#   "   
�������#��[ 5%   "   ��5    "   �� *Name+5%   "   5'      �� 5)      $ Vertical=�6!   .+�5+      �� -   5        $��LabelFieldEmptyWarning��5,       $?��9Все поля должны быть заполнены!��5+       #��[ 5-       $
��Bold"�5.       $��10(�5/       $��30��50       $��Center=�51       $��Bottom=�52       
���  ��$y�Hidden=�54       56      57      58      � 59       � ColumnDefinitions 5:      �� 5;      $��1* �6'   �� 5<      $��1* �6'   �� 5=      $��1* �6'   .+�5@      �� -   5        $��ButtonClose��5A      $��Закрыть��5@      $��30��5C      $��0q�5D      ���#777777
�������#��[ 5G      $��DemiBold"�5H      $��0��5I      �� 5K      -   5        $��ButtonDelete��5L      $��Удалить��5K      $��30��5N      $��0q�5O      
���  ��
�������#��[ 5R      $��DemiBold"�5S      $��1��5T      �� 5V      -   5        $��
ButtonSave��5W      $��Сохранить��5V      $��30��5Y      $��0q�5Z      
��� ���
���   �#��[ 5]      $��DemiBold"�5^      $��2��5_      5`      5a      5b      5c      