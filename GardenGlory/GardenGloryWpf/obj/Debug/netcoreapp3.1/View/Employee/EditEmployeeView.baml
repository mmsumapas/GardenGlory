   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:GardenGloryWpf.View.EmployeeGardenGloryWpf.View.Employee  5      3    -GardenGloryWpf.View.Employee.EditEmployeeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:GardenGloryWpf.View.Employee     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  EditEmployeeView��5      $	��440��5	      $	��450��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��0��5       $��0��5!      $��Right=�5"      $��Center=�5#      $��
First Name��5$      �� 5%   
   $��1��5&      $��0��5'      $��Right=�5(      $��Center=�5)      $��	Last Name��5*      �� 5+   
   $��2��5,      $��0��5-      $��Right=�5.      $��Center=�5/      $��Cellphone Number��50      �� 51   
   $��3��52      $��0��53      $��Right=�54      $��Center=�55      $��Employee Type��56      �� 57   
   $��4��58      $��0��59      $��Right=�5:      $��Center=�5;      $��Employee Status��5<      �� 5=   
   $��5��5>      $��0��5?      $��Right=�5@      $��Center=�5A      $��Experience Level��5B      �� 5C   
   $��6��5D      $��0��5E      $��Right=�5F      $��Center=�5G      $��
Supervisor��5H      �� 5J   
   -   5        $��txtFirstName��5K      $��0��5L      $��2��5M      $	��200��5N      $��40��5O      $
��Left=�5P      $��20(�5Q      ��5R      ��  �� Path$ 	FirstName��� 5S   
   -   5        $��txtLastName��5T      $��1��5U      $��2��5V      $	��200��5W      $��40��5X      $
��Left=�5Y      $��20(�5Z      ��5[      �� $ LastName��� 5\   
   -   5        $��txtCellphone��5]      $��2��5^      $��2��5_      $	��200��5`      $��40��5a      $
��Left=�5b      $��20(�5c      ��5d      �� $ 	CellPhone��� 5e   
   -   5        $��CmbEmployeeType��5f      $��3��5g      $��2��5h      $	��200��5i      $
��Left=�5j       �� DisplayMemberPath$ EmployeeTypeName��5k      $��20(�5l       �� 
IsEditable$
 True��5m       �� IsTextSearchEnabled$ False��5n      ��5o      �� $8 2AssociatedEmployeeDetailCmbViewModel.EmployeeTypes� �� SelectedItem 5r      �� $? 9AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType�	 �� Text	 5s      �� *=;AssociatedEmployeeDetailCmbViewModel.SearchEmployeeTypeText+
 �� UpdateSourceTrigger$
 Explicit=� �� Delay$
 0100���� 5t   
   -   5        $��CmbEmployeeStatus��5u      $��4��5v      $��2��5w      $	��200��5x      $
��Left=�5y      $ EmployeeStatusName��5z      $��20(�5{      $
 True��5|      $ False��5}      ��5~      �� $; 5AssociatedEmployeeDetailCmbViewModel.EmployeeStatuses� 5�      �� $A ;AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus�	 5�      �� *?=AssociatedEmployeeDetailCmbViewModel.SearchEmployeeStatusText+$
 Explicit=�$
 0100���� 5�   
   -   5        $��CmbExperienceLevel��5�      $��5��5�      $��2��5�      $	��200��5�      $
��Left=�5�      $ ExperienceLevelName��5�      $��20(�5�      $
 True��5�      $ False��5�      ��5�      �� $; 5AssociatedEmployeeDetailCmbViewModel.ExperienceLevels� 5�      �� $B <AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel�	 5�      �� *@>AssociatedEmployeeDetailCmbViewModel.SearchExperienceLevelText+$
 Explicit=�$
 0100���� 5�   
   -   5        $��CmbSupervisor��5�      $��6��5�      $��2��5�      $	��200��5�      $
��Left=�5�      $ EmployeeFullName��5�      $��20(�5�      $
 True��5�      $ False��5�      ��5�      �� $4 .AssociatedEmployeeDetailCmbViewModel.Employees� 5�      �� $; 5AssociatedEmployeeDetailCmbViewModel.SelectedEmployee�	 5�      �� *97AssociatedEmployeeDetailCmbViewModel.SearchEmployeeText+$
 Explicit=�$
 0100��� 5�   
   $��7��6   $��2��6    5�      �� 5�      $	��100 �6#   �� 5�      $��80 �6#   �� 5�      $��5 �6#   �� 5�      $��80 �6#   .+�5�      �� -   5        $��EditEmployeeSave��5�      $��1��5�      
����� �
������ $
��Save��5�      �� 5�      -	   5        $��EditEmployeeCancel��5�      $��3��5�      
����� �
������ $��Cancel��5�      5�      5�      5�      