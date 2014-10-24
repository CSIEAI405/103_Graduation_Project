package com.example;

import java.io.IOException;
import java.util.Date;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.google.appengine.api.datastore.DatastoreService;
import com.google.appengine.api.datastore.DatastoreServiceFactory;
import com.google.appengine.api.datastore.Entity;
import com.google.gson.Gson;

public class RecordSensor extends HttpServlet {

	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		// TODO Auto-generated method stub
		int value =Integer.parseInt(request.getParameter("value"));
		long date =Date.parse(request.getParameter("date"));
		DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
		Entity newRecord = new Entity("SENSOR_RECORD");
		
		newRecord.setProperty("Value", value);
		newRecord.setProperty("Date", date);
		datastore.put(newRecord);
	}
	
}
