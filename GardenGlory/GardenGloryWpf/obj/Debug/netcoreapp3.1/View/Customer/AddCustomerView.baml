   M S B A M L   `   `   `  ����I  EGardenGloryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:GardenGloryWpf.View.CustomerGardenGloryWpf.View.Customer  5      2    ,GardenGloryWpf.View.Customer.AddCustomerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:GardenGloryWpf.View.Customer     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  AddCustomerView��5      $	��750��5	      $	��350��5
       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��5 �6   �� 5      $	��260 �6   �� 5      $	��100 �6   �� 5       $��5 �6   �� 5!      $��* �6   .+�5$   
   �� $��0��5%      $��0��5&      $��Right=�5'      $��Customer Details��5(      $��Oblique$�5)      �� 5*   
   $��1��5+      $��0��5,      $��Right=�5-      $
��Name��5.      �� 5/   
   $��2��50      $��0��51      $��Right=�52      $��Email��53      �� 54   
   $��3��55      $��0��56      $��Right=�57      $��Contact Number��58      �� 59   
   $��4��5:      $��0��5;      $��Right=�5<      $��
Owner Type��5=      �� 5>   
   $��6��5?      $��0��5@      $��Right=�5A      $��Service Details��5B      $��Oblique$�5C      �� 5D   
   $��7��5E      $��0��5F      $��Right=�5G      $��Service Request��5H      �� 5I   
   $��8��5J      $��0��5K      $��Right=�5L      $��Service Type��5M      �� 5N   
   $��0��5O      $��3��5P      $��Right=�5Q      $��Property Details��5R      $��Oblique$�5S      �� 5T   
   $��1��5U      $��3��5V      $��Right=�5W      $��Property Name��5X      �� 5Y   
   $��2��5Z      $��3��5[      $��Right=�5\      $��Street��5]      �� 5^   
   $��3��5_      $��3��5`      $��Right=�5a      $
��City��5b      �� 5c   
   $��4��5d      $��3��5e      $��Right=�5f      $	��Zip��5g      �� 5h   
   $��5��5i      $��3��5j      $��Right=�5k      $��Description��5l      �� 5n   
   -   5        $��txtCustomerName��5o      $��1��5p      $��2��5q      $	��250��5r      $��28��5s      $
��Left=�5t      ��5u      ��  �� Path$" AssociatedCustomerModel.Name��� 5v   
   -   5        $��txtCustomerEmail��5w      $��2��5x      $��2��5y      $	��250��5z      $��28��5{      $
��Left=�5|      ��5}      �� $# AssociatedCustomerModel.Email��� 5~   
   -   5        $��txtContactNumber��5      $��3��5�      $��2��5�      $	��250��5�      $��25��5�      $
��Left=�5�      ��5�      �� $+ %AssociatedCustomerModel.ContactNumber��� 5�   
   -   5        $��CmbOwnerType��5�      $��4��5�      $��2��5�      $	��250��5�      $
��Left=�5�       �� DisplayMemberPath$ OwnerTypeName��5�      $��12(�5�       �� 
IsEditable$
 True��5�       �� IsTextSearchEnabled$ False��5�      ��5�      �� $0 *AssociatedOwnerTypeCmbViewModel.OwnerTypes� �� SelectedItem 5�      �� $7 1AssociatedOwnerTypeCmbViewModel.SelectedOwnerType�	 �� Text	 5�      �� *53AssociatedOwnerTypeCmbViewModel.SearchOwnerTypeText+
 �� UpdateSourceTrigger$
 Explicit=� �� Delay$
 0100���� 5�   
   -   5        $��txtServiceRequest��5�      $��7��5�      $��2��5�      $	��250��5�      $��28��5�      $
��Left=�5�      ��5�      �� $ ServiceRequest��� 5�   
   -   5        $��CmbServiceType��5�      $��8��5�      $��2��5�      $	��250��5�      $
��Left=�5�      $ ServiceTypeName��5�      $��12(�5�      $
 True��5�      $ False��5�      ��5�      �� $4 .AssociatedServiceTypeCmbViewModel.ServiceTypes� 5�      �� $; 5AssociatedServiceTypeCmbViewModel.SelectedServiceType�	 5�      �� *97AssociatedServiceTypeCmbViewModel.SearchServiceTypeText+$
 Explicit=�$
 0100���� 5�   
   -   5        $��txtPropertyName��5�      $��1��5�      $��5��5�      $	��250��5�      $��28��5�      $
��Left=�5�      ��5�      �� $ PropertyName��� 5�   
   -   5        $��txtPropertyStreet��5�      $��2��5�      $��5��5�      $	��250��5�      $��28��5�      $
��Left=�5�      ��5�      �� $ Street��� 5�   
   -	   5        $��txtPropertyCity��5�      $��3��5�      $��5��5�      $	��250��5�      $��28��5�      $
��Left=�5�      ��5�      �� $
 City��� 5�   
   -
   5        $��txtPropertyNZip��5�      $��4��5�      $��5��5�      $	��250��5�      $��28��5�      $
��Left=�5�      ��5�      �� $	 Zip��� 5�   
   -   5        $��txtPropertyDescription��5�      $��5��5�      $��5��5�      $	��250��5�      $��28��5�      $
��Left=�5�      ��5�      �� $ Description�� 5�   
   $��9��6   $��5��6    5�      �� 5�      $	��100 �6#   �� 5�      $��90 �6#   �� 5�      $��90 �6#   .+�5�      �� -   5        $��CSave��5�      $��1��5�      $��68��5�      $��25��5�      
����� �
������ $
��Save��5�      $��12(�5�      �� 5�      -   5        $��CCancel��5�      $��2��5�      $��68��5�      $��25��5�      $
��Left=�5�      
����� �
������ $��Cancel��5�      $��12(�5�      5�      5�      5�      