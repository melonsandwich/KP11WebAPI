   M S B A M L   `   `   `  ����N  JKP11.WPFApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:KP11.WPFApplication.MVVM.ViewKP11.WPFApplication.MVVM.View  5      O,clr-namespace:KP11.WPFApplication.MVVM.ModelKP11.WPFApplication.MVVM.Model  6A   4    .KP11.WPFApplication.MVVM.View.SubjectSelection   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:KP11.WPFApplication.MVVM.View     5      >model,clr-namespace:KP11.WPFApplication.MVVM.Model     6A     N� Title$  SubjectSelection��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   �� $!��../../../Media/Image/bg.png��6   $��2��5      $��UniformToFill=�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 15Q�6   5      �� 5   
   
���   �$��1��6!    J� Opacity$	 0.3Q�62   �� 5   
   $��0��6   $��Center=�5      $��Center=�5      .+�5      �� -   5        $��LabelProfessorName��5      $<��6Жмышенко Валерий Альбертович��5         LabelTitleWhite#��[  5       �� 5"      $��Предметы��6   $��Center=�5#      $��DemiBold"�5$      $��25(�5%      #��[  5&      5'       � 5)   
   -   5        $��FrameSubject��5)      $��2��5*        � NavigationUIVisibility$ Hidden=�5+       K� ZIndex$ 50��5,      �� 5.   
   -   5        $��ButtonAddSubject��5.      $��Добавить��50      $	��Top=�51      $��Right=�52      $	��120��53      $��15q�54      $��5q�55      
 � Tag$ admin��56      �� 58   
   -   5        $��
ButtonBack��58      $��
Назад��59      $	��Top=�5;      $
��Left=�5<      $	��120��5=      $��15q�5>      $��5q�5?      � 5A   
   $��1��6   $��35q�5B      .+�5C      �� 
���   �$	 0.3Q�6%   �� 5D      -   5        $��LabelNoSubjects��5E        
LabelTitle#��[ 5D      $��Нет предметов��5F      $��Center=�5G      $��Center=�5H      
�������$y�	Collapsed=�5J      �� 5K      $��Disabled=�6   $
��Auto=�5L      .��5M      ��  �� Orientation$ Vertical=�6   .+�5N      �� ��6#   �� *
Subjects+��5O      �� 5P      .R�5Q   "   � 	 � ColumnDefinitions	 5R   &   �� 5S   *   $	��10* �6;   �� 5T   *   $��1* �6;   .+�5V   &   �� $��ButtonSubject��6-   -   5        $��5q�5Y   -   $��Stretch=�5Z   -   $��Stretch=�5[   -   $��0��5\   -   .��5]   *   � .+�5^   .   �� $��10(�68   $	��Top=�5_   8   $��Right=�5`   8   �� 5a   2   $
�ID: ��66    �� 5b   2   �66   �� *ID+5c   /   ]� 5d   .   .+�5e   2   �� $ Vertical=�6=   $
��Left=�5f   =   $
��Left=�5g   =   .+�5h   6   �� #��[ 6<   $��20(�5j   <   ��5i   <   �� *Name+5j   <   �� 5k   6   $ 
Horizontal=�6A   .+�5l   :   �� #��[ 6@   $��DemiBold"�5m   @   $)��#Количество пособий��5n   @   $��15(�5o   @   �� 5p   :   #��[ 6@   $��15(�5r   @   $��Regular"�5s   @   ��5q   @   �� *ManualAmount+5s   @   5t   7   5u   3   5v   /   5w   +   5x   '   �� 5y   &   $��1��61   $��Center=�5z   1   $��Center=�5{   1   .+�5|   *   �� $��
ButtonEdit��61   -   5        $��Center=�5   1   $��Center=�5�   1   $��5q�5�   1   .��5�   .   �� $%��../../../../Media/Icon/edit.png��64   $��50��5�   4   $��50��5�   4   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      