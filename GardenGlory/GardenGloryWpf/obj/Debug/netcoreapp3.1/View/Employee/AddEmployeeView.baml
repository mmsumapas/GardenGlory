   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:GardenGloryWpf.View.EmployeeGardenGloryWpf.View.Employee  5      2    ,GardenGloryWpf.View.Employee.AddEmployeeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:GardenGloryWpf.View.Employee     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  AddEmployeeView��5      $	��410��5	      $	��430��5
       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5    
   �� $��0��5!      $��0��5"      $��Right=�5#      $��Center=�5$      $��
First Name��5%      �� 5&   
   $��1��5'      $��0��5(      $��Right=�5)      $��Center=�5*      $��	Last Name��5+      �� 5,   
   $��2��5-      $��0��5.      $��Right=�5/      $��Center=�50      $��Cellphone Number��51      �� 52   
   $��3��53      $��0��54      $��Right=�55      $��Center=�56      $��Employee Type��57      �� 58   
   $��4��59      $��0��5:      $��Right=�5;      $��Center=�5<      $��Employee Status��5=      �� 5>   
   $��5��5?      $��0��5@      $��Right=�5A      $��Center=�5B      $��Experience Level��5C      �� 5D   
   $��6��5E      $��0��5F      $��Right=�5G      $��Center=�5H      $��
Supervisor��5I      �� 5K   
   -   5        $��txtFirstName��5L      $��0��5M      $��2��5N      $	��200��5O      $��40��5P      $
��Left=�5Q      $��20(�5R      ��5S      ��  �� Path$+ %AssociatedEmployeeViewModel.FirstName��� 5T   
   -   5        $��txtLastName��5U      $��1��5V      $��2��5W      $	��200��5X      $��40��5Y      $
��Left=�5Z      $��20(�5[      ��5\      �� $* $AssociatedEmployeeViewModel.LastName��� 5]   
   -   5        $��txtCellphone��5^      $��2��5_      $��2��5`      $	��200��5a      $��40��5b      $
��Left=�5c      $��20(�5d      ��5e      �� $+ %AssociatedEmployeeViewModel.CellPhone��� 5f   
   -   5        $��CmbEmployeeType��5g      $��3��5h      $��2��5i      $	��200��5j      $
��Left=�5k       �� DisplayMemberPath$ EmployeeTypeName��5l      $��20(�5m       �� 
IsEditable$
 True��5n       �� IsTextSearchEnabled$ False��5o      ��5p      �� $8 2AssociatedEmployeeDetailCmbViewModel.EmployeeTypes�	 �� SelectedItem	 5s      �� $? 9AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType�
 �� Text
 5t      �� *=;AssociatedEmployeeDetailCmbViewModel.SearchEmployeeTypeText+ �� UpdateSourceTrigger$ Explicit=� �� Delay$
 0100���� 5u   
   -   5        $��CmbEmployeeStatus��5v      $��4��5w      $��2��5x      $	��200��5y      $
��Left=�5z      $ EmployeeStatusName��5{      $��20(�5|      $
 True��5}      $ False��5~      ��5      �� $; 5AssociatedEmployeeDetailCmbViewModel.EmployeeStatuses�	 5�      �� $A ;AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus�
 5�      �� *?=AssociatedEmployeeDetailCmbViewModel.SearchEmployeeStatusText+$ Explicit=�$
 0100���� 5�   
   -   5        $��CmbExperienceLevel��5�      $��5��5�      $��2��5�      $	��200��5�      $
��Left=�5�      $ ExperienceLevelName��5�      $��20(�5�      $
 True��5�      $ False��5�      ��5�      �� $; 5AssociatedEmployeeDetailCmbViewModel.ExperienceLevels�	 5�      �� $B <AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel�
 5�      �� *@>AssociatedEmployeeDetailCmbViewModel.SearchExperienceLevelText+$ Explicit=�$
 0100���� 5�   
   -   5        $��CmbSupervisor��5�      $��6��5�      $��2��5�      $	��200��5�      $
��Left=�5�      $ EmployeeFullName��5�      $��20(�5�      $
 True��5�      $ False��5�      ��5�      �� $4 .AssociatedEmployeeDetailCmbViewModel.Employees�	 5�      �� $; 5AssociatedEmployeeDetailCmbViewModel.SelectedEmployee�
 5�      �� *97AssociatedEmployeeDetailCmbViewModel.SearchEmployeeText+$ Explicit=�$
 0100��� 5�   
   $��7��6   $��2��6    5�      �� 5�      $	��100 �6#   �� 5�      $��80 �6#   �� 5�      $��5 �6#   �� 5�      $��80 �6#   .+�5�      �� -   5        $��AddEmployeeSave��5�      $��1��5�      
����� �
������ $
��Save��5�      �� 5�      -	   5        $��AddEmployeeCancel��5�      $��3��5�      
����� �
������ $��Cancel��5�      5�      5�      5�      