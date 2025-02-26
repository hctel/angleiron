# Frontend-backend protocol documentation
## Abstract
Communication between the frontends and the backend are made through TCP. Standard port is 6210.
Requests always contain a command (first word), arguments are separaded with an '&'.
If an argument is a list, elements are separated with ';'. If this list contains more than one element, these sub-elements are separated with a '/'.
## Client frontend requests
### SHOWTYPES
Use to list the different types (models) of products.
Example:
  F-B: SHOWTYPES
  B-F (Response): TYPELIST&modelname1/price1;modelname2/price2;modelname3/price3; (etc.) 
### AUTH
Use to authenticate an user
Example:
  F-B: AUTH&email&password
  B-F (Response):
  If sucessful: AUTHOK&sessionID&clientID&remoteIP
  If incorrect password: AUTHFAIL&NOPASSWD
  If unknown user: AUTHFAIL&NOUSER
### NEWORDER
Use to make an new order 
Example request : NEWORDER&IDcategory&IDclient&Statuspayed&Status&price
## Merchand frontend requests
### SHOWORDERS
Use to list all orders
Example response: ORDERLIST&orderID1/orderName1/orderStatus1/orderDate1/orderStock1;orderID2/orderName2/orderStatus2/orderDate2/orderStock2; (etc.)
### DETAILORDER
Use to show the details of an order
Example request: DETAILORDER&orderID
Example response: ORDERDETAIL&orderID&elemnt1/quantity1/inStock1/Description1(Name);elemnt2/quantity2/inStock/Description2(Name);elemnt3/quantity3/InStock3/Description3(Name); (etc.)
### ORDERSTOCK
Use to order new stock
Request must give the component ID and the quantity 
### STOCKDEDELIVERED
Use to let known the database when knew component arrives
Request must give the component ID and the quantity
### STOCKTOORDER
Use to let known the marchand what he must order
Request must give the component ID he wants to check
