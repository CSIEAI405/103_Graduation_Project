<%@ page language="java" contentType="text/html; charset=BIG5"
    pageEncoding="BIG5"%>
    <%@ page import="com.google.appengine.api.users.User" %>
<%@ page import="com.google.appengine.api.users.UserService" %>
<%@ page import="com.google.appengine.api.users.UserServiceFactory" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<script type='text/javascript' src='jquery.js'></script>
<script type='text/javascript'>
	function connectSocketServer() {
		var support = 'MozWebSocket' in window ? 'MozWebSocket' : ('WebSocket' in window ? 'WebSocket' : null);
		ws = new window[support]('ws://'+url);
		ws.onopen = function () {
			if (ws) {
				ws.send(wsMessage);
				ws.close()
			}
		}
	}
</script>
</head>
<body onload='connectSocketServer()'>
<% 
		String url = request.getParameter("url");
		String action = request.getParameter("action");
		UserService userService = UserServiceFactory.getUserService();
		User user = userService.getCurrentUser();
		String wsMessage="";
		String str="";
		if(!url.isEmpty()&&url!=null&&!action.isEmpty()&&action!=null){
			if (user != null) {
				wsMessage = user.getNickname()+","+action;
				
				 //str+="<script type='text/javascript'> var action="+action+";</script>";	
			}else{
				wsMessage = "annoymous"+","+action;
			}
			 str= "<script type='text/javascript'> var wsMessage='"+wsMessage+"';</script>";	
			 str+="<script type='text/javascript'> var url='"+url+"';</script>";	
		}
		
%>
<%=str%>

</body>
</html>
