   M S B A M L   `   `   `  ����K  GProdajaVozilaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProdajaVozilaApp.View.GostProdajaVozilaApp.View.Gost  5   	   0    *ProdajaVozilaApp.View.Gost.CarDetailedInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:ProdajaVozilaApp.View.Gost     5   	     � Title$  CarDetailedInfo��5   	   $	��543��6!   $	��818��6.    � WindowStartupLocation$ CenterScreen=�6;   ��5	      �� 5
   
    �� ImageSource$" ../../Resources/pozadina.jpg��6    �� Opacity$	 0.4Q�6@   6P    � 	Resources 5       �� 
TargetType   NewGameButtonStyle �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius �� Padding �� Color �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��5      .�5      ��  � ��$  Resources/teen bd.ttf#Teen)�6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ Center=�6;   6L   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $	 ButtonBorder��5   %   $��2q�5   %   $
 10��5   %   $ 3q�5   %   
���������5   "   �� 5   &   ButtonBorderBrush��$ Black��6Q   ._�5   "   �� $��Center=�63   $	��4,2q�5    3   5!      5"       5#      P� 5$       �@J�IsMouseOver$
 True��6=   . �5%   "   �� $ ButtonBorder��6)    � �� �#C0C0C06Y   5&      5(      5*      5+      5,      .��5-      �� -   5        $	 Border��5-      $��50q�6   ��5.   
   �� 5/      $ ../../Resources\zid.jpg��6   6A   ._�51   
   � -   5         �Name$
 Grid��51       � ColumnDefinitions 52      �� 53      $��* �6#   6/   �� 54      $��* �6#   6/   �� 55      $��* �6#   6/   �� 56      $��* �6#   6/    � RowDefinitions 58      �� 59      $	��30* �6    6/   �� 5:      $	��80* �6    6/   �� 5;      $	��80* �6    6/   �� 5<      $	��80* �6    6/   �� 5=      $	��30* �6    6/   .+�5?      �� $��1��6   $��2��6(   $��19(�6<   
�������$*��$Detaljni prikaz informacija o vozilu��6b   
���   �$��Black"�6�    �� TextAlignment$ Center=�6�   $��Center=�6�   $��Center=�6�   �� 5@      -   5         ��Name$ 
BackButton��5@      #��[  6)   $��4��6U   $��0��6b   $��	40,5,40,8q�6r   .��5A      �� $��Povratak��6   $ Center=�6,   $��Black"�6C   $��15(�6V   5B      �� 5C      $��1��6   $��0��6"   $��2��62   $��3��6F   
�������
���   �$��12q�6�   $��10q�6�   $
 3��6�   ._�5D      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5D      5E      5F      �� 5G      $��1��6   $��2��6"   $��2��62   $��3��6F   
�������
���   �$��12q�6�   $��10q�6�   $
 3��6�   ._�5H      ��  �� Orientation$ Vertical=�6   $��	0,0,0,-26q�64   .+�5I      �� -   5         ��Name$ Slika��5I      $	��230��6+   �� 5J      -   5         ��Name$ ScrollViewer��5J   #   $��Visible=�69   $��Disabled=�6a   $��79��6�   .��5K      �� -   5         ��Name$ Slicice��5K   %   $ 
Horizontal=�66   $	��495��6O   $��53��6[   5L      5M      5N      5P      5Q      5R      