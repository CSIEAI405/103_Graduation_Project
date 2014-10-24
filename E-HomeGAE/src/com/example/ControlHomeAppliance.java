package com.example;

import java.io.IOException;
import java.io.Writer;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.google.appengine.api.users.User;
import com.google.appengine.api.users.UserService;
import com.google.appengine.api.users.UserServiceFactory;

@SuppressWarnings("serial")
public class ControlHomeAppliance extends HttpServlet {

	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		Writer writer = response.getWriter();
		String url = request.getParameter("url");
		String action = request.getParameter("action");
		UserService userService = UserServiceFactory.getUserService();
		User user = userService.getCurrentUser();
		String wsMessage="";
		if(!url.isEmpty()&&url!=null&&!action.isEmpty()&&action!=null){
			if (user != null) {
				wsMessage = user.getNickname()+","+action;
			}else{
				wsMessage = "annoymous"+","+action;
			}
			
			writer.write("<html>");
			writer.write("<head>");
			writer.write("<script type='text/javascript' src='jquery.js'></script>");
			writer.write("<script type='text/javascript'>");
			writer.write("function connectSocketServer() {");
			writer.write("var support = 'MozWebSocket' in window ? 'MozWebSocket' : ('WebSocket' in window ? 'WebSocket' : null);");
			writer.write("ws = new window[support]('ws://"+url+"');");
			writer.write("ws.onopen = function () {");
			writer.write("if (ws) {"
						+ "ws.send('"+wsMessage+"');"
						+ "ws.close();"
						+ "}");
			writer.write("}");
			writer.write("}");
			writer.write("</script>");
			writer.write("</head>");
			writer.write("<body onload='connectSocketServer()'>");
			
			
			writer.write("</body>");
			writer.write("</html>");
		}
	}

	

}
