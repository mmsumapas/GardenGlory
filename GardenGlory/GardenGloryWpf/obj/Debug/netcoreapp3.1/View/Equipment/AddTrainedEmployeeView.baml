   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:GardenGloryWpf.View.EquipmentGardenGloryWpf.View.Equipment  5      :    4GardenGloryWpf.View.Equipment.AddTrainedEmployeeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:GardenGloryWpf.View.Equipment     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  AddTrainedEmployeeView��5      $	��500��5	      $	��200��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��0��5      $��Right=�5      $��Center=�5      $��Employee��5      $��15(�5       �� 5!   
   -   5        $��CmbEmployee��5"      $��1��5#      $��2��5$      $	��250��5%      $
��Left=�5&       �� DisplayMemberPath$ EmployeeFullName��5'      $��18(�5(       �� 
IsEditable$
 True��5)       �� IsTextSearchEnabled$ False��5*      ��5+      ��  �� Path$4 .AssociatedEmployeeDetailCmbViewModel.Employees� �� SelectedItem 5.      �� $; 5AssociatedEmployeeDetailCmbViewModel.SelectedEmployee�	 �� Text	 5/      �� *97AssociatedEmployeeDetailCmbViewModel.SearchEmployeeText+
 �� UpdateSourceTrigger$
 Explicit=� �� Delay$
 0100��� 52   
   $��4��6   $��2��6    53      �� 54      $	��170 �6#   �� 55      $��90 �6#   �� 56      $��90 �6#   .+�58      �� -   5        $��AddTrainedEmployeeSave��59      $��1��5:      $��68��5;      $��25��5<      
����� �
������ $
��Save��5@      $��12(�5A      �� 5B      -   5        $��AddTrainedEmployeeCancel��5C      $��2��5D      $��68��5E      $��25��5F      $
��Left=�5G      
����� �
������ $��Cancel��5K      $��12(�5L      5M      5N      5O      