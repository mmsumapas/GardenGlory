   M S B A M L   `   `   `  ����U  QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem  5      I EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:GardenGloryWpf.View.EquipmentGardenGloryWpf.View.Equipment 5      :   4GardenGloryWpf.View.Equipment.AddEquipmentRepairView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ?System,clr-namespace:System;assembly=System.Runtime     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:GardenGloryWpf.View.Equipment     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��500��5	      $	��270��5
        � WindowStartupLocation$  CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��0��5      $��Right=�5      $��Center=�5      $��Date of Repair��5       �� 5!   
   $��2��5"      $��0��5#      $��Right=�5$      $��Center=�5%      $��Amount (₱) ��5&      �� 5'   
   $��3��5(      $��0��5)      $��Right=�5*      $��Center=�5+      $��Remarks��5,      (  "System.Windows.Controls.DatePicker  5-   
   -   5        $��txtDateOfRepair��5.      $��1��5/      $��2��50      $	��250��51      $��28��52      $
��Left=�53      
 �� Now   DisplayDate# Z 54      $��15(�55         SelectedDate 56      ��  �� Path$ DateOfRepair��� 58   
   -   5        $��	txtAmount��59      $��2��5:      $��2��5;      $	��250��5<      $��28��5=      $
��Left=�5>      $��15(�5?      ��5@      �� $ Amount��� 5A   
   -   5        $��
txtRemarks��5B      $��3��5C      $��2��5D      $	��250��5E      $��28��5F      $
��Left=�5G      $��15(�5H      ��5I      �� $ Remarks�� 5L   
   $��4��6   $��2��6    5M      �� 5N      $	��170 �6#   �� 5O      $��90 �6#   �� 5P      $��90 �6#   .+�5R      �� -   5        $��AddEquipmentRepairSave��5S      $��1��5T      $��68��5U      $��25��5V      
����� �
������ $
��Save��5Z      $��12(�5[      �� 5\      -   5        $��AddEquipmentRepairCancel��5]      $��2��5^      $��68��5_      $��25��5`      $
��Left=�5a      
����� �
������ $��Cancel��5e      $��12(�5f      5g      5h      5i      