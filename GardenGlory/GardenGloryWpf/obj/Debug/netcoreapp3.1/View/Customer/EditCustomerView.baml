   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:GardenGloryWpf.View.CustomerGardenGloryWpf.View.Customer  5      3    -GardenGloryWpf.View.Customer.CustomerEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:GardenGloryWpf.View.Customer     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  CustomerEditView��5      $	��500��5	      $	��230��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��0��5      $��Right=�5      $
��Name��5       �� 5!   
   $��2��5"      $��0��5#      $��Right=�5$      $��Email��5%      �� 5&   
   $��3��5'      $��0��5(      $��Right=�5)      $��Contact Number��5*      �� 5+   
   $��4��5,      $��0��5-      $��Right=�5.      $��
Owner Type��5/      �� 51   
   -   5        $��txtCustomerName��52      $��1��53      $��2��54      $	��250��55      $��28��56      $
��Left=�57      ��58      ��  �� Path$
 Name��� 59   
   -   5        $��txtCustomerEmail��5:      $��2��5;      $��2��5<      $	��250��5=      $��28��5>      $
��Left=�5?      ��5@      �� $ Email��� 5A   
   -   5        $��txtContactNumber��5B      $��3��5C      $��2��5D      $	��250��5E      $��25��5F      $
��Left=�5G      ��5H      �� $ ContactNumber��� 5I   
   -   5        $��CmbOwnerType��5J      $��4��5K      $��2��5L      $	��250��5M      $
��Left=�5N       �� DisplayMemberPath$ OwnerTypeName��5O      $��12(�5P       �� 
IsEditable$
 True��5Q       �� IsTextSearchEnabled$ False��5R      ��5S      �� $0 *AssociatedOwnerTypeCmbViewModel.OwnerTypes� �� SelectedItem 5V      �� $7 1AssociatedOwnerTypeCmbViewModel.SelectedOwnerType�	 �� Text	 5W      �� *53AssociatedOwnerTypeCmbViewModel.SearchOwnerTypeText+
 �� UpdateSourceTrigger$
 Explicit=� �� Delay$
 0100��� 5X   
   $��6��6   $��2��6    5Y      �� 5Z      $	��170 �6#   �� 5[      $��90 �6#   �� 5\      $��90 �6#   .+�5^      �� -   5        $��CSave��5_      $��1��5`      $��68��5a      $��25��5b      
����� �
������ $
��Save��5f      $��12(�5g      �� 5h      -   5        $��CCancel��5i      $��2��5j      $��68��5k      $��25��5l      $
��Left=�5m      
����� �
������ $��Cancel��5q      $��12(�5r      5s      5t      5u      