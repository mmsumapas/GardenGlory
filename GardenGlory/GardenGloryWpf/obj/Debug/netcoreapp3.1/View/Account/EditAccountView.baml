   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:GardenGloryWpf.View.AccountGardenGloryWpf.View.Account  5      1    +GardenGloryWpf.View.Account.EditAccountView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:GardenGloryWpf.View.Account     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  EditAccountView��5      $	��400��5	      $	��180��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��0��5      $��Right=�5      $��Center=�5      $
��Role��5      �� 5    
   -   5        $��CmbRole��5!      $��1��5"      $��2��5#      $	��210��5$      $
��Left=�5%       �� DisplayMemberPath$ RoleTypeName��5&      $��18(�5'       �� 
IsEditable$
 True��5(       �� IsTextSearchEnabled$ False��5)      ��5*      ��  �� Path$&  AssociatedRoleCmbViewModel.Roles� �� SelectedItem 5-      �� $- 'AssociatedRoleCmbViewModel.SelectedRole�	 �� Text	 5.      �� **(AssociatedRoleCmbViewModel.SeachRoleText+
 �� UpdateSourceTrigger$
 Explicit=� �� Delay$
 0100��� 50   
   $��2��6   $��2��6    51      �� 52      $��80 �6#   �� 53      $��75 �6#   �� 54      $��5 �6#   �� 55      $��75 �6#   .+�57      �� -   5        $��EditAccountSave��58      $��1��59      
����� �
������ $
��Save��5=      �� 5>      -   5        $��EditAccountCancel��5?      $��3��5@      
����� �
������ $��Cancel��5D      5E      5F      5H      