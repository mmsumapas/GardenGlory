   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:GardenGloryWpf.View.AccountGardenGloryWpf.View.Account  5      0    *GardenGloryWpf.View.Account.AddAccountView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:GardenGloryWpf.View.Account     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  AddAccountView��5      $	��400��5	      $	��220��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��0��5      $��Right=�5      $��Center=�5      $��Employee��5      �� 5   
   $��2��5       $��0��5!      $��Right=�5"      $��Center=�5#      $
��Role��5$      �� 5&   
   -   5        $��CmbEmployee��5'      $��1��5(      $��2��5)      $	��250��5*      $
��Left=�5+       �� DisplayMemberPath$ EmployeeFullName��5,      $��18(�5-       �� 
IsEditable$
 True��5.       �� IsTextSearchEnabled$ False��5/      ��50      ��  �� Path$4 .AssociatedEmployeeDetailCmbViewModel.Employees� �� SelectedItem 53      �� $; 5AssociatedEmployeeDetailCmbViewModel.SelectedEmployee�	 �� Text	 54      �� *97AssociatedEmployeeDetailCmbViewModel.SearchEmployeeText+
 �� UpdateSourceTrigger$
 Explicit=� �� Delay$
 0100���� 55   
   -   5        $��CmbRole��56      $��2��57      $��2��58      $	��250��59      $
��Left=�5:      $ RoleTypeName��5;      $��18(�5<      $
 True��5=      $ False��5>      ��5?      �� $&  AssociatedRoleCmbViewModel.Roles� 5B      �� $- 'AssociatedRoleCmbViewModel.SelectedRole�	 5C      �� **(AssociatedRoleCmbViewModel.SeachRoleText+$
 Explicit=�$
 0100��� 5D   
   $��3��6   $��2��6    5E      �� 5F      $��80 �6#   �� 5G      $��70 �6#   �� 5H      $��5 �6#   �� 5I      $��70 �6#   .+�5K      �� -   5        $��AddAccountSave��5L      $��1��5M      
����� �
������ $
��Save��5Q      �� 5R      -   5        $��AddAccountCancel��5S      $��3��5T      $��74��5U      
����� �
������ $��Cancel��5Y      5Z      5[      5]      