   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:GardenGloryWpf.View.EquipmentGardenGloryWpf.View.Equipment  5      4    .GardenGloryWpf.View.Equipment.AddEquipmentView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:GardenGloryWpf.View.Equipment     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  AddEquipmentView��5      $	��400��5	      $	��180��5
       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��Center=�5      $��Equipment Name��5      $��15(�5      �� 5   
   -   5        $��txtEquipmentName��5      $��1��5      $��1��5       $	��200��5!      $
��Left=�5"      $��Center=�5#      $��18(�5$      ��5%      ��  �� Path$0 *AssociatedEquipmentViewModel.EquipmentName�� 5&   
   $��2��6   $��1��6    5'      �� 5(      $	��100 �6#   �� 5)      $	��100 �6#   .+�5+      �� -   5        $��AddEquipmentSave��5,      $��0��5-      $��80��5.      $��25��5/      $��Center=�50      
����� �
������ $
��Save��54      $��12(�55      �� 56      -   5        $��EditEquipmentCancel��57      $��1��58      $��80��59      $��25��5:      $��Center=�5;      
����� �
������ $��Cancel��5?      $��12(�5@      5B      5C      5D      