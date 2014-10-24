<%@ page language="java" contentType="text/html; charset=BIG5"
    pageEncoding="BIG5"%>
<%@ page import="com.google.appengine.api.datastore.DatastoreService" %>
<%@ page import="com.google.appengine.api.datastore.DatastoreServiceFactory" %>
<%@ page import="com.google.appengine.api.datastore.Entity" %>
<%@ page import="com.google.appengine.api.datastore.FetchOptions" %>
<%@ page import="com.google.appengine.api.datastore.Key" %>
<%@ page import="com.google.appengine.api.datastore.KeyFactory" %>
<%@ page import="com.google.appengine.api.datastore.Query" %>
<%@ page import="java.util.List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=BIG5">
<title>Insert title here</title>
</head>
<body>
<% 
	DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
	// Run an ancestor query to ensure we see the most up-to-date
	// view of the Greetings belonging to the selected Guestbook.
	Query query = new Query("USER_RECORD");
	List<Entity> greetings = datastore.prepare(query).asList(FetchOptions.Builder.withDefaults());

%>
<table border="1">
  <tr>
    <td>User name</td>
    <td>Appliance name</td>
    <td>Action</td>
    <td>Date</td>
  </tr>

<% 
	 for (Entity greeting : greetings) {	
		 String name = greeting.getProperty("Name").toString();
		 String appliance = greeting.getProperty("Appliance").toString();
		 String action = greeting.getProperty("Action").toString();
		 String date = greeting.getProperty("Date").toString();
%>	
 	<tr>
    <td><%= name%></td>
    <td> <%= appliance %></td>
    <td><%= action%></td>
    <td> <%= date%> </td>
 	</tr>
<%
	}
%>
  
</table> 

</body>
</html>