   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:GardenGloryWpf.View.ServiceGardenGloryWpf.View.Service  5      0    *GardenGloryWpf.View.Service.AddPaymentView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:GardenGloryWpf.View.Service     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��500��5      $	��220��5	        � WindowStartupLocation$  CenterScreen=�5
      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� $��1��5      $��0��5      $��Right=�5      $��Center=�5      $��Payment Method��5      �� 5   
   $��2��5       $��0��5!      $��Right=�5"      $��Center=�5#      $��Amount (₱)��5$      �� 5%   
   -   5        $��CmbPaymentMethod��5&      $��1��5'      $��2��5(      $	��250��5)      $
��Left=�5*       �� DisplayMemberPath$ 
MethodName��5+       �� 
IsEditable$
 True��5,       �� IsTextSearchEnabled$ False��5-      ��5.      ��  �� Path$8 2AssociatedPaymentMethodCmbViewModel.PaymentMethods� �� SelectedItem 51      �� $? 9AssociatedPaymentMethodCmbViewModel.SelectedPaymentMethod� �� Text 52      �� *=;AssociatedPaymentMethodCmbViewModel.SearchPaymentMethodText+	 �� UpdateSourceTrigger$	 Explicit=�
 �� Delay$

 0100���� 53   
   -   5        $��	txtAmount��54      $��2��55      $��2��56      $	��250��57      $��28��58      $
��Left=�59      ��5:      �� $ Amount�� 5=   
   $��3��6   $��2��6    5>      �� 5?      $	��170 �6#   �� 5@      $��90 �6#   �� 5A      $��90 �6#   .+�5C      �� -   5        $��AddPaymentSave��5D      $��1��5E      $��68��5F      $��25��5G      
����� �
������ $
��Save��5K      $��12(�5L      �� 5M      -   5        $��AddPaymentCancel��5N      $��2��5O      $��68��5P      $��25��5Q      $
��Left=�5R      
����� �
������ $��Cancel��5V      $��12(�5W      5X      5Y      5Z      