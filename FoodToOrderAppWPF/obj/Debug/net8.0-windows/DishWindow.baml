   M S B A M L   `   `   `  ����L  HFoodToOrderAppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FoodToOrderAppWPFFoodToOrderAppWPF  5   	   "    FoodToOrderAppWPF.DishWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FoodToOrderAppWPF     5   	     � Title$  
DishWindow��5   	   $	��450��6   $	��800��6)   
������� � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ Franklin Gothic)�6+   �� 5       � ��
 ��iA�6+   5      5      .��5      � $��Center=�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $	��250 �6    �� 5      $
��auto �6    �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5      �� 5      $
��auto �6#   .+�5      �� $��0��6    �� Padding$ 10q�6%   $��30(�62   $��Center=�6@   $
��Left=�6[   MENU6}   �� 5   
   -   5        $��lstdish��5      $��1��6   $��Center=�6.   $��Center=�6I   �� 5   
   -   5        $��5q�5         SubmitButtonStyle#��[  6   $��2��6G   $��Add To Cart��6l    5      ��%^   '��       �� 5       " ��6   .�5!      ��  �@��CornerRadius$ 6��65   5"      5#      5$      �� 5%   
   -   5        $��3��5%      $��5q�6   $
��Back��6)   #��[  6L    5&      ��%^   '��       �� 5'      " ��6   .�5(      ��  �@��CornerRadius$ 6��65   5)      5*      5+      5,      5-      