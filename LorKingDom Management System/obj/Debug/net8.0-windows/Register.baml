   M S B A M L   `   `   `  ����W  SLorKingDom Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:LorKingDom_Management_SystemLorKingDom_Management_System  5   	   +    %LorKingDom_Management_System.Register   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:LorKingDom_Management_System     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � AllowsTransparency$
 True��5   	   
������  � Title$ 
MainWindow��5   	   $	��500��5   	   $	��800��5   	   .��5      ��  �� CornerRadius$ 20��6   
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��1.5* �6#   .+�5      �� -   5        $��images\close.png��5      $��1��5       K� ZIndex$ 1��5         imgClose#��[  5      �� 5       $ 	10 0 0 10��6   ��5!      �� 5#       �� 
StartPoint$	 0,0&�6*   	 �� EndPoint$		 1,1&�6;   .��5$      � 
 � Color$
 DarkCyan��6'    � Offset$ 0Q�68   � 5%      $
 
BlueViolet��6'   $ 1Q�6:   5&      ._�5)      � .+�5+      �� .+�5,      �  � Points �    -1��� ;X�����#4eb186 J� Opacity$ .1Q�6N   � 5-      ' �    �� �� ���� ��
��
�������$	 .05Q�6Q   A� 5.      $��250 450 0 0q�6"   $��40��67   $��40��6B   
�������$
 0.05Q�6[   A� 5/      $��
50 400 0 0q�6"   $��20��66   $��20��6A   
�������$
 0.05Q�6Z   50      �� 53      $��Center=�6!   .+�54      �� $��SignIn��6$     	titleText#��[ 62   �� 55      $%��Sign In now to connect with us!��6$     descriptionText#��[ 56   $   $ .8Q�57   $   $��20 30q�58   $   �� 59      -   5        $��SignIn��59   !     signUpButton#��[ 62   6X   5:      5;      5<      �� 5?      -   5        ���#ffffff$��1��5@      $ 	0 10 10 0��5A      ._�5D      �� $��Center=�6   .+�5F      �� $��Create an Account��6    #��[ 5G       
����� �$��0,0,0,10q�5I       �� 5L      $(��"Please fill in your details below:��6    #��[ 5M       ���#878787$��0 0 0 15q�5O       �� 5R      $��1q�6   ���#acb0af$
��70 5q�6G   $ 5��6U   ._�5S      � $	��7 9q�6    5T      �� 5U   "   $
��auto �63   �� 5V   "   $��* �63   .+�5Y      �� $��images/user.png��6$   $��20��6=   $ .5Q�6I   �� 5[      -   5         ��Name$ txtName��5[   &     textbox#��[ 5\   &   ��5]   &   �� *TextBoxItem.AccountName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5^      5_      �� 5b      $��1q�6   ���#acb0af$
��70 5q�6G   $ 5��6U   ._�5c      � $	��7 9q�6    5d      �� 5e   "   $
��auto �63   �� 5f   "   $��* �63   .+�5h      �� $��\images\phone.png��6$   $��20��6?   $ .5Q�6K   �� 5i      -   5        $ txtPhone��5i   &   #��[ 5j   &   ��5k   &   �� *TextBoxItem.PhoneNumber+$ TwoWay=�$ PropertyChanged=�5l      5m      �� 5p      $��1q�6   ���#acb0af$
��70 5q�6G   $ 5��6U   ._�5q      � $	��7 9q�6    5r      �� 5s   "   $
��auto �63   �� 5t   "   $��* �63   .+�5v      �� $��images/email.png��6$   $��20��6>   $ .5Q�6J   �� 5w      -   5        $ txtEmail��5w   &   #��[ 5x   &   ��5y   &   �� *TextBoxItem.Email+$ TwoWay=�$ PropertyChanged=�5{      5|      �� 5      $��1q�6   ���#acb0af$
��70 5q�6G   $ 5��6U   ._�5�      � $	��7 9q�6    5�      �� 5�   "   $
��auto �63   �� 5�   "   $��* �63   .+�5�      �� $��images/lock.png��6$   $��20��6=   $ .5Q�6I   �� 5�      -   5         ��Name$ textPassword��5�   (     textHint#��[ 5�   (   G� 5�      -   5         G�Name$ txtPassword��5�   *   #��[ 5�   *   5�   *   5�      5�      �� 5�      -	   5        $��SignUp��5�        signInButton#��[ 5�      $��0,20,0,0q�5�      5�      5�      5�      5�      5�      