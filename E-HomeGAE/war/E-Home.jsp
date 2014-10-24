<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="com.google.appengine.api.users.User" %>
<%@ page import="com.google.appengine.api.users.UserService" %>
<%@ page import="com.google.appengine.api.users.UserServiceFactory" %>
<%--[START imports]--%>
<%@ page import="com.google.appengine.api.datastore.DatastoreService" %>
<%@ page import="com.google.appengine.api.datastore.DatastoreServiceFactory" %>
<%@ page import="com.google.appengine.api.datastore.Entity" %>
<%@ page import="com.google.appengine.api.datastore.FetchOptions" %>
<%@ page import="com.google.appengine.api.datastore.Key" %>
<%@ page import="com.google.appengine.api.datastore.KeyFactory" %>
<%@ page import="com.google.appengine.api.datastore.Query" %>
<%--[END imports]--%>
<%@ page import="java.util.List" %>
<%@ taglib prefix="fn" uri="http://java.sun.com/jsp/jstl/functions" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html class="">
<!--<![endif]-->
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>智慧家庭E-home</title>
<link href="boilerplate.css" rel="stylesheet" type="text/css">
<link href="E-Home.css" rel="stylesheet" type="text/css">
<link href="SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css">
<!-- 
若要深入了解檔案頂端 html 標籤周圍的條件式註解:
paulirish.com/2008/conditional-stylesheets-vs-css-hacks-answer-neither/

如果您使用自訂的 Modernizr 組建 (http://www.modernizr.com/)，請執行下列動作:
* 在這裡將連結插入您的 js
* 將下列連結移至 html5shiv
* 將「no-js」類別新增至頂端的 html 標籤
* 如果您在 Modernizr 組建中包含 MQ Polyfill，也可以將連結移至 respond.min.js 
-->
<!--[if lt IE 9]>
<script src="//html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
	<script src="respond.min.js"></script>
	<script src="SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
	 <script type="text/javascript" src="jquery.js"></script>
	<script type="text/javascript">
        var noSupportMessage = "Your browser cannot support WebSocket!";
        var ws;
    	var clickCount=0;
        function appendMessage(message) {
            $('body').append(message);
        }
    
        function connectSocketServer( IPAddress, Port) {
            var support = "MozWebSocket" in window ? 'MozWebSocket' : ("WebSocket" in window ? 'WebSocket' : null);
    
            if (support == null) {
                appendMessage("* " + noSupportMessage + "<br/>");
                return;
            }
    
            appendMessage("* Connecting to server ..<br/>");
            // create a new websocket and connect
            ws = new window[support]('ws://'+IPAddress+':'+Port);
    
            // when data is comming from the server, this metod is called
            ws.onmessage = function (evt) {
                appendMessage("# " + evt.data + "<br />");
				
            };
    
            // when the connection is established, this method is called
            ws.onopen = function () {
                appendMessage('* Connection open<br/>');
            };
    
            // when the connection is closed, this method is called
            ws.onclose = function () {
                appendMessage('* Connection closed<br/>');
            }
        }
    
        function sendMessage(message) {
            if (ws) {
                ws.send(message);
            }
        }
    
        function disconnectWebSocket() {
            if (ws) {
                ws.close();
            }
        }
    
        function connectWebSocket() {
            connectSocketServer();
        }
    
		

        
		
		function check() {
			var IPAddress = document.getElementById("txtIPAddress").value;
			var Port =  document.getElementById("txtPort").value
            if(IPAddress=="" | Port=="") {
				window.alert("IP位址及通訊埠號不得為空!!!")
				return;
			}
			connectSocketServer(IPAddress,Port);
			
        }
    
    	function changeImage() {
			 if(clickCount%2==0) {
				sendMessage(nickName+',7');
			 	$("#switch").attr("src","img/on.png");
			 }
			 else {
				sendMessage(nickName+',8');
			 	$("#switch").attr("src","img/off.png");
			 }
			 clickCount++;
				
			 
		}
    </script>
</head>
<body>
		<% 
     		UserService userService = UserServiceFactory.getUserService();
			User user = userService.getCurrentUser();
			String str;
			
			if (user != null) {
				str = "<script type='text/javascript'> var nickName='"+user.getNickname()+"';</script>";
				 pageContext.setAttribute("user", user);
				
		%>
				<p>Hello, ${fn:escapeXml(user.nickname)}! (You can
				<a href="<%= userService.createLogoutURL(request.getRequestURI()) %>">sign out</a>.)</p>
    	<%
			} else {
				str = "<script type='text/javascript'> var nickName='annoymous';</script>";	
		%>
			
				<p>Hello!
				<a href="<%= userService.createLoginURL(request.getRequestURI()) %>">Sign in</a>
				to include your name with greetings you post.</p>
		<%
			}		
		%>
		<%= str %>
<div class="gridContainer clearfix">
  <div id="LayoutDiv1">
    <h1>家電控制  </h1>
  </div>
  <p>&nbsp;</p>
  <p>&nbsp;</p>
  <div id="LayoutDiv2">
    <p> <strong>連線設置</strong></p>
    <p>主機位址：
  <input name="txtIPAddress" type="text" id="txtIPAddress" size="15">
      通訊埠：
      <input name="txtPort" type="text" id="txtPort" size="5">
      <input type="button" name="btnConnect" id="btnConnect" value="連線" onClick="check()">
      <input type="button" name="btnDisconnect" id="btnDisconnect" value="結束連線">
    </p>
  </div>
  <p>&nbsp;</p>
  <div id="LayoutDiv3">
    <div id="TabbedPanels1" class="TabbedPanels">
      <ul class="TabbedPanelsTabGroup">
        <li class="TabbedPanelsTab" tabindex="0"><img src="img/fan.png" width="64" height="64"></li>
        <li class="TabbedPanelsTab" tabindex="1"><img src="img/experience_speakers_twin.png" width="64" height="64"></li>
        <li class="TabbedPanelsTab" tabindex="2"><img src="img/air-conditioner.png" width="64" height="64"></li>
	  </ul>
      <div class="TabbedPanelsContentGroup">
        <div class="TabbedPanelsContent">
          <button type="button"  onClick="sendMessage(nickName+',1')"><img src="img/power_blue.png" width="64" height="64" ></button>
          <button type="button"  onClick="sendMessage(nickName+',2')"><img src="img/wind.png" width="64" height="64"></button>
          <button type="button"  onClick="sendMessage(nickName+',3')"><img src="img/timer.png" width="64" height="64"></button>
        </div>
        <div class="TabbedPanelsContent">
          <button type="button"  onClick="sendMessage(nickName+',4')"><img src="img/power_blue.png" width="64" height="64"></button>
          <button type="button"  onClick="sendMessage(nickName+',5')"><img src="img/media_volume_up.png"width="64" height="64"></button>
          <button type="button"  onClick="sendMessage(nickName+',6')"><img src="img/media_volume_down.png" width="64" height="64"></button>
        </div>
        <div class="TabbedPanelsContent">
          <button type="button"  onClick="changeImage()"><img src="img/off.png" width="64" height="64" id="switch"></button>
          <button type="button"  onClick="sendMessage(nickName+',9')"><img src="img/add.png"width="64" height="64"></button>
          <button type="button"	 onClick="sendMessage(nickName+',10')"><img src="img/minus.png" width="64" height="64"></button>
        </div>
	  </div>
    </div>
  </div>
  
</div>

	<script type="text/javascript">
		var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
	</script>
    
</body>
</html>
