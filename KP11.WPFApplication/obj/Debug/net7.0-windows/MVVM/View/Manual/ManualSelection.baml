   M S B A M L   `   `   `  ����N  JKP11.WPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:KP11.WPFApplication.MVVM.ViewKP11.WPFApplication.MVVM.View  5      3    -KP11.WPFApplication.MVVM.View.ManualSelection   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:KP11.WPFApplication.MVVM.View     5        N� Title$  ManualSelection��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   �� $!��../../../Media/Image/bg.png��6   $��2��5      $��UniformToFill=�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 15Q�6   5      �� 5   
   
���   �$��1��6!    J� Opacity$	 0.3Q�62    � 5   
   -   5        $��FrameSingleManual��5      $��2��5        � NavigationUIVisibility$ Hidden=�5       K� ZIndex$ 50��5      �� 5    
   -   5        $��
ButtonBack��5       $��
Назад��5!      $	��Top=�5#      $
��Left=�5$      $	��120��5%      $��15q�5&      $��5q�5'      �� 5)   
   -   5        $��	ButtonAdd��5)      $��Добавить��5*      $	��Top=�5,      $��Right=�5-      $	��120��5.      $��15q�5/      $��5q�50      �� 52   
   $��0��6   $��Center=�53      $��Center=�54      .+�55      �� -   5        $��LabelProfessor��55      $<��6Жмышенко Валерий Альбертович��56         LabelTitleWhite#��[  57      $��Center=�58      �� 5:      -   5        $��LabelSubject��5:      $(��"Разговоры о важном��5;      $��Center=�5<      $��DemiBold"�5=      $��25(�5>      #��[  5?      �� 5A      $��Пособия��6   $��Center=�5B      $��Regular"�5C      $��20(�5D      #��[  5E      5F      � 5H   
   $��1��6   $��35q�5I      .+�5J      �� 
���   �$	 0.3Q�6%   �� 5K      -   5        $��LabelNoManuals��5L        
LabelTitle#��[ 5K      $��Нет пособий��5M      $��Center=�5N      $��Center=�5O      
�������$	 0.4Q�5Q      �� 5R      $��Disabled=�6   $
��Auto=�5S      .��5T      �� ��6   �� *	Manuals+��5U      �� 5V      .R�5W      �  � ColumnDefinitions 5X   "   �� 5Y   &   $	��15* �67   �� 5Z   &   $��1* �67   .+�5]   "   �� $��ButtonManual��6)   -   5        $��5q�5`   )   $��Stretch=�5a   )   .��5b   &   � .+�5c   *   ]� .+�5d   .   ��  �� Orientation$ Vertical=�69   $
��Left=�5e   9   $
��Left=�5f   9   .+�5g   2   �� #��[ 68   $��20(�5i   8   ��5h   8   �� *Name+5i   8   �� 5j   2   $ 
Horizontal=�6=   ${�False��5k   =   $y�	Collapsed=�5l   =   .+�5m   6   �� #��[ 6<   $��DemiBold"�5n   <   $��Дата создания��5o   <   $��15(�5p   <   �� 5q   6   #��[ 6<   $��15(�5s   <   $��Regular"�5t   <   ��5r   <   �� *DateCreated+	 �� StringFormat$	 {0:d MMMM yyyy H:mm}��
 �� ConverterCulture$
 ru-RU��5t   <   5u   3   5v   /   5w   +   5x   '   5y   #   �� 5z   "   $��1��6-   $��Center=�5{   -   $��Center=�5|   -   .+�5}   &   �� $��
ButtonEdit��6-   -   5        $��Center=�5�   -   $��Center=�5�   -   $��5q�5�   -   .��5�   *   �� $"��../../../Media/Icon/edit.png��60   $��25��5�   0   $��25��5�   0   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      