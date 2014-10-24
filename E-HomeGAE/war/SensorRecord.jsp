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
<%@ page import="com.google.gson.Gson" %>
<%@ page import="java.util.Date" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=BIG5">
<title>Insert title here</title>




    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
      google.load("visualization", "1", {packages:["corechart"]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = google.visualization.arrayToDataTable([
          ['Date', 'Value'],
          <% 
      	DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
      // Run an ancestor query to ensure we see the most up-to-date
      // view of the Greetings belonging to the selected Guestbook.
      	Query query = new Query("SENSOR_RECORD");
      	
      	List<Entity> greetings = datastore.prepare(query.addSort("Date")).asList(FetchOptions.Builder.withDefaults());
      	String endString="";
      	Gson gson = new Gson();
      	int count=0;
      	for(Entity greeting:greetings) {
      		count++;
      		if(count!=greetings.size()) 
      			endString =",";
      		else
      			endString ="";
      		String date=greeting.getProperty("Date").toString();
      		Entity newRecord = new Entity("SENSOR_RECORD_SHOW");
    		
    		newRecord.setProperty("Value", greeting.getProperty("Value"));
    		newRecord.setProperty("Date", new Date(Long.parseLong(greeting.getProperty("Date").toString())));
          	String json = gson.toJson(newRecord.getProperties().values());
          	
       
          	
      %>
          <%=json%><%=endString%>
          
<%
    	}  	
%>
        ]);

        var options = {
          title: 'Company Performance'
        };

        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

        chart.draw(data, options);
      }
    </script>

</head>
<body>


<div id="chart_div" style="width: 900px; height: 500px;"></div>
</body>
</html>