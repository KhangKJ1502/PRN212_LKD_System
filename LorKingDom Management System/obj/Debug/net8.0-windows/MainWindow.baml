   M S B A M L   `   `   `  ����W  SLorKingDom Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:LorKingDom_Management_SystemLorKingDom_Management_System  5   	   -    'LorKingDom_Management_System.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:LorKingDom_Management_System     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 none=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � AllowsTransparency$
 True��5   	   
������  � Title$ 
MainWindow��5   	   $	��500��5      $	��800��5      .��5      ��  �� CornerRadius$ 20��6   
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��1.5* �6#   .+�5      �� -   5        $��\images\close.png��5      $��1��5       K� ZIndex$ 1��5         imgClose#��[  5      �� 5!      $ 	10 0 0 10��6   ��5"      �� 5$       �� 
StartPoint$	 0,0&�6*   	 �� EndPoint$		 1,1&�6;   .��5%      � 
 � Color$
 DarkCyan��6'    � Offset$ 0Q�68   � 5&      $
 
BlueViolet��6'   $ 1Q�6:   5'      ._�5*      � .+�5,      �� .+�5-      �  � Points �    -1��� ;X�����#4eb186 J� Opacity$ .1Q�6N   � 5.      ' �    �� �� ���� ��
��
�������$	 .05Q�6Q   A� 5/      $��250 450 0 0q�6"   $��40��67   $��40��6B   
�������$
 0.05Q�6[   A� 50      $��
50 400 0 0q�6"   $��20��66   $��20��6A   
�������$
 0.05Q�6Z   51      �� 54      $��Center=�6!   .+�55      �� $��SignUp��6$     	titleText#��[ 62   �� 56      $$��SignUp now to connect with us!��6$     descriptionText#��[ 6J   $ .8Q�6s   $��20 30q�6�   �� 57      -   5        $��SignUp��57   !     signUpButton#��[ 62   6X   58      59      5:      �� 5=      -   5        ���#ffffff$��1��5=   *   $ 	0 10 10 0��6:   ._�5?      �� $��Center=�6   .+�5A      �� $��Sign In��6    #��[ 6/   
����� �6R   �� 5C       �� Orientation$ 
Horizontal=�6!   $
��0 20q�6:   $��Center=�6H   .+�5D      ��   ButtonCircle#��[ 6!   .��5E      �� $��/images/google.png��6$   $��15��6@   $��15��6K   5F      �� 5G      #��[ 6!   .��5H      �� $��/images/facebook.png��6$   $��15��6B   $��15��6M   5I      �� 5J      #��[ 6!   .��5K      �� $��/images/linkedin.png��6$   $��15��6B   $��15��6M   5L      5M      �� 5O      $��or use your email:��6    #��[ 6:   ���#878787$��	0 10 0 15q�6x   �� 5S      $��1q�6   ���#acb0af$
��70 7q�6G   $ 5��6U   ._�5T      � $	��7 9q�6    5U      �� 5V   "   $
��auto �63   �� 5W   "   $��* �63   .+�5Z      �� $��/images/email.png��6$   $��20��6?   $ .5Q�6K   �� 5[      -   5         ��Name$ 	textEmail��5[   (   $��email��6[     textHint#��[ 6h   �� 5\      -   5         ��Name$ txtEmail��5\   &     textbox#��[ 69   5]      5^      �� 5b      $��1q�6   ���#acb0af$
��70 7q�6G   $ 5��6U   ._�5c      � $	��7 9q�6    5d      �� 5e   "   $
��auto �63   �� 5f   "   $��* �63   .+�5i      �� $��/images/lock.png��6$   $��20��6>   $ .5Q�6J   �� 5j      -   5        $ textPassword��5j   (   $��password��6a   #��[ 6q   G� 5k      -   5         G�Name$ txtPassword��5k   *   #��[ 6m   5l      5m      �� 5p      -   5        $��SignIn��5p        signInButton#��[ 6C   5r      5s      5t      5u      5v      