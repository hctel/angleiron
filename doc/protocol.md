# Frontend-backend protocol documentation
## Abstract
Communication between the frontends and the backend are made through TCP. Standard port is 6210.<br>  
Requests always contain a command (first word), arguments are separaded with an '&'.
If an argument is a list, elements are separated with ';'. If this list contains more than one element, these sub-elements are separated with a '/'.<br>  
## Client frontend requests
### SHOWTYPES
Use to list the different types (models) of products.<br>  
Example:<br>  
  F-B: SHOWTYPES<br>  
  B-F (Response): TYPELIST&modelname1/size1/price1/colorsAvail1/optionsAvail1/ImageName1;(etc.) <br>  
### AUTH
Use to authenticate an user<br>  
Example:
  F-B: AUTH&email&password<br>  
  B-F (Response):<br>  
  If sucessful: AUTHOK&sessionID&clientID&remoteIP<br>  
  If incorrect password: AUTHFAIL&NOPASSWD<br>  
  If unknown user: AUTHFAIL&NOUSER<br>  
### NEWORDER
Use to make an new order <br>  
Example request : NEWORDER&IDcategory&IDclient&Statuspayed&Status&price<br>  
## Merchand frontend requests<br>  
### SHOWORDERS
Use to list all orders<br>  
Example response: ORDERLIST&orderID1/orderName1/orderStatus1/orderDate1/Instock1;orderID2/orderName2/orderStatus2/orderDate2/Instock2; (etc.)<br>  
### DETAILORDER
Use to show the details of an order<br>  
Example request: DETAILORDER&orderID<br>  
Example response: ORDERDETAIL&orderID&elemnt1/quantity1/inStock1/Description1(Name);elemnt2/quantity2/inStock/Description2(Name);elemnt3/quantity3/InStock3/Description3(Name); (etc.)<br>  
### ORDERSTOCK
Use to order new stock<br>  
Request must give the component ID and the quantity <br>  
### STOCKDEDELIVERED
Use to let known the database when new component arrives<br>  
Request must give the component ID and the quantity<br>  
### STOCKTOORDER
Use to let known the marchand what he must order<br>  
Request must give the component ID he wants to check<br>  
### UPDATESTATUS
Use to update the status of an order<br>  
Example request: UPDATESTATUS&orderID&status<br>  
If sucessful: OK<br>  
