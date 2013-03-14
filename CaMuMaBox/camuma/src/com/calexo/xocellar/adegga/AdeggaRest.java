package com.calexo.xocellar.adegga;

import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

import com.googlecode.androidannotations.annotations.rest.Accept;
import com.googlecode.androidannotations.annotations.rest.Get;
import com.googlecode.androidannotations.annotations.rest.Rest;
import com.googlecode.androidannotations.api.rest.MediaType;

@Rest //("http://api.adegga.com/rest/v1.0")
public interface AdeggaRest {
	@Get("http://api.adegga.com/rest/v1.0/GetWinesByName/{search}/key=76bb197edd4cc2c6db60")
	@Accept(MediaType.APPLICATION_JSON)
	ResponseEntity<AdeggaResponse> getWines(String search);
	
	RestTemplate getRestTemplate();
	

}
