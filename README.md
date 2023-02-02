# DesktopAppDevAssignment1

This program is a simple inventory tracker for a shop with the ability to add to cart for customer service checkout.


It allows viewing the available inventory of the shop by pressing the CONNECT button on the Admin window, and then the VIEW DATA button.
In order to add to cart on the Sales window, insert desired Product ID, Product Name, and the amount of KG desired, then press the SELECT button. This adds items to the cart table in the Sales page.


Once on the Sales window, pressing the CONNECT button will display the current cart table.
If you want something more from the inventory, you can press the RETURN TO ADMIN button. Your cart will remain when you return to the Sales window, so long as you press the CONNECT button every time the window switches.


Example tutorial video: https://www.youtube.com/watch?v=4H2-1VzGiiU&ab_channel=DennisMayuga



## All functions on Admin window:

#### CONNECT button:

Establishes connection to the database. Necessary to press this before using any other function, apart from the GO TO SALES button.



#### VIEW DATA button:

Displays the inventory table with all currently available items in the shop by ID, name, price, and weight.



#### SELECT button:

Button to be pressed after typing the name and weight of the item desired in the textboxes, to send this information to cart on the Sales window.



#### GO TO SALES button:

This allows you to go to the Sales window.

Note: Every time there is a change between windows, it is necessary to press the CONNECT button before any other button, to restore connection to the database.



#### INSERT button: 

Add another item that is not already in the inventory table by writing in all fields, then pressing INSERT. Upon pressing VIEW DATA, the inventory will reflect the new item added.



#### UPDATE button:

Ability to update an already existing item in the inventory table by writing in all fields, then pressing UPDATE. Upon pressing VIEW DATA, the inventory will reflect the changes to the item.



#### DELETE button:

Deletes the entire row of the selected item.


## All functions on Sales window:

#### CONNECT button:

Establishes connection to the database. Necessary to press this before using any other function, apart from the GO BACK TO ADMIN button.



#### VIEW CART button:

Displays the cart table with all added items by product ID, name, price, and weight.



#### GO BACK TO ADMIN button:

This allows you to go to the Admin window.

Note: Every time there is a change between windows, it is necessary to press the CONNECT button before any other button, to restore connection to the database.



#### OK TO PAY button:

This will finalise the transaction with the customer, updating the remaining inventory in the shop after this transaction, and deleting the cart records.





# Group Members
Mayuga, Dennis

Qui, Chaohao

Magda, Alex
