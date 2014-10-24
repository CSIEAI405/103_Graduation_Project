package com.example;

import java.io.IOException;
import java.util.Date;

import javax.servlet.http.*;

import com.google.appengine.api.datastore.DatastoreService;
import com.google.appengine.api.datastore.DatastoreServiceFactory;
import com.google.appengine.api.datastore.Entity;
import com.google.appengine.api.datastore.Key;
import com.google.appengine.api.datastore.KeyFactory;

@SuppressWarnings("serial")
public class E_HomeServlet extends HttpServlet {
	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws IOException {
		String name = request.getParameter("name");
		String appliance = request.getParameter("appliance");
		String action = request.getParameter("action");
		String date = request.getParameter("date");
		DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
		Entity newRecord = new Entity("USER_RECORD");
		newRecord.setProperty("Name", name);
		newRecord.setProperty("Appliance", appliance);
		newRecord.setProperty("Action", action);
		newRecord.setProperty("Date", date);
		datastore.put(newRecord);
		response.sendRedirect("/record.jsp");
	}
}
